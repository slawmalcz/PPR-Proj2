using Project2.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in program");
            Console.WriteLine("Do you want to try to connect to default dataBase");
            String test = Console.ReadLine();
            if (test.Equals("y"))
            {
                DataBaseOperator dataBaseOperator = DataBaseOperator.Instance;
                Console.WriteLine("Succes Database connection");
                DataTable dataTable = dataBaseOperator.QueriesNo1(@"SELECT * FROM Albums");
                Console.WriteLine("Succes Data injection");
                Console.WriteLine("Extracting data:");
                PrintData(dataTable);

            }
            Console.ReadLine();
        }

        private static void PrintData(DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                Albums albums = new Albums(dr);
                //Console.WriteLine(albums.ToString());
                //XMLConector.WriteXML(albums);
                XMLConector.ReadXML(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml");
            }
        }
    }
}
