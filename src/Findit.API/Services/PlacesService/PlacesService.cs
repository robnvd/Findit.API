using AutoMapper;
using Findit.API.Configuration;
using Findit.API.Core;
using Findit.DL.Entities;
using Findit.DL.Repositories;
using Findit.DTO;
using Microsoft.Extensions.Options;

namespace Findit.API
{
    public class PlacesService : BaseService, IPlacesService
	{
		private readonly PlacesRepository _placesRepository;

		public PlacesService(IOptions<DatabaseSettings> databaseSettings, IMapper mapper) : base(mapper)
		{
			_placesRepository = new PlacesRepository(databaseSettings.Value.ConnectionString);
		}

		public void UpdateCachedPlace(PlaceDto place)
		{
			var entity = Mapper.Map<Place>(place);
			//TODO investigate Update specific fields
			_placesRepository.Replace(entity);
		}
	}
}
