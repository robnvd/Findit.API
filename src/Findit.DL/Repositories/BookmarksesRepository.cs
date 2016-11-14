using System.Collections.Generic;
using Findit.DL.Entities;
using Findit.DL.GenericRepository;

namespace Findit.DL.Repositories
{
    public class BookmarksesRepository : Repository<Bookmark>
    {

        public BookmarksesRepository(string connectionString) : base(connectionString) {}

        public IEnumerable<Bookmark> GetBookmarksByUser(string username)
        {
            return Find(x => x.CreatedBy.Equals(username));
            //GetMany(x => x.CreatedBy.Equals(username));
        }

        public Bookmark GetBookmarkByUsernameAndPlaceId(string username, string placeId)
        {
            return First(x => x.CreatedBy.Equals(username) && x.PlaceId.Equals(placeId));
            //GetFirst(x => x.CreatedBy.Equals(username) && x.PlaceId.Equals(placeId));
        }
    }
}