using AutoMapper;
using Dapper;
using EvoApp.DTO;
using MySql.Data.MySqlClient;

namespace EvoApp.Services.Contract
{
    public class ContractServiceRest : IContractServiceRest
    {

        private readonly MySQLConfiguration _connectionString;
        private readonly IMapper _mapper;
        public ContractServiceRest(MySQLConfiguration connectionString, IMapper mapper)
        {
            _connectionString = connectionString;
            _mapper = mapper;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<ContractDto>> GetContract()
        {
            IEnumerable<ContractDto> response = new List<ContractDto>();
            try
            {
                var db = dbConnection();

                var sql = @" SELECT *
                        FROM contract";

                var srvResponse = await db.QueryAsync<ContractDto>(sql, new { });
                response = _mapper.Map<List<ContractDto>>(srvResponse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return response;
        }

        public async Task<ContractDto> GetContractById(int id)
        {
            ContractDto response = new ContractDto();
            try
            {
                var db = dbConnection();

                var sql = @" SELECT id, CourseCode, FechaAlta, Estado, CantidadEgresados, FechaEntrega, MedioEntrega, Vendedor, ColegioNivel, ColegioNombre, ColegioCurso, ColegioLocalidad, Comision, Total
                        FROM contract
                        WHERE id = @id";

                var srvResponse = await db.QueryFirstOrDefaultAsync<ContractDto>(sql, new { id = id });
                response = _mapper.Map<ContractDto>(srvResponse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return response;
        }
    }
}
