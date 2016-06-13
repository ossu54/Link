using Link.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Link.Models.AddSitesViewModels
{
    public class FormSubmissionViewModel : IValidatableObject
    {
        [Required]
        public User User { get; set; }
        [Required]
        public IList<WebSiteInfo> WebSiteInfos { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            int minSites = 5; int maxSites = 10; int i = 0; int j = 0;
            Validator.TryValidateObject(User, new ValidationContext(User), results);
            if (WebSiteInfos.Count() < minSites || WebSiteInfos.Count() > maxSites) results.Add(new ValidationResult("Vale saitide arv, ei kasutanud rakendust, et POSTitada."));
            List<WebSiteInfo> nonNullUrlWsis = WebSiteInfos.Where(wsi => wsi.Url != null).ToList();
            if (nonNullUrlWsis.Select(wsi => wsi.Url.Replace("://www.", "://").Replace("https://", "http://")).Distinct().Count() != nonNullUrlWsis.Count()) results.Add(new ValidationResult("Ühte URLi võib sisestada vaid korra."));
            foreach (WebSiteInfo wsi in WebSiteInfos)
            {
                var context = new ValidationContext(wsi);
                IEnumerable<ValidationResult> elemResults = wsi.Validate(context);
                j++;
                if (elemResults.Count() != 0 && (wsi.Category != null || wsi.Points != null || wsi.Title != null || wsi.Url != null))
                {
                    ValidationResult valRes = elemResults.Aggregate((res1, res2) => new ValidationResult(res1.ErrorMessage + " " + res2.ErrorMessage));
                    valRes.ErrorMessage = "Sait " + j.ToString() + ": " + valRes.ErrorMessage + " ";
                    results.Add(valRes);
                }
                i += elemResults.Count() == 0 ? 1 : 0;
            }
            if (i < minSites) results.Add(new ValidationResult("Sisesta korrektselt vähemalt " + minSites + " saiti."));
            return results;
        }
    }
}
