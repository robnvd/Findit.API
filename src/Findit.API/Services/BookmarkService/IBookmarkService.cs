using System.Collections.Generic;
using Findit.DTO;

namespace Findit.API.Services.BookmarkService
{
    public interface IBookmarkService
    {
        IEnumerable<BookmarkDto> GetBookmarksByUser(string username);
        BookmarkDto GetBookmarkById(string id);
        BookmarkDto GetBookmarkByUsernameAndPlaceId(string username, string placeId);
        void AddBookmark(string username, BookmarkDto bookmark);
        void UpdateBookmark(string username, BookmarkDto bookmark);
        void RemoveBookmark(string username, string placeId);
    }
}