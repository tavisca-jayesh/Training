using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeRemarkApp.Model;

namespace EmployeeRemarkApp.UI
{
    public partial class AddRemarkUserControl : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] == null || Request.Cookies["Password"] == null)
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
                EmployeeListResponse allEmployees = new EmployeeListResponse();

                Dictionary<string, string> employeeDictionary = new Dictionary<string, string>();
                allEmployees = allEmployees.GetAllEmployees();
                foreach (Employee employee in allEmployees.ResponseEmployeeList)
                {
                    employeeDictionary.Add(employee.Id.ToString(), employee.FirstName + "  " + employee.LastName);
                }
                EmployeeList.DataTextField = "Value";
                EmployeeList.DataValueField = "Key";
                EmployeeList.DataSource = employeeDictionary;
                EmployeeList.DataBind();
            }
        }

        protected void AddRemarkButton_Click(object sender, ImageClickEventArgs e)
        {
            HRHome EmpView = new HRHome();
            Remark remark = new Remark();
            remark.Text = RemarkText.Value;
            remark.CreateTimeStamp = DateTime.UtcNow;

            RemarkResponse add = new RemarkResponse();
            var response = add.AddRemark(remark, EmployeeList.SelectedValue.ToString());
            RemarkText.InnerText = null;
            RemarkText.InnerHtml = null;
            EmployeeList.SelectedIndex = -1;

            EmpView.EmployeeView(sender, e);

        }

        protected void EmployeeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}