
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCore.Models
{
    public partial class SectionPhoto
    {

        [NotMapped]
        public string LargePhotoPath { get { return "/photos/sections/" + Photo; } }

        [NotMapped]
        public string MediemPhotoPath { get { return "/photos/sections/" + Photo.Replace("_lg", "_md"); } }

    }
}
