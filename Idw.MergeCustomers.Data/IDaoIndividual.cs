using Idw.MergeCustomers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idw.MergeCustomers.Data
{
    public interface IDaoIndividual
    {
        /// <summary>
        /// List all individuals.
        /// </summary>
        /// <returns>Collection Individual</returns>
        ICollection<Individual> ListAll();

        /// <summary>
        /// Get Individual By Id.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password</param>
        /// <returns>Return object Individual.</returns>
        Individual GetIndividual(string username, string password);
    }
}
