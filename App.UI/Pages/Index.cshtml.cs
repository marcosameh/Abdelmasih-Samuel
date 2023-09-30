using App.UI.Models;
using App.UI.Enums;
using Microsoft.AspNetCore.Mvc;
using AppCore.Managers;
using System.Collections.Generic;
using AppCore.Models;
using Microsoft.Extensions.Options;
using AppCore.Infrastructure;
using System.Linq;

namespace App.UI.Pages
{
    public class IndexModel : PageModelBase
    {
        private readonly HomeBannerManager homeBannerManager;
        private readonly SectionManager sectionManager;

        public List<HomeBanner> HomeBanners { get; private set; }
        public IQueryable<Section> PlanetSections { get; private set; }

        public IndexModel(HomeBannerManager homeBannerManager,SectionManager sectionManager)
        {
            PageName = PageNames.Home;
            this.homeBannerManager = homeBannerManager;
            this.sectionManager = sectionManager;
        }

        public IActionResult OnGet()
        {
            HomeBanners = homeBannerManager.GetHomeBanners();
            PlanetSections=sectionManager.GetSections();
            return Page();
        }

    }
}

