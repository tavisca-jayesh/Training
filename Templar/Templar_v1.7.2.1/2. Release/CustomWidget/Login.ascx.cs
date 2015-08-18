using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;
using EmployeeRemarkApp.Model;

namespace CustomWidget
{
    public partial class Login : System.Web.UI.UserControl, IWidget
    {
        IWidgetHost Host = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Host.CurrentPageMode != PageMode.Design)
            {
                LoginPanel.Visible = true;
            }
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    UserId.Text = Request.Cookies["UserName"].Value;
                    Password.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }

        public void HideSettings()
        {
            LoginPanel.Visible = false;
        }

        public new void Init(IWidgetHost host)
        {
            Host = host;
        }

        public void ShowSettings()
        {
            LoginPanel.Visible = true;
        }

        protected void LoginButton_Click(object sender, EventArgs e, string employeeId)
        {

            if (RememberMe.Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Id"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Role"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["Id"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["Role"].Expires = DateTime.Now.AddDays(1);
            }
        }

        protected void SubmitLogin_Click(object sender, EventArgs e)
        {
            LoginAuthetication loginInfo = new LoginAuthetication();
            loginInfo.EmailId = UserIdBox.Text;
            loginInfo.Password = PwdBox.Text;

            EmployeeResponse authenticateEmployee = new EmployeeResponse();
            var response = authenticateEmployee.Authenticate(loginInfo);

            if (response.ResponseStatus.StatusCode == "200")
            {
                //success

                LoginButton_Click(sender, e, response.ResponseEmployee.Id.ToString());
                Response.Cookies["UserName"].Value = UserId.Text.Trim();
                Response.Cookies["Password"].Value = Password.Text.Trim();
                Response.Cookies["Id"].Value = response.ResponseEmployee.Id.ToString().Trim();
                Response.Cookies["Role"].Value = response.ResponseEmployee.Role.ToString().Trim();
            }
            else
            {
                //error
                FailureField.Text = "Invalid User Name or Password";
                FailureField.Visible = true;
            }

            //Redirect
            if(response.ResponseEmployee.Role == "HR")
                Response.Redirect("HRHome");
            else
                Response.Redirect("EMPHome");
        }
    }
}