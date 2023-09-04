using EvoApp.Services.MyArticleList;
using EvoApp.Services.MyView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyArticleListController : ControllerBase
    {
        private readonly IMyArticleListServiceRest _myArticleListServiceRest;

        public MyArticleListController(IMyArticleListServiceRest myArticleListServiceRest)
        {
            _myArticleListServiceRest = myArticleListServiceRest;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetMyArticleListById(int id)
        {
            return Ok(await _myArticleListServiceRest.GetMyArticleListById(id));
        }
    }
}
