using EvoApp.Services.Articles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticlesServiceRest _articlesService;

        public ArticlesController(IArticlesServiceRest articlesServiceRest)
        {
            _articlesService = articlesServiceRest;
        }

        [HttpGet]
        public async Task<ActionResult> GetArticles()
        {
            return Ok(await _articlesService.GetArticles());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetArticleById(int id)
        {
            return Ok(await _articlesService.GetArticleById(id));
        }
    }
}
