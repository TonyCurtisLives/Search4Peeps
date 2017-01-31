using Search4Peeps.Models;
using System.Collections.Generic;

namespace Search4Peeps.Services
{
    public interface IPeepService
    {
        IList<Peep> GetPeeps(string searchTerm);
        byte[] GetPhoto(int ID);
    }
}