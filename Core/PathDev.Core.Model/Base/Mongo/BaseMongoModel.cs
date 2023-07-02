using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Base.Mongo
{
    public class BaseMongoModel
    {
        /// <summary>
        /// Kaydın Durumu
        /// 1: Aktif
        /// 0: Pasif
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Oluşturma zamani
        /// </summary>
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Güncellenme zamani
        /// </summary>
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime EditedDate { get; set; }

        /// <summary>
        /// Güncelleyen Kişi
        /// </summary>
        public string EditedBy { get; set; }

        /// <summary>
        /// Ekleyen Kişi
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Primary Key
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
