using EmployeeRemarkApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace CustomWidget
{
    public partial class ChangePassword : System.Web.UI.UserControl,IWidget
    {
        IWidgetHost Host = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Host.CurrentPageMode != PageMode.Design)
            {
                ChangePasswordPanel.Visible = true;
            }
            if (!IsPostBack)
            {
                if (Request.Cookies["Role"].Value != "EMP" || Request.Cookies["UserName"] == null || Request.Cookies["Password"] == null)
                {
                    Response.Redirect("LoginPage");
                }
            }
        }

        public void HideSettings()
        {
            ChangePasswordPanel.Visible = false;
        }

        public new void Init(IWidgetHost host)
        {
            Host = host;
        }

        public void ShowSettings()
        {
            ChangePasswordPanel.Visible = true;
        }

        protected void ChangePwdButton_Click(object sender, EventArgs e)
        {

            EmployeeRemarkApp.Model.ChangePassword newCredentials = new EmployeeRemarkApp.Model.ChangePassword();
            newCredentials.Id = Request.Cookies["Id"].Value;
            newCredentials.NewPassword = NewPwdBox.Text;

            EmployeeRemarkApp.Model.ChangePasswordResponse changePwd = new EmployeeRemarkApp.Model.ChangePasswordResponse();
            var response = changePwd.changePwd(newCredentials);

            if (response.ResponseStatus.StatusCode == "200")
            {
                CurrentPwdBox.Text = null;
                NewPwdBox.Text = null;
                ConfirmPwdBox.Text = null;
                FailureField.Visible = false;
                SuccessField.Visible = true;
                Response.Redirect("EMPHome");
            }
            else
            {
                SuccessField.Visible = false;
                FailureField.Visible = true;
            }
        }

    }
}