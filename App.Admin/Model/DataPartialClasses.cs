using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.ComponentModel;
//using Microsoft.Data.OData.Query.SemanticAst;
using NotAClue.ComponentModel.DataAnnotations;

namespace DynamicData.Admin.Model
{


    #region Sections

    [MetadataType(typeof(SectionsMetadata))]
    public partial class Section
    {

     
    }

    public class SectionsMetadata
    {
        [UIHint("Html")]
        public object Description { get; set; }
        [ScaffoldColumn(false)]
        public object SectionPhotoes { get; set; }
    }

    #endregion

}