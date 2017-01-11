using System;
using Findit.DL.Entities.Base;

namespace Findit.DL.Entities
{
	public class Bookmark : BaseEntity
	{
		public string BookmarkText { get; set; }

		public virtual Place Place { get; set; }
	}
}