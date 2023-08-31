using EvoApp.DTO;

namespace EvoApp.Services.Articles
{
    public interface IArticlesServiceRest
    {
        public Task<IEnumerable<ArticlesDto>> GetArticles();
        public Task<ArticlesDto> GetArticleById(int id);
    }
}
