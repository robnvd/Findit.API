using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Findit.DL.Entities.Base
{
	/// <summary>
	/// mongo entity
	/// </summary>
	[BsonIgnoreExtraElements(Inherited = true)]
	public class BaseEntity : IBaseEntity
	{
		public BaseEntity()
		{
			//Id = ObjectId.GenerateNewId().ToString();
		}

		/// <summary>
		/// id in string format
		/// </summary>
		[BsonElement("_id", Order = 0)]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		/// <summary>
		/// id in objectId format
		/// </summary>
		public ObjectId ObjectId
		{
			get
			{
				//Incase, this is required if db record is null
				if (Id == null)
					Id = ObjectId.GenerateNewId().ToString();
				return ObjectId.Parse(Id);
			}
		}

		/// <summary>
		/// create date
		/// </summary>
		public DateTime CreatedOn => ObjectId.CreationTime;

		/// <summary>
		/// who created the record
		/// </summary>
		public string CreatedBy { get; set; }

		/// <summary>
		/// modify date
		/// </summary>
		[BsonElement("_m", Order = 1)]
		[BsonRepresentation(BsonType.DateTime)]
		public DateTime ModifiedOn { get; set; }

		/// <summary>
		/// modified by
		/// </summary>
		public string ModifiedBy { get; set; }


	}
}