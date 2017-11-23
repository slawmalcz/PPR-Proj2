using Project2.DataModels;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Project2
{
    class DataBaseOperator
    {
        public static String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mindi\Desktop\Studia\PRA\Project2\Project2\Music.mdf;Integrated Security=True";

        public static DataTable ReadDB(String ObjectView)
        {
            String sqlQuerry = @"SELECT * FROM " + ObjectView;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.SelectCommand = new SqlCommand(sqlQuerry, new SqlConnection(connectionString));
            da.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }

        public static void WriteTODB<T>(T dataModel) where T : IDataModels
        {
            String SQLPass = "INSERT INTO " + dataModel.ReturnDataTableDeffinition() + " VALUES ";
            SQLPass = SQLPass + dataModel.DataToDB();
            try
            {
                new SqlCommand(SQLPass, new SqlConnection(connectionString));
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
