using Idw.MergeCustomers.Data;
using Idw.MergeCustomers.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace Idw.MergeCustomers.Bl
{
    public class IndividualBl
    {

        private IDaoIndividual dao;

        /// <summary>
        /// Cto class IndividualBl
        /// </summary>
        /// <param name="dao">Inyection dependence IDaoIndividual</param>
        public IndividualBl(IDaoIndividual dao)
        {
            this.dao = dao;
        }

        public ICollection<Individual> ListIndividuals()
        {
            try
            {
                return dao.ListAll();
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException("Error BusinessLogic", ex);
            }
        }

        /// <summary>
        /// Merge customers.
        /// </summary>
        /// <param name="dt">DataTable customers</param>
        /// <returns></returns>
        public void MergeCustomer(DataTable dt)
        {
            int idClient1 = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            int idClient2 = Convert.ToInt32(dt.Rows[1].ItemArray[0]);
            if (idClient1 == idClient2)
            {
                throw new BusinessException("Error: Equals Customers.");
            } else
            {

            }
        }
    }
}
