//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DynamicData.Admin.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MediaItem
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Alt { get; set; }
        public string VedioUrl { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string ItemKey { get; set; }
        public int PageId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    
        public virtual SitePage SitePage { get; set; }
    }
}
