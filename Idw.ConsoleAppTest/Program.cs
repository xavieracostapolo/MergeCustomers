using Idw.MergeCustomers.Bl;
using Idw.MergeCustomers.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idw.ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string conn = ConfigurationManager.AppSettings["stringConnection"];

            IndividualBl bl = new IndividualBl(conn);

            foreach (Individual p in bl.ListIndividuals())
            {
                Console.WriteLine(p.FirstName);
            }

            Console.ReadLine();
        }
    }
}
