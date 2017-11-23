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
                Console.WriteLine("Succes Database connection");
                DataTable dataTable = DataBaseOperator.ReadDB(Albums.ReturnDataTableView());
                Console.WriteLine("Succes Data injection");
                Console.WriteLine("Extracting data:");
                Albums albums = new Albums(dataTable);
                XMLConector.WriteXML(albums, "TestoweAlbumy");
                Albums albums1 = XMLConector.ReadXML<Albums>("TestoweAlbumy");
                foreach(Album a in albums1.Album)
                {
                    Console.WriteLine(a.ToString());
                }

            }
            Console.ReadLine();
        }
    }
}
