using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Search4Peeps.Models
{
    public class Photo
    {
        [Key, ForeignKey("Peep")] // must be at the top of the list
        public int PhotoID { get; set; }
        public virtual Peep Peep { get; set; }
        public byte[] Image { get; set; }
    }
}