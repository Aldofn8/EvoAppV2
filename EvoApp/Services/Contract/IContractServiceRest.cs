using EvoApp.DTO;

namespace EvoApp.Services.Contract
{
    public interface IContractServiceRest
    {
        public Task<IEnumerable<ContractDto>> GetContract();
        public Task<ContractDto> GetContractById(int id);
    }
}
