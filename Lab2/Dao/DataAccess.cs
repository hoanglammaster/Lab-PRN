using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Dao
{
    public class DataAccess
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source = localhost; Initial Catalog = Northwind; user = sa; password = 123");
           
            return connection;
        }
    }
}
