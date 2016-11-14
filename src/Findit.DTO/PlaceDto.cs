using Findit.DTO.Base;

namespace Findit.DTO
{
    public class PlaceDto : Dto
    {
        public string PlaceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
    }
}