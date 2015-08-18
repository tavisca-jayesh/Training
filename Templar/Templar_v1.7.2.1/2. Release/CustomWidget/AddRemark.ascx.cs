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
    public partial class AddRemark : System.Web.UI.UserControl,IWidget
    {
        IWidgetHost Host = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Host.CurrentPageMode != PageMode.Design)
            {
                AddRemarkPanel.Visible = true;
            }
            if (!IsPostBack)
            {
                if (Request.Cookies["Role"].Value != "HR" || Request.Cookies["UserName"] == null || Request.Cookies["Password"] == null)
                {
                    Response.Redirect("LoginPage");
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

        public void HideSettings()
        {
            AddRemarkPanel.Visible = false;
            //throw new NotImplementedException();
        }

        public new void Init(IWidgetHost host)
        {
            Host = host;
            //throw new NotImplementedException();
        }

        public void ShowSettings()
        {
            AddRemarkPanel.Visible = true;
            //throw new NotImplementedException();
        }

        protected void RemarkSubmitButton_Click(object sender, EventArgs e)
        {
            Remark remark = new Remark();
            remark.Text = RemarkText.Value;
            remark.CreateTimeStamp = DateTime.UtcNow;
            RemarkResponse add = new RemarkResponse();
            string id = EmployeeList.SelectedValue;
            var response = add.AddRemark(remark, id ); 

            if (response.ResponseStatus.StatusCode == "200")
            {
                RemarkText.InnerText = null;
                RemarkText.InnerHtml = null;
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

        protected void EmployeeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}