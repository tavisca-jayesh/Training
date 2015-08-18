using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;
using EmployeeRemarkApp.Model;
using System.Net;

namespace CustomWidget
{
    public partial class ViewRemark : System.Web.UI.UserControl, IWidget
    {
        IWidgetHost Host = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Host.CurrentPageMode != PageMode.Design)
            {
                ViewRemarkPanel.Visible = true;
            }
            if (!IsPostBack)
            {
                if (Request.Cookies["Role"].Value != "EMP" || Request.Cookies["UserName"] == null || Request.Cookies["Password"] == null || Request.Cookies["Id"] == null)
                {
                    Response.Redirect("LoginPage");
                }
                LoadGridView(sender, e);
            }
        }

        public void HideSettings()
        {
            ViewRemarkPanel.Visible = false;
        }

        public new void Init(IWidgetHost host)
        {
            Host = host;
        }

        public void ShowSettings()
        {
            ViewRemarkPanel.Visible = true;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGridView(sender, e);
        }

        protected void LoadGridView(object sender, EventArgs e)
        {
            Remark remark = new Remark();
            var employeeId = "Akash";//Request.Cookies["Id"];
            WebClient remarkReadClient = new WebClient();
            remarkReadClient.Headers.Add("Content-Type", "application/json");
            //get remark service call
            RemarkListResponse response = new RemarkListResponse();
            response = response.GetRemarks(employeeId, GridView1.PageSize.ToString(), (GridView1.PageIndex + 1).ToString());
            GridView1.VirtualItemCount = Int32.Parse(response.ResponseRemarkList[GridView1.PageSize].Text);
            Remark last = response.ResponseRemarkList[GridView1.PageSize];
            response.ResponseRemarkList.Remove(last);
            GridView1.DataSource = response.ResponseRemarkList;
            GridView1.DataBind();
        }
    }
}