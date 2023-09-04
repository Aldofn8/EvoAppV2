using EvoApp.DTO;

namespace EvoApp.Services.MyArticleList
{
    public interface IMyArticleListServiceRest
    {
        public Task<IEnumerable<MyArticleListDto>> GetMyArticleListById(int id);
    }
}
