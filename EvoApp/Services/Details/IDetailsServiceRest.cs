using EvoApp.DTO;

namespace EvoApp.Services.Details
{
    public interface IDetailsServiceRest
    {
        public Task<IEnumerable<DetailsDto>> GetDetails();
        public Task<DetailsDto> GetDetailById(int id);
    }
}
