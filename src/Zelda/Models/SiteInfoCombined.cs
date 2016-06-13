using System;
using System.Collections.Generic;
using System.Linq;

namespace Zelda.Models
{
    public class SiteInfoCombined
    {
        public string Url { get; set; }
        public int TotalPoints { get; set; }
        public IList<string> Titles { get; set; }
        public IList<string> Descriptions { get; set; }
        public IList<string> Owners { get; set; }
        public IList<string> Categories { get; set; }

        public SiteInfoCombined(string key, List<WebSiteInfo> wsis)
        {
            var strComparer = new LowerCaseNoWhiteSpaceStringComparer();
            Url = key;
            TotalPoints = wsis.Select(wsi => wsi.Points).Aggregate((p1, p2) => p1 + p2);
            Titles = wsis.Select(wsi => wsi.Title).Distinct(strComparer).ToList();
            Descriptions = wsis.Where(wsi => wsi.Description != null).Select(wsi => wsi.Description).Distinct(strComparer).ToList();
            Owners = wsis.Where(wsi => wsi.Description != null).Select(wsi => wsi.Owner).Distinct(strComparer).ToList();
            Categories = wsis.Select(wsi => wsi.Category).Distinct(strComparer).ToList();
        }
        
        public static Comparison<SiteInfoCombined> PointsComparison = delegate (SiteInfoCombined site1, SiteInfoCombined site2)
        {
            return site2.TotalPoints.CompareTo(site1.TotalPoints);
        };

        public static Comparison<SiteInfoCombined> UrlComparison = delegate (SiteInfoCombined site1, SiteInfoCombined site2)
        {
            // TODO
            return 0;
        };

        private class LowerCaseNoWhiteSpaceStringComparer : IEqualityComparer<string>
        {
            public bool Equals(string s1, string s2)
            {
                return RemoveWhiteSpaceAndLower(s1) == RemoveWhiteSpaceAndLower(s2);
            }
            public int GetHashCode(string obj)
            {
                return RemoveWhiteSpaceAndLower(obj).GetHashCode();
            }
            private string RemoveWhiteSpaceAndLower(string str)
            {
                return str.Replace(" ", string.Empty).ToLower();
            }
        }
    }
}
