﻿using AppCore.Enums;
using AppCore.Models;
using AppCore.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AppCore.Managers
{
    public class MediaItemManager
    {
        private readonly AppCoreContext context;

        public MediaItemManager(AppCoreContext context)
        {

            this.context = context;
        }

    

        public IQueryable<MediaItem> GetMediaItemsByPage(int pageId)
        {
            return context.MediaItems.Where(x => x.PageId == pageId).OrderBy(x => x.DisplayOrder);
        }

      

        public MediaItem GetMediaItem(string mediaItemKey)
        {
            var item = context.MediaItems.FirstOrDefault(x => x.ItemKey == mediaItemKey);
            return item;
        }
    }
}