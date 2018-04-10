using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Data.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        private readonly string _connectionString;

        public SqlProductDatabase ( string connectionString )
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            if (connectionString == "")
                throw new ArgumentException("Connection string cannot be empty.",
                                            nameof(connectionString));

            _connectionString = connectionString;
        }

        protected override Product AddCore( Product product )
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);

                var parm = cmd.CreateParameter();
                parm.ParameterName = "@isDiscontinued";
                parm.DbType = System.Data.DbType.Boolean;
                parm.Value = product.IsDiscontinued;
                cmd.Parameters.Add(parm);

                conn.Open();
                var result = cmd.ExecuteScalar();

                var id = Convert.ToInt32(result);
                product.Id = id;
            };

            return product;
        }

        protected override IEnumerable<Product> GetAllCore()
        {
            var items = new List<Product>();

            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("GetAllProducts", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
            };

            return items;
        }

        protected override Product GetCore( int id )
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("GetProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", id));

                conn.Open();
            };

            return null;
        }

        protected override Product GetProductByNameCore( string name )
        {
            throw new NotImplementedException();
        }

        protected override void RemoveCore( int id )
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("RemoveProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", id));

                conn.Open();
                cmd.ExecuteNonQuery();
            };
        }

        protected override Product UpdateCore( Product product )
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", product.Id));
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);

                var parm = cmd.CreateParameter();
                parm.ParameterName = "@isDiscontinued";
                parm.DbType = System.Data.DbType.Boolean;
                parm.Value = product.IsDiscontinued;
                cmd.Parameters.Add(parm);

                conn.Open();
                cmd.ExecuteNonQuery();
            };

            return product;
        }
    }
}
