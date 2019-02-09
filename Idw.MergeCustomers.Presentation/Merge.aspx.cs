using Idw.MergeCustomers.Bl;
using Idw.MergeCustomers.Data;
using Idw.MergeCustomers.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Idw.MergeCustomers.Presentation
{
    public partial class Merge : System.Web.UI.Page
    {
        /// <summary>
        /// Variable access data
        /// </summary>
        DaoIndividual daoIndividual = new DaoIndividual(ConfigurationManager.AppSettings["stringConnection"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.FillGrid();
                this.CreateDataTable();
                lblMessage.Text = "No selected customers";
            }
        }

        protected void gvCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.FillGrid();
            gvCustomers.PageIndex = e.NewPageIndex;
            gvCustomers.DataBind();
        }

        /// <summary>
        /// Load data to GridView.
        /// </summary>
        private void FillGrid()
        {
            if (ViewState["dataGrid"] == null)
            {
                IndividualBl bl = new IndividualBl(daoIndividual);
                ViewState["dataGrid"] = bl.ListIndividuals();
                gvCustomers.DataSource = ViewState["dataGrid"];
            }
            else
            {
                gvCustomers.DataSource = ViewState["dataGrid"];
            }
            gvCustomers.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            CreateDataTable();
        }

        /// <summary>
        /// Create Datatable merge customers.
        /// </summary>
        private void CreateDataTable()
        {
            DataTable dtMerge = new DataTable();
            dtMerge.Columns.Add("Id");
            dtMerge.Columns.Add("FirstName");
            dtMerge.Columns.Add("LastName");
            ViewState["gvMerge"] = dtMerge;
            gvMerge.DataSource = dtMerge;
            gvMerge.DataBind();
            lblMessage.Text = "No selected customers";
        }

        protected void btnMerge_Click(object sender, EventArgs e)
        {
            DataTable dtMerge = (DataTable)ViewState["gvMerge"];
            Button chk = (Button)sender;
            if (dtMerge.Rows.Count <= 1)
            {
                //Agregar filas a la tabla de merge
                GridViewRow gvr = (GridViewRow)chk.NamingContainer;
                DataRow drow = dtMerge.NewRow();
                drow["Id"] = gvCustomers.Rows[gvr.RowIndex].Cells[1].Text;
                drow["FirstName"] = gvCustomers.Rows[gvr.RowIndex].Cells[2].Text;
                drow["LastName"] = gvCustomers.Rows[gvr.RowIndex].Cells[3].Text;
                dtMerge.Rows.Add(drow);
                gvMerge.DataSource = dtMerge;
                gvMerge.DataBind();
                lblMessage.Text = string.Empty;
            }
        }

        protected void btnMerge_SendMerge(object sender, EventArgs e)
        {
            DataTable dtMerge = (DataTable)ViewState["gvMerge"];
            if (dtMerge.Rows.Count < 2)
            {
                lblMessage.Text = "Select two customers!";
            }
            else
            {
                lblMessage.Text = string.Empty;
                try
                {
                    IndividualBl bl = new IndividualBl(daoIndividual);
                    bl.MergeCustomer(dtMerge);
                }
                catch (BusinessException ex)
                {
                    lblMessage.Text = ex.Message;
                }
                
                
            }
        }
    }
}