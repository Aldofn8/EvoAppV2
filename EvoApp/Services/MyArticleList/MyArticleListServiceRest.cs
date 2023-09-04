using AutoMapper;
using Dapper;
using EvoApp.DTO;
using MySql.Data.MySqlClient;

namespace EvoApp.Services.MyArticleList
{
    public class MyArticleListServiceRest : IMyArticleListServiceRest
    {
        private readonly MySQLConfiguration _connectionString;
        private readonly IMapper _mapper;
        public MyArticleListServiceRest(MySQLConfiguration connectionString, IMapper mapper)
        {
            _connectionString = connectionString;
            _mapper = mapper;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<MyArticleListDto>> GetMyArticleListById(int id)
        {
            IEnumerable<MyArticleListDto> response = new List<MyArticleListDto>();
            try
            {
                var db = dbConnection();

                var sql = @" SELECT *
                        FROM MyArticleList
                        WHERE ContractId = @id";

                var srvResponse = await db.QueryAsync<MyArticleListDto>(sql, new { id = id });
                response = _mapper.Map<List<MyArticleListDto>>(srvResponse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return response;
        }
    }
}
