using Idw.MergeCustomers.Bl;
using Idw.MergeCustomers.Data;
using Idw.MergeCustomers.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Idw.MergeCustomers.Presentation
{
    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// Variable access data
        /// </summary>
        DaoIndividual daoIndividual = new DaoIndividual(ConfigurationManager.AppSettings["stringConnection"]);
        DaoAddress daoAddress = new DaoAddress(ConfigurationManager.AppSettings["stringConnection"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblMsg.Text = "Valid Credentials: Username = test, Password = test";
            }

            if (Request.IsAuthenticated)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
            IndividualBl bl = new IndividualBl(daoIndividual, daoAddress);

            try
            {
                Individual individual = bl.GetIndividual(Email.Text, Password.Text);

                if (individual.RecordNumber > 0)
                {
                    FormsAuthentication.RedirectFromLoginPage(Email.Text, false);
                }
                else
                {
                    lblMsg.Text = "Error in login";
                }
            }
            catch (Exception)
            {
                //Manager log application
                lblMsg.Text = "Error in login.";
            }
           
        }
    }
}