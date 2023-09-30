using App.UI.Models;
using App.UI.Enums;
using Microsoft.AspNetCore.Mvc;
using AppCore.Managers;
using System.Collections.Generic;
using AppCore.Models;
using Microsoft.Extensions.Options;
using AppCore.Infrastructure;

namespace App.UI.Pages
{
    public class IndexModel : PageModelBase
    {
        private readonly HomeBannerManager homeBannerManager;

        public List<HomeBanner> HomeBanners { get; private set; }
        public IndexModel(HomeBannerManager homeBannerManager)
        {
            PageName = PageNames.Home;
            this.homeBannerManager = homeBannerManager;
        }

        public IActionResult OnGet()
        {
            HomeBanners = homeBannerManager.GetHomeBanners();

            return Page();
        }

    }
}

