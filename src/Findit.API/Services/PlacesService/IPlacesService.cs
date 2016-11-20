using System;
using Findit.DTO;

namespace Findit.API
{
	public interface IPlacesService
	{
		void UpdateCachedPlace(PlaceDto place);
	}
}