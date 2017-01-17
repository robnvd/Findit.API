using Findit.DL.Entities.Base;

namespace Findit.DL.Entities
{
    public class Place : BaseEntity
    {
        public string PlaceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
    }
}