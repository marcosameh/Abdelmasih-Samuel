using AppCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Domain
{
    public class ArchiveModel
    {
        public string TargetYear;
        public int Year { get; set; }
        public IEnumerable<News> NewsDates { get; set; }
        public IEnumerable<GroupedMonth> Months { get; set; }
    }
}
