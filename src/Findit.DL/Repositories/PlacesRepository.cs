using Findit.DL.Entities;
using Findit.DL.GenericRepository;

namespace Findit.DL.Repositories
{
    public class PlacesRepository : Repository<Place>
    {
        public PlacesRepository(string connectionString) : base(connectionString) { }
    }
}