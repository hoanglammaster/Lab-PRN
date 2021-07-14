using Lab2.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Dao
{
    public class CategoryContext
    {
        public static IEnumerable<Category> GetCategories()
        {
            var listCategory = new List<Category>();
            DataTable table = GetDataTableCategories();
            foreach (DataRow row in table.Rows)
            {
                var category = new Category(Convert.ToInt32(row["CategoryId"].ToString()), row["CategoryName"].ToString());
                listCategory.Add(category);
            }
            return listCategory.AsEnumerable<Category>();

        }
        public static DataTable GetDataTableCategories()
        {
            string query = "SELECT * FROM Categories";
            using (SqlConnection connection = DataAccess.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
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
}
