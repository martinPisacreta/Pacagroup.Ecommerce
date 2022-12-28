using Microsoft.Extensions.Configuration;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Data;
using System.Data.SqlClient;

namespace Pacagroup.Ecommerce.Infraestructura.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration; //IConfiguration me permite acceder a las propiedades de otros proyectos

        //Se aplica en el constructor Inyeccion de dependencias
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null) return null;

                sqlConnection.ConnectionString = _configuration.GetConnectionString("NorthwindConnection");
                sqlConnection.Open();
                return sqlConnection;

            }
        }
    }
}
