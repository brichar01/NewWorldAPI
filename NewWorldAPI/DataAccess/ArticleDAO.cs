using MongoDB.Driver;
using NewWorldAPI.Configuration;
using NewWorldAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace NewWorldAPI.DataAccess
{
    public class ArticleDAO
    {
        private readonly IMongoCollection<Article> _articles;

        public ArticleDAO(IArticleDatabaseSettings articleDatabaseSettings)
        {
            var cert = new X509Certificate2(articleDatabaseSettings.ConnectionCertificate,
                                            articleDatabaseSettings.ConnectionPassword);
            var settings = MongoClientSettings.FromConnectionString(articleDatabaseSettings.ConnectionString);
            settings.SslSettings = new SslSettings { ClientCertificates = new List<X509Certificate>() { cert } };

            var client = new MongoClient(settings);
            var database = client.GetDatabase(articleDatabaseSettings.DatabaseName);
            _articles = database.GetCollection<Article>(articleDatabaseSettings.ArticleCollectionName);
        }

        public Article Get(string articleId)
        {
            return _articles.Find(article => article.Id == articleId).FirstOrDefault<Article>();
        }
    }
}