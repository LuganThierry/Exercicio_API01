using Dapper;
using Microsoft.Data.SqlClient;

namespace PW.Aula01Exer01.Repository
{
    public class ClienteRepository
    {
        private readonly IConfiguration _configuration;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cliente> GetClientes()
        {
            var query = "SELECT * FROM Cliente";

            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var conn = new SqlConnection(connectionString);

            return conn.Query<Cliente>(query).ToList();
        }
    }
}
