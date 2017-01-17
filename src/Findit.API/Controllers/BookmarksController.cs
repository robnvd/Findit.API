using Findit.API.Core;
using Findit.API.Services.BookmarkService;
using Findit.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Findit.API
{
    public class BookmarksController : BaseController
	{
		private readonly IBookmarkService _bookmarkService;

		public BookmarksController(IBookmarkService bookmakService)
		{
			_bookmarkService = bookmakService;
		}

		// GET: api/Bookmarks/MyBookmarks
		[HttpGet]
		[Route("MyBookmarks")]
		public IActionResult Get()
		{
			var dtos = _bookmarkService.GetBookmarksByUser(User.Identity.GetClaim("name"));
			return Ok(dtos);
		}

		// GET: api/Bookmarks/PlaceBookmark/placeId
		[HttpGet]
		[Route("PlaceBookmark/{placeId}")]
		public IActionResult PlaceBookmark(string placeId)
		{
			var dto = _bookmarkService.GetBookmarkByUsernameAndPlaceId(User.Identity.GetClaim("name"), placeId);
			return Ok(dto);
		}

		// POST: api/Bookmarks/AddBookmark
		[HttpPost]
		[Route("AddBookmark")]
		public IActionResult Post([FromBody]BookmarkDto bookmark)
		{
			_bookmarkService.AddBookmark(User.Identity.GetClaim("name"), bookmark);
			return Ok();
		}

		[HttpPut]
		[Route("UpdateBookmark")]
		public IActionResult Put([FromBody]BookmarkDto bookmark) 
		{
			_bookmarkService.UpdateBookmark(User.Identity.GetClaim("name"), bookmark);
			return Ok();
		}

		// DELETE: api/Bookmarks/RemoveBookmark/:placeId
		[HttpDelete]
		[Route("RemoveBookmark/{placeId}")]
		public IActionResult Delete(string placeId)
		{
			_bookmarkService.RemoveBookmark(User.Identity.GetClaim("name"), placeId);
			return Ok();
		}
	}
}
