using EvoApp.Services.Articles;
using EvoApp.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractServiceRest _contractService;

        public ContractController(IContractServiceRest contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public async Task<ActionResult> GetContract()
        {
            return Ok(await _contractService.GetContract());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetContractById(int id)
        {
            return Ok(await _contractService.GetContractById(id));
        }
    }
}
