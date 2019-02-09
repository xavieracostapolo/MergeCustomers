using Microsoft.VisualStudio.TestTools.UnitTesting;
using Idw.MergeCustomers.Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idw.MergeCustomers.Data;
using Moq;
using Idw.MergeCustomers.Entities;
using System.Collections.ObjectModel;
using System.Data;

namespace Idw.MergeCustomers.Bl.Tests
{
    [TestClass()]
    public class IndividualBlTests
    {
        [TestMethod()]
        public void ListIndividualsTest()
        {
            var moqDaoIndividual = new Mock<IDaoIndividual>();
            var moqDaoAddress = new Mock<IDaoAddress>();

            moqDaoIndividual.Setup(f => f.ListAll()).Returns(new Collection<Individual>());

            IndividualBl bl = new IndividualBl(moqDaoIndividual.Object, moqDaoAddress.Object);

            Assert.AreNotEqual(bl.ListIndividuals(), null);
        }

        [TestMethod()]
        public void MergeCustomerTest()
        {
            var exceptionThrow = false;
            int idClientSource = 1;
            int idClientDelete = 2;
            DataTable dtMerge = new DataTable();
            dtMerge.Columns.Add("Id");
            dtMerge.Columns.Add("FirstName");
            dtMerge.Columns.Add("LastName");

            DataRow drow1 = dtMerge.NewRow();
            drow1["Id"] = "1";
            drow1["FirstName"] = "First Name Test 1";
            drow1["LastName"] = "Last Name Test 1";
            dtMerge.Rows.Add(drow1);

            DataRow drow2 = dtMerge.NewRow();
            drow2["Id"] = "2";
            drow2["FirstName"] = "First Name Test 2";
            drow2["LastName"] = "Last Name Test 2";
            dtMerge.Rows.Add(drow2);

            var moqDaoIndividual = new Mock<IDaoIndividual>();
            var moqDaoAddress = new Mock<IDaoAddress>();
            
            moqDaoAddress.Setup(x => x.UpdateAddressByCustomer(idClientSource, idClientDelete));

            IndividualBl bl = new IndividualBl(moqDaoIndividual.Object, moqDaoAddress.Object);

            try
            {
                bl.MergeCustomer(dtMerge);
            }
            catch (DataAccessException)
            {
                exceptionThrow = true;
            }

            Assert.IsFalse(exceptionThrow);
        }
    }
}