using EvoApp.DTO;

namespace EvoApp.Services.MyView
{
    public interface IMyViewServiceRest
    {
        public Task<MyViewDto> GetMyViewById(int id);
    }
}
