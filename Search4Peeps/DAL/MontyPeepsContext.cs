using Search4Peeps.Models;
using System.Data.Entity;

namespace Search4Peeps.DAL
{
    public class MontyPeepsContext : DbContext
    {
        // virtual lets me moq these
        public virtual DbSet<Peep> Peeps { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    }
}