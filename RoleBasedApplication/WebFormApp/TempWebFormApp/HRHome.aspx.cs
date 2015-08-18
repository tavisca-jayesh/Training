using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeRemarkApp.UI
{
    public partial class HRHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] == null || Request.Cookies["Password"] == null)
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
            }
            if (!Page.IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }
        }
        protected void Page_PreRender(object sender, System.EventArgs e)
        {
            
        }
       
        public void EmployeeView(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex -= 1;   
        }

        public void RemarkView(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex += 1;
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null && Request.Cookies["Id"] != null)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies["Id"].Expires = DateTime.Now.AddDays(-1d);
            }
            Response.Redirect("http://localhost:62581/LoginPage");
        }

        

    }
}