using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWorldAPI.Configuration
{
    public class ArticleDatabaseSettings : IArticleDatabaseSettings
    {
        public string ArticleCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IArticleDatabaseSettings
    {
        string ArticleCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
