using AppCore.Enums;
using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace AppCore.Managers
{
    public class BannerManager
    {
        private readonly AppCoreContext _context;
        private readonly int _languageId;
        public BannerManager(AppCoreContext context, int languageId)
        {
            _context = context;
            _languageId = languageId;
        }



        public Banner GetBanner(int PageId)
        {

            var banner = _context.Banners.Include(x => x.BannerLocalizeds.Where(x => x.LanguageId == _languageId)).SingleOrDefault(u => u.PageId == PageId && u.Active == true);

            banner?.Localize(_languageId);
            return banner;
        }

        public IEnumerable<Banner> GetBanners()
        {
            return _context.Banners.Where(u => u.Active.HasValue).OrderBy(x => x.DisplayOrder);
        }



    }
}