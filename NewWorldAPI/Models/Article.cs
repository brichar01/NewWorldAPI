using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWorldAPI.Models
{
    public class Article : ArticleSummary
    {
        public string ArticleContent { get; set; }
    }
}
