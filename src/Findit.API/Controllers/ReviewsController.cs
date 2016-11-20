using System;
using Findit.API.Core;
using Findit.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Findit.API
{
	public class ReviewsController : BaseController
	{
		private readonly IReviewsService _reviewsService;

		public ReviewsController(IReviewsService reviewsService)
		{
			_reviewsService = reviewsService;
		}

		// GET: api/Reviews/MyReviews/:username
		[HttpGet]
		[Route("MyReviews/{username}")]
		public IActionResult MyReviews(string username)
		{
			if (User.Identity.Name.Equals(username))
			{
				var dtos = _reviewsService.GetReviewsByUser(username);
				return Ok(dtos);
			}
			return Unauthorized();
		}

		// GET: api/Reviews/PlaceReviews/:placeId
		[HttpGet]
		[Route("PlaceReviews/{placeId}")]
		public IActionResult PlaceReviews(string placeId)
		{
			var dtos = _reviewsService.GetReviewsByPlace(placeId);
			return Ok(dtos);
		}

		// GET: api/Reviews/:id
		[HttpGet]
		[Route("{id}")]
		public IActionResult Get(string id)
		{
			var dto = _reviewsService.GetReviewById(id);
			return Ok(dto);
		}

		// POST: api/Reviews/AddReview
		[HttpPost]
		[Route("AddReview")]
		public IActionResult AddReview([FromBody]ReviewDto review)
		{
			var newReview = _reviewsService.AddReview(User.Identity.Name, review);
			return Ok(newReview);
		}

		// DELETE: api/Reviews/RemoveReview
		[HttpDelete]
		[Route("RemoveReview")]
		public IActionResult RemoveReview([FromBody]ReviewDto review)
		{
			_reviewsService.RemoveReview(User.Identity.Name, review);
			return Ok();
		}

		// POST: api/Reviews/RemoveReview
		[HttpPost]
		[Route("ApproveReview")]
		public IActionResult ApproveReview([FromBody] ReviewDto review)
		{
			_reviewsService.ApproveReview(User.Identity.Name, review);
			return Ok();
		}
	}
}
