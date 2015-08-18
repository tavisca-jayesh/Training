using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeRemarkApp.Model;
using System.Runtime.Serialization.Json;

namespace EmployeeRemarkApp.UI
{
    public partial class LoginUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    UserId.Text = Request.Cookies["UserName"].Value;
                    Password.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }
        protected void LoginButton_Click(object sender, EventArgs e,string employeeId)
        {

            if (RememberMe.Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Id"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["Id"].Expires = DateTime.Now.AddDays(30);
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Redirect using Role

            LoginAuthetication loginInfo = new LoginAuthetication();
            loginInfo.EmailId = UserId.Text;
            loginInfo.Password = Password.Text;

            EmployeeResponse authenticateEmployee = new EmployeeResponse();
            var response = authenticateEmployee.Authenticate(loginInfo);

            if (response.ResponseStatus.StatusCode == "200")
            {
                LoginButton_Click(sender, e, response.ResponseEmployee.Id.ToString());
                Response.Cookies["UserName"].Value = UserId.Text.Trim();
                Response.Cookies["Password"].Value = Password.Text.Trim();
                Response.Cookies["Id"].Value = response.ResponseEmployee.Id.ToString().Trim();
            }
            else
            { 
                //show error
            }
            if (response.ResponseStatus.StatusCode.Equals("401") || response.ResponseEmployee == null)
            {
                Response.Write("Invalid User Name or Password");
            }
            else
            {
                if (string.Equals(response.ResponseEmployee.Role.Trim(), "HR", StringComparison.OrdinalIgnoreCase))
                {
                    Response.Redirect("http://localhost:62581/HRHome.aspx");
                }
                Response.Redirect("http://localhost:62581/EmployeeHome.aspx");
            }
            Response.Redirect("HRHome.aspx");
        }
    }
}