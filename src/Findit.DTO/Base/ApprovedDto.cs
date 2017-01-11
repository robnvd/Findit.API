using System;

namespace Findit.DTO.Base
{
	public class ApprovedDto : Dto
	{
		public bool IsApproved { get; set; }
		public string ApprovedBy { get; set; }
		public DateTime? ApprovedOn { get; set; }
	}

	public static class ApprovedDtoExtensions
	{
		public static void Approve(this ApprovedDto dto, string approvedBy)
		{
			dto.ApprovedBy = approvedBy;
			dto.ApprovedOn = DateTime.UtcNow;
			dto.IsApproved = true;
			dto.AuditUpdate(approvedBy);
		}
	}
}