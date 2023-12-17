using sqlapp.Models;
using System.Data.SqlClient;

namespace sqlapp.Service
{
    public class ProductService
    {

        private static string db_source = "appserver200.database.windows.net";
        private static string db_user = "sqlusr";
        private static string db_password = "PR1M4V3R42023..";
        private static string db_database = "appdb";

        private SqlConnection getConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);

        }

        public List<Products> GetProducts()
        {
            SqlConnection _conn = getConnection();
            List<Products> productos = new List<Products>();
            String QUERY_STATEMENT = "SELECT * FROM PRODUCTS";
            _conn.Open();
            SqlCommand command = new SqlCommand(QUERY_STATEMENT, _conn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                productos.Add(new Products()
                {
                    ProductID = dataReader.GetInt32(0),
                    ProductName = dataReader.GetString(1),
                    Quantity = dataReader.GetInt32(2),
                });
            }
            _conn.Close();
            return productos;

        }

    }
}
