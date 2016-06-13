using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using Zelda.Data;
using Microsoft.EntityFrameworkCore;
using Zelda.Models;

namespace Zelda.Controllers
{
    public class SitesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SitesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<string> Sites(int nrResults = 10, string sortBy = "points", bool reverse = false)
        {
            List<WebSiteInfo> siteInfos = await _context.WebSiteInfos.ToListAsync();
            List<SiteInfoCombined> returnData = new List<SiteInfoCombined>();
            siteInfos.GroupBy(wsi => wsi.Url.Replace("://www.", "://").Replace("https://", "http://")).ToList().ForEach(grouping => 
            {
                returnData.Add(new SiteInfoCombined(grouping.Key, grouping.ToList()));
            });
            if (sortBy == "url") returnData.Sort(SiteInfoCombined.UrlComparison);
            if (sortBy == "points") returnData.Sort(SiteInfoCombined.PointsComparison);
            if (reverse) returnData.Reverse();
            return JsonConvert.SerializeObject(returnData.Take(nrResults));
        }
    }
}
