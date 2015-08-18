using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeRemarkApp.Model;
using System.IO;
using System.Runtime.Serialization.Json;

namespace EmployeeRemarkApp.UI
{
    public partial class EmployeeHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] == null || Request.Cookies["Password"] == null || Request.Cookies["Id"]==null)
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
                LoadGridView(sender, e);
                //change password change view
                ChangePassword1.ChangePasswordTemplateContainer.Visible = true;
                ChangePassword1.SuccessTemplateContainer.Visible = false;
                
            }
        }

        protected void LoadGridView(object sender, EventArgs e)
        {
            Remark remark = new Remark();
            var employeeId = "Akash";//Request.Cookies["Id"];
            WebClient remarkReadClient = new WebClient();
            remarkReadClient.Headers.Add("Content-Type", "application/json");
            //get remark service call
            RemarkListResponse response = new RemarkListResponse();
            response = response.GetRemarks(employeeId , GridView1.PageSize.ToString(),(GridView1.PageIndex + 1).ToString());
           
            GridView1.VirtualItemCount=Int32.Parse(response.ResponseRemarkList[GridView1.PageSize].Text);
            Remark last = response.ResponseRemarkList[GridView1.PageSize];

            response.ResponseRemarkList.Remove(last);
            GridView1.DataSource = response.ResponseRemarkList;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGridView(sender, e);
        }

        protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
        {
            //change password here
            Model.ChangePassword newCredentials = new Model.ChangePassword();
            newCredentials.Id = Request.Cookies["Id"].Value;
            newCredentials.NewPassword = "asdf123"; //take from textbox

            Model.ChangePasswordResponse changePwd = new Model.ChangePasswordResponse();
            var response = changePwd.changePwd(newCredentials);
            //success
            if (response.ResponseStatus.StatusCode == "200")
            {
                ChangePassword1.ChangePasswordTemplateContainer.Visible = false;
                ChangePassword1.SuccessTemplateContainer.Visible = true;
            }
            else
            {
                ChangePassword1.SuccessTemplateContainer.Visible = false;
                ChangePassword1.ChangePasswordTemplateContainer.Visible = true;
                //show error
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies["Id"].Expires = DateTime.Now.AddDays(-1d);
            }
            Response.Redirect("http://localhost:62581/LoginPage");
        }
    }
}