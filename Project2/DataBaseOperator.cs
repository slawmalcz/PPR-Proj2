using System;
using System.Collections.Generic;
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

        private DataBaseOperator()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
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
    }
}
