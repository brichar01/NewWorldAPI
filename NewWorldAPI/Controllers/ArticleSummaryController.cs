using Microsoft.AspNetCore.Mvc;
using NewWorldAPI.DataAccess;
using NewWorldAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWorldAPI.Controllers
{
    [Route("article-summaries")]
    public class ArticleSummaryProvider : ControllerBase
    {
        private readonly ArticleDAO _articleDAO;

        public ArticleSummaryProvider(ArticleDAO articleDAO)
        {
            _articleDAO = articleDAO;
        }

        [HttpGet]
        [Produces("application/json")]
        public List<ArticleSummary> Get([FromQuery] int pageNum, [FromQuery] int pageSize) =>
             _articleDAO.GetArticleSummaries(pageNum, pageSize);
    }
}
