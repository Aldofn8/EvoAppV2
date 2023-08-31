using EvoApp.Services.Contract;
using EvoApp.Services.Details;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly IDetailsServiceRest _detailService;

        public DetailsController(IDetailsServiceRest detailService)
        {
            _detailService = detailService;
        }

        [HttpGet]
        public async Task<ActionResult> GetDetails()
        {
            return Ok(await _detailService.GetDetails());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDetailById(int id)
        {
            return Ok(await _detailService.GetDetailById(id));
        }
    }
}
