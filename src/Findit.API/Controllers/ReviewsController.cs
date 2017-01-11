using System;
using Findit.API.Core;
using Findit.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace Findit.API
{
	public class ReviewsController : BaseController
	{
		private readonly IReviewsService _reviewsService;

		public ReviewsController(IReviewsService reviewsService)
		{
			_reviewsService = reviewsService;
		}

		// GET: api/Reviews/MyReviews
		[HttpGet]
		[Route("MyReviews")]
		public IActionResult MyReviews()
		{
			var dtos = _reviewsService.GetReviewsByUser(User.Identity.GetClaim("name"));
			return Ok(dtos);
		}

		// GET: api/Reviews/PlaceReviews/:placeId
		[AllowAnonymous]
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
			var newReview = _reviewsService.AddReview(User.Identity.GetClaim("name"), review);
			return Ok(newReview);
		}

		// DELETE: api/Reviews/RemoveReview
		[HttpDelete]
		[Route("RemoveReview")]
		public IActionResult RemoveReview([FromBody]ReviewDto review)
		{
			_reviewsService.RemoveReview(User.Identity.GetClaim("name"), review);
			return Ok();
		}

		// POST: api/Reviews/RemoveReview
		[HttpPost]
		[Route("ApproveReview")]
		public IActionResult ApproveReview([FromBody] ReviewDto review)
		{
			_reviewsService.ApproveReview(User.Identity.GetClaim("name"), review);
			return Ok();
		}
	}
}
