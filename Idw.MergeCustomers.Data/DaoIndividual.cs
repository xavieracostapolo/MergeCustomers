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
    public class DaoIndividual : IDaoIndividual
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

                        command.CommandText = $"SELECT " +
                            $"i.RecordNumber, i.FirstName, i.LastName, i.Gender, a.AddressId, a.StreetName, a.City, a.State " +
                            $"FROM individual i " +
                            $"INNER JOIN individualaddress ia ON ia.RecordNumber = i.RecordNumber " +
                            $"INNER JOIN address a ON a.AddressId = ia.AddressId " +
                            $"WHERE 1";

                        MySqlDataReader res = command.ExecuteReader();

                        while (res.Read())
                        {
                            Individual obj = new Individual();

                            obj.RecordNumber = Convert.ToInt32(res["RecordNumber"]);
                            obj.FirstName = Convert.ToString(res["FirstName"]);
                            obj.LastName = Convert.ToString(res["LastName"]);
                            obj.Gender = Convert.ToString(res["Gender"]);
                            obj.AddressId = Convert.ToInt32(res["AddressId"]);
                            obj.StreetName = Convert.ToString(res["StreetName"]);
                            obj.City = Convert.ToString(res["City"]);
                            obj.State = Convert.ToString(res["State"]);

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
