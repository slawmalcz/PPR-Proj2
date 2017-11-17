using System;
using System.Collections.Generic;
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
                try
                {
                    DataBaseOperator dataBaseOperator =  DataBaseOperator.Instance;
                    Console.WriteLine("Succes");
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
