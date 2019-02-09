using Idw.MergeCustomers.Bl;
using Idw.MergeCustomers.Data;
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
            /// <summary>
            /// Variable access data
            /// </summary>
            DaoIndividual daoIndividual = new DaoIndividual(ConfigurationManager.AppSettings["stringConnection"]);

            Individual obj = daoIndividual.GetById(1);
            Console.WriteLine(obj.FirstName);

            Console.ReadLine();
        }
    }
}
