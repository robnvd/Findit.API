using System.Collections.Generic;
using Findit.DL.Entities;
using Findit.DL.GenericRepository;

namespace Findit.DL.Repositories
{
	public class ReviewsRepository : Repository<Review>
	{
		public ReviewsRepository(string connectionString) : base(connectionString) { }

		public IEnumerable<Review> GetReviewsByUser(string username)
		{
			return Find(x => x.CreatedBy.Equals(username));
		}

		public IEnumerable<Review> GetReviewsByPlace(string placeId, bool approvedOnly = true)
		{
			return approvedOnly
				? Find(x => x.IsApproved && x.Place.PlaceId.Equals(placeId)) :
				Find(x => x.Place.PlaceId.Equals(placeId));
		}
	}
}