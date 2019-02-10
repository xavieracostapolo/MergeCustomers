using Idw.MergeCustomers.Data;
using Idw.MergeCustomers.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace Idw.MergeCustomers.Bl
{
    public class IndividualBl
    {

        private IDaoIndividual daoIndividual;
        private IDaoAddress daoAddress;

        /// <summary>
        /// Cto class IndividualBl
        /// </summary>
        /// <param name="dao">Inyection dependence IDaoIndividual</param>
        public IndividualBl(IDaoIndividual daoIndividual, IDaoAddress daoAddress)
        {
            this.daoIndividual = daoIndividual;
            this.daoAddress = daoAddress;
        }

        /// <summary>
        /// Get Individual By Id.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password</param>
        /// <returns>Return object Individual.</returns>
        public Individual GetIndividual(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new BusinessException("Username not valid");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new BusinessException("Password not valid");
            }

            try
            {
                return daoIndividual.GetIndividual(username, password);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException("Error BusinessLogic", ex);
            }
        }

        /// <summary>
        /// List Individuals.
        /// </summary>
        /// <returns>Return collection individual.</returns>
        public ICollection<Individual> ListIndividuals()
        {
            try
            {
                return daoIndividual.ListAll();
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
            }
            else
            {
                try
                {
                    daoAddress.UpdateAddressByCustomer(idClient1, idClient2);  
                }
                catch (DataAccessException ex)
                {
                    throw new BusinessException("Error Business Logic Merge Customers", ex);
                }
            }
        }
    }
}
