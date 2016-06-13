using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link.Models.DisplaySitesViewModels
{
    public class DisplaySitesViewModel
    {
        public IList<SiteInfoCombined> SiteInfosCombined { get; set; }
        public DisplaySitesViewModel(IList<SiteInfoCombined> infos)
        {
            SiteInfosCombined = infos;
        }
    }
}
