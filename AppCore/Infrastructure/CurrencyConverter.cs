using AppCore.Common;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text.Json;

namespace AppCore.Infrastructure
{
    public class CurrencyConverter
    {
        private string apiKey;
        private readonly IMemoryCache cache;
        private readonly IConfiguration configuration;

        public CurrencyConverter(IMemoryCache cache, IConfiguration configuration)
        {
            this.cache = cache;
            apiKey = configuration.GetValue<string>("CurrencyConverterApiKey");
        }

        public Result<decimal> GetTotalInRequestedCurrency(string fromcurrency, string toCurrecny, decimal total)
        {
            var GetRateResult = GetRate(fromcurrency, toCurrecny);
            if (GetRateResult.IsFailure)
            {
                var convertedAmount = total;
                return Result.Ok(convertedAmount);
            }
            return Result.Ok(total * GetRateResult.Value);
        }

        public Result<decimal> GetRate(string fromCurrencyIso3Code, string toCurrencyIso3Code)
        {
            try
            {
                if (fromCurrencyIso3Code == toCurrencyIso3Code)
                {
                    return Result.Ok<decimal>(1);
                }

                decimal exchangeRate;
                var cacheKey = $"{fromCurrencyIso3Code}-{toCurrencyIso3Code}";
                if (!cache.TryGetValue(cacheKey, out exchangeRate))
                {
                    var URL = $"https://api.apilayer.com/fixer/convert?to={toCurrencyIso3Code}&from={fromCurrencyIso3Code}&amount=1";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                    request.Headers.Add("apikey", apiKey);
                    try
                    {
                        using (var response = (HttpWebResponse)request.GetResponse())
                        {
                            using (var reader = new StreamReader(response.GetResponseStream()))
                            {
                                var objText = reader.ReadToEnd();
                                JObject joResponse = JObject.Parse(objText);
                                exchangeRate = System.Convert.ToDecimal((JValue)joResponse["result"]);
                            }
                        }
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromHours(24));

                        cache.Set(cacheKey, exchangeRate, cacheEntryOptions);
                    }
                    catch (Exception ex)
                    {
                        return Result.Ok<decimal>(31);
                        //return Result.Fail<decimal>(ex.Message);
                    }
                }
                return Result.Ok<decimal>(exchangeRate);
            }
            catch (WebException ex)
            {
                return Result.Fail<decimal>($"An error occurred while retrieving the exchange rate: {ex.Message}");
            }
            catch (JsonException ex)
            {
                return Result.Fail<decimal>($"An error occurred while parsing the response: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result.Fail<decimal>($"An unexpected error occurred: {ex.Message}");
            }
        }


    }
}
