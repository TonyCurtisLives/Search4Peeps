using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Search4Peeps.Models
{
    public class Address
    {
        [Key, ForeignKey("Peep")] // must be at the top of the list
        public int AddressID { get; set; }
        public virtual Peep Peep { get; set; }

        [StringLength(50)]
        public string Line1 { get; set; }

        [StringLength(50)]
        public string Line2 { get; set; }

        [StringLength(25)]
        public string City { get; set; }

        [StringLength(20)]
        public string StateOrProvince { get; set; }

        [StringLength(15)]
        public string PostalCode { get; set; }

        [StringLength(20)]
        public string Country { get; set; }
    }
}