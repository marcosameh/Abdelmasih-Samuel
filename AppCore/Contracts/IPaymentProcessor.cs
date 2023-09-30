using AppCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Contracts
{
    public interface IPaymentProcessor
    {
        Result<string> GetPaymentIframeSrc(string bookingKey, string firstName, string lastName, string Phone, string Email, decimal totalCost, string redirectUrl = "");
    }
}
