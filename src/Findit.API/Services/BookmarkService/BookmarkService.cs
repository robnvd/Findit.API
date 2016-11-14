using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Findit.API.Configuration;
using Findit.DL.Repositories;
using Findit.DTO;
using Microsoft.Extensions.Options;

namespace Findit.API.Services.BookmarkService
{
    public class BookmarkService : BaseService, IBookmarkService
    {
        private readonly BookmarksesRepository _bookmarksesRepository;

        public BookmarkService(IOptions<DatabaseSettings> databaseSettings, IMapper mapper) : base(mapper)
        {
            _bookmarksesRepository = new BookmarksesRepository(databaseSettings.Value.ConnectionString);
        }
        public IEnumerable<BookmarkDto> GetBookmarksByUser(string username)
        {
            var entities = _bookmarksesRepository.GetBookmarksByUser(username);
            var bookmarks = entities.Select(x => Mapper.Map<BookmarkDto>(x));
            return bookmarks;
        }

        public BookmarkDto GetBookmarkById(string id)
        {
            var entity = _bookmarksesRepository.Get(id);
            var dto = Mapper.Map<BookmarkDto>(entity);
            return dto;
        }

        public BookmarkDto GetBookmarkByUsernameAndPlaceId(string username, string placeId)
        {
            var entity = _bookmarksesRepository.GetBookmarkByUsernameAndPlaceId(username, placeId);
            var dto = Mapper.Map<BookmarkDto>(entity);
            return dto;
        }

        public void AddBookmark(string username, BookmarkDto bookmark)
        {
            bookmark.defaults
            _bookmarksesRepository.
        }

        public void RemoveBookmark(string username, string placeId)
        {
            throw new System.NotImplementedException();
        }
    }
}