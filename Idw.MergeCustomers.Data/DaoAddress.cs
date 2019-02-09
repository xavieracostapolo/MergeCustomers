using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idw.MergeCustomers.Entities;
using MySql.Data.MySqlClient;

namespace Idw.MergeCustomers.Data
{
    public class DaoAddress : IDaoAddress
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        private string stringConn;

        public DaoAddress(string stringConn)
        {
            this.stringConn = stringConn;
        }

        /// <summary>
        /// Merge customers.
        /// </summary>
        /// <param name="idClientSource">Client Source.</param>
        /// <param name="idClientDelete">Client Delete.</param>
        public void UpdateAddressByCustomer(int idClientSource, int idClientDelete)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(stringConn))
                {
                    con.Open();
                    MySqlTransaction trx = null;
                    trx = con.BeginTransaction();
                    try
                    {
                        using (var command = con.CreateCommand())
                        {
                            command.Transaction = trx;

                            command.CommandType = CommandType.Text;
                            command.CommandText = $"UPDATE individualaddress " +
                                $"SET RecordNumber= {idClientSource} WHERE RecordNumber = {idClientDelete} ";
                            command.ExecuteNonQuery();

                            command.CommandType = CommandType.Text;
                            command.CommandText = $"DELETE FROM individual WHERE RecordNumber = {idClientDelete}";
                            command.ExecuteNonQuery();

                        }

                        trx.Commit();
                    }
                    catch (Exception ex)
                    {
                        trx.Rollback();
                        throw new DataException("Error Merge Customers", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Error Merge Customers", ex);
            }
        }
    }
}
