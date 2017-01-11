using System;
using Findit.DL.Entities.Base;

namespace Findit.DL.Entities
{
	public class Review : ApprovedEntity
	{
		public string ReviewText { get; set; }
		public short Rating { get; set; }

		public virtual Place Place { get; set; }
	}
}