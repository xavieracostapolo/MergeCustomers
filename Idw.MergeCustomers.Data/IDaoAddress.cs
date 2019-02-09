using Idw.MergeCustomers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idw.MergeCustomers.Data
{
    public interface IDaoAddress
    {
        void UpdateAddressByCustomer(int idClientSource, int idClientDelete);
    }
}
