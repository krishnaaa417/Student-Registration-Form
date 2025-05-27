using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;

namespace StudentFormWithADO.NET.Data
{
    public class Helper
    {
        private readonly IConfiguration _configuration;
        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

    }
}
