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
        public DateTime ModifiedOn { get; }

        /// <summary>
        /// modified by
        /// </summary>
        public string ModifiedBy{ get; set; }
    }
}