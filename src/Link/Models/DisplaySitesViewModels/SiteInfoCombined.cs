using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link.Models.DisplaySitesViewModels 
{
    public class SiteInfoCombined
    {
        public string Url { get; set; }
        public int TotalPoints { get; set; }
        public IList<string> Titles { get; set; }
        public IList<string> Descriptions { get; set; }
        public IList<string> Owners { get; set; }
        public IList<string> Categories { get; set; }
    }
}
