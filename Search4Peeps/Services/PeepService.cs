using System.Collections.Generic;
using System.Linq;
using Search4Peeps.Models;
using Search4Peeps.DAL;
using System.Data.Entity;

namespace Search4Peeps.Services
{
    public class PeepService : IPeepService
    {
        private MontyPeepsContext montyPeepsContext;

        public PeepService(MontyPeepsContext db)
        {
            montyPeepsContext = db;
        }

        public IList<Peep> GetPeeps(string searchTerm)
        {
            return montyPeepsContext.Peeps
                .Include(p => p.Address).Include(p => p.Photo)
                .Where(p => p.FirstName.Contains(searchTerm)
                || p.MiddleName.Contains(searchTerm)
                || p.LastName.Contains(searchTerm))
                .ToList();
        }

        public byte[] GetPhoto(int id)
        {
            return montyPeepsContext.Photos.Find(id).Image;
        }
    }
}