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
    
    public partial class Faq
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faq()
        {
            this.FaqLocalizeds = new HashSet<FaqLocalized>();
        }
    
        public int Id { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int DisplayOrder { get; set; }
    
        public virtual FaqCategory FaqCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaqLocalized> FaqLocalizeds { get; set; }
    }
}