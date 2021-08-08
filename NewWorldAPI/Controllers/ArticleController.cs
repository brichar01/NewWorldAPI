using Microsoft.AspNetCore.Mvc;
using NewWorldAPI.Models;
using NewWorldAPI.DataAccess;

namespace NewWorldAPI.Controllers
{
    [ApiController]
    [Route("article")]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleDAO _articleDAO;

        public ArticleController(ArticleDAO articleDAO)
        {
            _articleDAO = articleDAO;
        }

        [HttpGet]
        [Route("{articleId}")]
        [Produces("application/json")]
        public Article Get(string articleId) =>
             _articleDAO.Get(articleId);
    }
}