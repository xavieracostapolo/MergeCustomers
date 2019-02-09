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

        DaoIndividual dao;

        public IndividualBl(string stringConn)
        {
            this.dao = new DaoIndividual(stringConn);
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
