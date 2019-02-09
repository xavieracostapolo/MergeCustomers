using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idw.MergeCustomers.Entities;
using MySql.Data.MySqlClient;

namespace Idw.MergeCustomers.Data
{
    public class DaoIndividual
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        private string stringConn;

        public DaoIndividual(string stringConn)
        {
            this.stringConn = stringConn;
        }

        /// <summary>
        /// Lists all.
        /// </summary>
        /// <returns>The all.</returns>
        public ICollection<Individual> ListAll()
        {
            ICollection<Individual> listIndividuals = new Collection<Individual>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(stringConn))
                {

                    con.Open();
                    using (var command = con.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;

                        command.CommandText = $"SELECT `RecordNumber`, `FirstName`, `LastName`, `Gender`, `Username`, " +
                            $"`Password` FROM `individual`";

                        MySqlDataReader res = command.ExecuteReader();

                        while (res.Read())
                        {
                            Individual obj = new Individual();

                            obj.RecordNumber = (int)res["RecordNumber"];
                            obj.FirstName = (string)res["FirstName"];
                            obj.LastName = (string)res["LastName"];
                            obj.Gender = (string)res["Gender"];
                            obj.Username = (string)res["Username"];
                            obj.Password = (string)res["Password"];

                            listIndividuals.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Error DataAccess", ex);
            }

            return listIndividuals;
        }
    }
}
