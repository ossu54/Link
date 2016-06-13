using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Link.Models
{
    public class WebSiteInfo
    {
        [Key]
        public int ID { get; set; }
        public User User { get; set; }
        [Required(ErrorMessage = "Pealkiri on kohustuslik väli."), MaxLength(100)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Url on kohustuslik väli."), MaxLength(100)]
        [Url(ErrorMessage = "Url vales formaadis, õige on http://example.com.")]
        public string Url { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string Owner { get; set; }
        [Required(ErrorMessage = "Kategooria on kohustuslik väli."), MaxLength(100)]
        public string Category { get; set; }
        [Required(ErrorMessage = "Punktid on kohustuslik väli.")]
        [Range(1,10)]
        public int? Points { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(this, validationContext, results, true);
            return results;
        }   
    }
}
