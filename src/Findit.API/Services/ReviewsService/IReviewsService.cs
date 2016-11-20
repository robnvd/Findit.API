using System;
using System.Collections.Generic;
using Findit.DTO;

namespace Findit.API
{
	public interface IReviewsService
	{
		IEnumerable<ReviewDto> GetReviewsByUser(string username);
		ReviewDto GetReviewById(string id);
		ReviewDto AddReview(string username, ReviewDto review);
		void RemoveReview(string username, ReviewDto review);
		void ApproveReview(string username, ReviewDto review);
		IEnumerable<ReviewDto> GetReviewsByPlace(string placeId);
	}
}
