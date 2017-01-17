using Findit.API.Core;
using Findit.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Findit.API
{
	public class PlacesController : BaseController
	{
		private readonly IPlacesService _placesService;

		public PlacesController(IPlacesService placesService)
		{
			_placesService = placesService;
		}

		[HttpPut]
        [Route("UpdateCachedPlace")]
		public IActionResult UpdateCachedPlace([FromBody] PlaceDto place)
		{
			_placesService.UpdateCachedPlace(place);
			return Ok();
		}
	}
}
