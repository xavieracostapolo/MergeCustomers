using Idw.MergeCustomers.Bl;
using Idw.MergeCustomers.Data;
using Idw.MergeCustomers.Entities;
using System;
using System.Collections;
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
        DaoAddress daoAddress = new DaoAddress(ConfigurationManager.AppSettings["stringConnection"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.FillGrid();
                GroupGridView(gvCustomers.Rows, 0, 4);
                this.CreateDataTable();
                lblMessage.Text = "No selected customers";
            }
        }

        protected void gvCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.FillGrid();
            gvCustomers.PageIndex = e.NewPageIndex;
            gvCustomers.DataBind();
            GroupGridView(gvCustomers.Rows, 0, 4);
        }

        /// <summary>
        /// Load data to GridView.
        /// </summary>
        private void FillGrid()
        {
            if (ViewState["dataGrid"] == null)
            {
                IndividualBl bl = new IndividualBl(daoIndividual, daoAddress);
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
                drow["Id"] = gvCustomers.Rows[gvr.RowIndex].Cells[0].Text;
                drow["FirstName"] = gvCustomers.Rows[gvr.RowIndex].Cells[1].Text;
                drow["LastName"] = gvCustomers.Rows[gvr.RowIndex].Cells[2].Text;
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
                    IndividualBl bl = new IndividualBl(daoIndividual, daoAddress);
                    bl.MergeCustomer(dtMerge);
                    ViewState["dataGrid"] = null;
                    this.CreateDataTable();
                    this.FillGrid();
                    GroupGridView(gvCustomers.Rows, 0, 4);
                }
                catch (BusinessException ex)
                {
                    lblMessage.Text = ex.Message;
                }
                
                
            }
        }

        /// <summary>
        /// Group rows view.
        /// </summary>
        /// <param name="gvrc">Grid view rows</param>
        /// <param name="startIndex">Start index column.</param>
        /// <param name="total">Totl column.</param>
        private void GroupGridView(GridViewRowCollection gvrc, int startIndex, int total)
        {
            if (gvrc.Count <= 0) return;
            if (total == 0) return;
            int i, count = 1;
            ArrayList lst = new ArrayList();
            lst.Add(gvrc[0]);
            var ctrl = gvrc[0].Cells[startIndex];
            for (i = 1; i < gvrc.Count; i++)
            {
                TableCell nextCell = gvrc[i].Cells[startIndex];
                if (ctrl.Text == nextCell.Text)
                {
                    count++;
                    nextCell.Visible = false;
                    lst.Add(gvrc[i]);
                }
                else
                {
                    if (count > 1)
                    {
                        ctrl.RowSpan = count;
                        GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
                    }
                    count = 1;
                    lst.Clear();
                    ctrl = gvrc[i].Cells[startIndex];
                    lst.Add(gvrc[i]);
                }
            }
            if (count > 1)
            {
                ctrl.RowSpan = count;
                GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
            }
            count = 1;
            lst.Clear();
        }
    }
}