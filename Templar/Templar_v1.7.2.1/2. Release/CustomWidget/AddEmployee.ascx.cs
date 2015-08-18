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
    public partial class AddEmployee : System.Web.UI.UserControl, IWidget
    {
        IWidgetHost Host = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Host.CurrentPageMode != PageMode.Design)
            {
                AddEmpPanel.Visible = true;
            }

            if (!IsPostBack)
            {
                if (Request.Cookies["Role"].Value != "HR" || Request.Cookies["UserName"] == null || Request.Cookies["Password"] == null)
                {
                    Response.Redirect("LoginPage");
                }
            }
        }

        public void HideSettings()
        {
            AddEmpPanel.Visible = false;
            //throw new NotImplementedException();
        }

        public new void Init(IWidgetHost host)
        {
            Host = host;
            //throw new NotImplementedException();
        }

        public void ShowSettings()
        {
            AddEmpPanel.Visible = true;
            //throw new NotImplementedException();
        }

        protected void EmpSubmitButton_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Id = 0;
            employee.Title = TitleBox.Text;
            employee.FirstName = FirstNameBox.Text;
            employee.LastName = LastNameBox.Text;
            employee.Email = EmailBox.Text;
            employee.Phone = PhoneBox.Text;
            employee.Password = System.Configuration.ConfigurationManager.AppSettings["DefaultPassword"]; //default password
            employee.Role = RoleBox.Text;

            EmployeeResponse save = new EmployeeResponse();
            var response = save.Save(employee);

            if (response.ResponseStatus.StatusCode == "200")
            {
                TitleBox.Text = null;
                FirstNameBox.Text = null;
                LastNameBox.Text = null;
                EmailBox.Text = null;
                PhoneBox.Text = null;
                RoleBox.Text = null;
                FailureField.Visible = false;
                SuccessField.Visible = true;
                Response.Redirect("HRHome");
            }
            else
            {
                SuccessField.Visible = false;
                FailureField.Visible = true;
            }
        }
    }
}