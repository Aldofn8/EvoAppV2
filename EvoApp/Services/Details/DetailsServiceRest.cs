using AutoMapper;
using Dapper;
using EvoApp.DTO;
using MySql.Data.MySqlClient;

namespace EvoApp.Services.Details
{
    public class DetailsServiceRest : IDetailsServiceRest
    {
        private readonly MySQLConfiguration _connectionString;
        private readonly IMapper _mapper;
        public DetailsServiceRest(MySQLConfiguration connectionString, IMapper mapper)
        {
            _connectionString = connectionString;
            _mapper = mapper;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<DetailsDto> GetDetailById(int id)
        {
            DetailsDto response = new DetailsDto();
            try
            {
                var db = dbConnection();

                var sql = @" SELECT id, ContractId, ArticleId, CreateDate, UpdateDate, Enabled, Deleted, CreatedBy
                        FROM details
                        WHERE id = @id";

                var srvResponse = await db.QueryFirstOrDefaultAsync<DetailsDto>(sql, new { id = id });
                response = _mapper.Map<DetailsDto>(srvResponse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return response;
        }

        public async Task<IEnumerable<DetailsDto>> GetDetails()
        {
            IEnumerable<DetailsDto> response = new List<DetailsDto>();
            try
            {
                var db = dbConnection();

                var sql = @" SELECT *
                        FROM details";

                var srvResponse = await db.QueryAsync<DetailsDto>(sql, new { });
                response = _mapper.Map<List<DetailsDto>>(srvResponse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return response;
        }
    }
}
