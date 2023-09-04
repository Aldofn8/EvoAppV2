
using EvoApp.Services.MyView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyViewController : ControllerBase
    {
        private readonly IMyViewServiceRest _myViewServiceRest;

        public MyViewController(IMyViewServiceRest myViewServiceRest)
        {
            _myViewServiceRest = myViewServiceRest;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetMyViewById(int id)
        {
            return Ok(await _myViewServiceRest.GetMyViewById(id));
        }
    }
}
