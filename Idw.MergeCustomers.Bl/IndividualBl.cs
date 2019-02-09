using Idw.MergeCustomers.Data;
using Idw.MergeCustomers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            catch (DataException ex)
            {
                throw new BusinessException("Error BusinessLogic", ex);
            }
        }
    }
}
