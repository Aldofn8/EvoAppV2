using AutoMapper;
using Dapper;
using EvoApp.DTO;
using MySql.Data.MySqlClient;

namespace EvoApp.Services.MyView
{
    public class MyViewServiceRest : IMyViewServiceRest
    {
        private readonly MySQLConfiguration _connectionString;
        private readonly IMapper _mapper;
        public MyViewServiceRest(MySQLConfiguration connectionString, IMapper mapper)
        {
            _connectionString = connectionString;
            _mapper = mapper;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<MyViewDto> GetMyViewById(int id)
        {
            MyViewDto response = new MyViewDto();
            try
            {
                var db = dbConnection();

                var sql = @" SELECT *
                        FROM myView
                        WHERE ContractId = @id";

                var srvResponse = await db.QueryFirstOrDefaultAsync<MyViewDto>(sql, new { id = id });
                response = _mapper.Map<MyViewDto>(srvResponse);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return response;
        }

    }
}
