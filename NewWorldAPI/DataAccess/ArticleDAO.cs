using MongoDB.Driver;
using NewWorldAPI.Configuration;
using NewWorldAPI.Models;
using System.Linq;

namespace NewWorldAPI.DataAccess
{
    public class ArticleDAO
    {
        private readonly IMongoCollection<Article> _articles;

        public ArticleDAO(IArticleDatabaseSettings articleDatabaseSettings)
        {
            var client = new MongoClient(articleDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(articleDatabaseSettings.DatabaseName);
            _articles = database.GetCollection<Article>(articleDatabaseSettings.ArticleCollectionName);
        }

        public Article Get(string articleId)
        {
            return _articles.Find(article => article.Id == articleId).FirstOrDefault<Article>();
        }
    }
}
