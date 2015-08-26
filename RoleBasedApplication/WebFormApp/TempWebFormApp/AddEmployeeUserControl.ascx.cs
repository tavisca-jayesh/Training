using EmployeeRemarkApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeRemarkApp.UI
{
    public partial class AddEmployeeUserControl : System.Web.UI.UserControl
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
        }

        protected void EmpSubmitButton_Click(object sender, ImageClickEventArgs e)
        {
            Employee employee = new Employee();
            employee.Id = 0;
            employee.Title = TitleBox.Text;
            employee.FirstName = FirstNameBox.Text;
            employee.LastName = LastNameBox.Text;
            employee.Email = EmailBox.Text;
            employee.Phone = PhoneBox.Text;
            employee.Password = "asdf123"; //default password
            employee.Role = employee.Title;

            EmployeeResponse save = new EmployeeResponse();
            var response = save.Save(employee);

            if (response.ResponseStatus.StatusCode == "200")
            {
                TitleBox.Text = null;
                FirstNameBox.Text = null;
                LastNameBox.Text = null;
                EmailBox.Text = null;
                PhoneBox.Text = null;

                Success.Visible = true;

                HRHome EmployeeView = new HRHome();
                EmployeeView.EmployeeView(sender, e);
            }
            else
            {
                Failure.Visible = true;
                //error respose
            }
        }
    }
}