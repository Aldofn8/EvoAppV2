using AutoMapper;
using Dapper;
using EvoApp.DTO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace EvoApp.Services.Articles
{
    public class ArticlesServiceRest : IArticlesServiceRest
    {

        private readonly MySQLConfiguration _connectionString;
        private readonly IMapper _mapper;
        public ArticlesServiceRest(MySQLConfiguration connectionString, IMapper mapper)
        {
            _connectionString = connectionString;
            _mapper = mapper;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<ArticlesDto> GetArticleById(int id)
        {
            ArticlesDto response = new ArticlesDto();
            try
            {
                var db = dbConnection();

                var sql = @" SELECT id, Nombre, Precio
                        FROM articles
                        WHERE id = @id";

                var srvResponse = await db.QueryFirstOrDefaultAsync<ArticlesDto>(sql, new { id = id });
                response = _mapper.Map<ArticlesDto>(srvResponse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return response;
        }

        public async Task<IEnumerable<ArticlesDto>> GetArticles()
        {
            IEnumerable<ArticlesDto> response = new List<ArticlesDto>();
            try
            {
                var db = dbConnection();

                var sql = @" SELECT *
                        FROM articles";

                var srvResponse = await db.QueryAsync<ArticlesDto>(sql, new { });
                response = _mapper.Map<List<ArticlesDto>>(srvResponse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return response;
        }
    }
}
