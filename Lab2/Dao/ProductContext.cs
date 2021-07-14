using Lab2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Dao
{
    public class ProductContext
    {
        public static IEnumerable<Product> GetProducts(int categoryId)
        {
            var listProduct = new List<Product>();
            DataTable table = GetDataTableProducts(categoryId);
            foreach(DataRow row in table.Rows)
            {
                var product = new Product(Convert.ToInt32(row["ProductId"].ToString()), row["ProductName"].ToString(), Decimal.Parse(row["UnitPrice"].ToString()));
                listProduct.Add(product);
            }
            return listProduct.AsEnumerable<Product>();
        
        }
        public static DataTable GetDataTableProducts(int id)
        {
            string query = "SELECT * FROM Products WHERE CategoryId = @id";
            using(SqlConnection connection = DataAccess.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                return table;
            }
        }
    }
}
