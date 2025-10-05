using Dapper;
using Microsoft.Data.SqlClient;
using SearchEmployees.WebAPI.Entities;

namespace SearchEmployees.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;

        public UsuarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            var sql = "SELECT Id, Nome, Email, Cidade FROM Usuarios";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Usuario>(sql);
                return result;
            }
        }
    }
}
