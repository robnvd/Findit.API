using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Findit.DL.Entities.Base
{
    /// <summary>
    /// mongo entity interface
    /// </summary>
    public interface IBaseEntity
    {

        /// <summary>
        /// id in string format
        /// </summary>
        [BsonId]
        string Id { get; set; }
        

        /// <summary>
        /// id in objectId format
        /// </summary>
        [BsonIgnore]
        ObjectId ObjectId { get; }

        /// <summary>
        /// who created the record
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// create date
        /// </summary>
        [BsonIgnore]
        DateTime CreatedOn { get; }


        /// <summary>
        /// modify date
        /// </summary>
        DateTime ModifiedOn { get; }

        /// <summary>
        /// modified by
        /// </summary>
        string ModifiedBy { get; set; }
    }
}