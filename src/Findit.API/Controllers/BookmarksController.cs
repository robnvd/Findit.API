using System;
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
		[Route("MyBookmarks/{username}")]
		public IActionResult Get(string username)
		{
			if (!User.Identity.Name.Equals(username)) return Unauthorized();
			var dtos = _bookmarkService.GetBookmarksByUser(username);
			return Ok(dtos);
		}

		// GET: api/Bookmarks/PlaceBookmark/username/placeId
		[HttpGet]
		[Route("PlaceBookmark/{username}/{placeId}")]
		public IActionResult PlaceBookmark(string username, string placeId)
		{
			if (!username.Equals(User.Identity.Name)) return Unauthorized();
			var dto = _bookmarkService.GetBookmarkByUsernameAndPlaceId(User.Identity.Name, placeId);
			return Ok(dto);
		}

		// POST: api/Bookmarks/AddBookmark
		[HttpPost]
		[Route("AddBookmark/{username}")]
		public IActionResult Post(string username, [FromBody]BookmarkDto bookmark)
		{
			if (!username.Equals(User.Identity.Name)) return Unauthorized();
			_bookmarkService.AddBookmark(User.Identity.Name, bookmark);
			return Ok();
		}

		// DELETE: api/Bookmarks/RemoveBookmark
		[HttpDelete]
		[Route("RemoveBookmark/{username}/{placeId}")]
		public IActionResult Delete(string username, string placeId)
		{
			if (!username.Equals(User.Identity.Name)) return Unauthorized();
			_bookmarkService.RemoveBookmark(User.Identity.Name, placeId);
			return Ok();
		}
	}
}
