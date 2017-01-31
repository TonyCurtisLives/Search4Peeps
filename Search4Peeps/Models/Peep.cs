using System.ComponentModel.DataAnnotations;

namespace Search4Peeps.Models
{
    public class Peep
    {
        public int PeepID { get; set; }
        public virtual Address Address { get; set; }
        public virtual Photo Photo { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
        public int Age { get; set; }

        [StringLength(1000)]
        public string Interests { get; set; }
        public bool HasShrubbery { get; set; }

        [StringLength(15)]
        public string FavoriteColor { get; set; }
        public int SwallowIQ { get; set; }
        [StringLength(15)]
        public string Nationality { get; set; }

    }
}