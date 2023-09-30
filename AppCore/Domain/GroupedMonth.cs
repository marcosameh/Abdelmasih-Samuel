using AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCore.Domain
{
    public class GroupedMonth
    {
        public int Month { get; set; }

        public IEnumerable<News> NewsList { get; set; }
        public int Year { get; set; }

        public int NewsCount
        {
            get
            {
                return NewsList.Count();
            }
        }
    }
}
