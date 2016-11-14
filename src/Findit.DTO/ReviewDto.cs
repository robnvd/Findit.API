using System;
using Findit.DTO.Base;

namespace Findit.DTO
{
    public class ReviewDto : ApprovedDto
    {
        public Guid PlaceGuid { get; set; }
        public string PlaceId { get; set; }

        public string ReviewText { get; set; }
        public short Rating { get; set; }

        public virtual PlaceDto Place { get; set; }
    }
}