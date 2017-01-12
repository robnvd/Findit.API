using System;
using Findit.DTO.Base;

namespace Findit.DTO
{
	public class BookmarkDto : Dto
	{
		public string PlaceId { get; set; }

		public string BookmarkText { get; set; }

		public PlaceDto Place { get; set; }
	}
}