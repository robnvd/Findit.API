using System;
using Findit.DTO.Base;

namespace Findit.DTO
{
    public class BookmarkDto : Dto
    {
        public Guid PlaceGuid { get; set; }
        public string PlaceId { get; set; }

        public string BookmarkText { get; set; }

        public virtual PlaceDto Place { get; set; }
    }
}