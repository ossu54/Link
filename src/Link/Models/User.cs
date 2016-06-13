using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Link.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Eesnimi on kohustuslik väli.")]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Perenimi on kohustuslik väli.")]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Sünniaeg on kohustuslik väli.")]
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        public override bool Equals(object obj)
        {
            var usr = obj as User;
            if (FirstName == usr.FirstName && LastName == usr.LastName && BirthDate.Date == usr.BirthDate.Date) return true;
            return false;
        }
        public override int GetHashCode()
        {
            return Tuple.Create(LastName, FirstName, BirthDate).GetHashCode();
        }
    }
}
