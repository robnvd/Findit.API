using System;

namespace Findit.DL.Entities.Base
{
    public class ApprovedEntity : BaseEntity
    {
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
    }

    public static class ApprovedEntityExtensions
    {
        public static void Approve(this ApprovedEntity entity, string approvedBy)
        {
            entity.ApprovedBy = approvedBy;
            entity.ApprovedOn = DateTime.UtcNow;
            entity.IsApproved = true;
        }
    }
}