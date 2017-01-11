using System;

namespace Findit.DTO.Base
{
	public class Dto
	{
		/// <summary>
		/// id in string format
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// id in objectId format
		/// </summary>
		//ObjectId ObjectId { get; }

		/// <summary>
		/// When it was created
		/// </summary>
		public DateTime CreatedOn { get; }

		/// <summary>
		/// who created the record
		/// </summary>
		public string CreatedBy { get; set; }

		/// <summary>
		/// modify date
		/// </summary>
		public DateTime ModifiedOn { get; set; }

		/// <summary>
		/// modified by
		/// </summary>
		public string ModifiedBy { get; set; }
	}

	public static class DtoExtensions
	{
		public static void AuditCreate(this Dto dto, string createdBy)
		{
			dto.CreatedBy = createdBy;
		}

		public static void AuditUpdate(this Dto dto, string modifiedBy)
		{
			dto.ModifiedBy = modifiedBy;
			dto.ModifiedOn = DateTime.UtcNow;
		}
	}
}