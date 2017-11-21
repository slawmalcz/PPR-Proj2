using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class DataBaseOperator
    {
        public static String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mindi\Desktop\Studia\PRA\Project2\Project2\Music.mdf;Integrated Security=True";

        /// SINGLETON INstance

        private static DataBaseOperator instance;
        private SqlConnection conn;

        private DataBaseOperator()
        {
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
            }
        }

        public static DataBaseOperator Instance {
            get {
                if (instance == null)
                {
                    instance = new DataBaseOperator();
                }
                return instance;
            }
        }

        /// Queries 
        
        public DataTable QueriesNo1(String sqlQuerry)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            da.SelectCommand = new SqlCommand(sqlQuerry, new SqlConnection(connectionString));
            da.Fill(ds);
            dt = ds.Tables[0];

            return dt;
        }
    }
}
