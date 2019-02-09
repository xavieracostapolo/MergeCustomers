using Idw.MergeCustomers.Bl;
using Idw.MergeCustomers.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Idw.MergeCustomers.Presentation
{
    public partial class Merge : System.Web.UI.Page
    {
        private readonly string conn = ConfigurationManager.AppSettings["stringConnection"];

        protected void Page_Load(object sender, EventArgs e)
        {
            IndividualBl bl = new IndividualBl(conn);

            gvCustomers.DataSource = bl.ListIndividuals();
            gvCustomers.DataBind();

            foreach (Individual p in bl.ListIndividuals())
            {
                Console.WriteLine(p.FirstName);
            }
        }
    }
}