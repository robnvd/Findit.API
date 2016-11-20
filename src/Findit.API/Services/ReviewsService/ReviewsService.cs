using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Findit.API.Configuration;
using Findit.API.Core;
using Findit.DL.Entities;
using Findit.DL.Entities.Base;
using Findit.DL.Repositories;
using Findit.DTO;
using Findit.DTO.Base;
using Microsoft.Extensions.Options;

namespace Findit.API
{
	public class ReviewsService : BaseService, IReviewsService
	{
		private readonly ReviewsRepository _reviewsRepository;

		public ReviewsService(IOptions<DatabaseSettings> databaseSettings, IMapper mapper) : base(mapper)
		{
			_reviewsRepository = new ReviewsRepository(databaseSettings.Value.ConnectionString);
		}

		public IEnumerable<ReviewDto> GetReviewsByUser(string username)
		{
			var entities = _reviewsRepository.GetReviewsByUser(username);
			var dtos = entities.Select(x => Mapper.Map<ReviewDto>(x));
			return dtos;
		}

		public ReviewDto GetReviewById(string id)
		{
			var entity = _reviewsRepository.Get(id);
			return Mapper.Map<ReviewDto>(entity);
		}

		public ReviewDto AddReview(string username, ReviewDto review)
		{
			//review.Defaults(username);
			//review.Place.string = string.Newstring();

			//TODO check if user is moderator
			review.Approve(username);
			var entity = Mapper.Map<Review>(review);
			_reviewsRepository.Insert(entity);
			return Mapper.Map<ReviewDto>(entity);
		}

		public void RemoveReview(string username, ReviewDto review)
		{
			//TODO Check for permissions
			_reviewsRepository.Delete(ent => ent.Id.Equals(review.Id));
		}

		public void ApproveReview(string username, ReviewDto review)
		{
			//TODO check for permissions
			var entity = _reviewsRepository.Get(review.Id);
			entity.Approve(username);
			_reviewsRepository.Update(entity);
		}

		public IEnumerable<ReviewDto> GetReviewsByPlace(string placeId)
		{
			var entities = _reviewsRepository.GetReviewsByPlace(placeId);
			var dtos = entities.Select(x => Mapper.Map<ReviewDto>(x));
			return dtos;
		}
	}
}
