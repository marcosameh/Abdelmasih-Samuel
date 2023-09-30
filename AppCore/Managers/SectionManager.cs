using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AppCore.Managers
{
    public class SectionManager
    {
      
        private readonly AppCoreContext _context;
        public SectionManager(AppCoreContext context)
        {
            _context = context;
           
        }

        public IQueryable<Section> GetSections()
        {
            return _context.Sections.Include(x => x.SectionPhotos).OrderBy(x => x.DisplayOrder);
                                  
        }

    }
}
