using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWorldAPI.Models
{
    public class Article
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("summary")]
        public string Summary { get; set; }
        [BsonElement("timestamp")]
        public DateTime TimeStamp { get; set; }
        [BsonElement("authorId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AuthorId { get; set; }
        [BsonElement("articleContent")]
        public string ArticleContent { get; set; }
    }
}
