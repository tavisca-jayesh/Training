using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TempWebFormApp.Models;

namespace TempWebFormApp
{
    public partial class LoginUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Redirect using Role


            LoginAuthetication loginInfo = new LoginAuthetication();
            loginInfo.EmailId = UserId.Text;
            loginInfo.Password = Password.Text;
            WebClient client = new WebClient();

            //Write Login Service
            //var empResponse = client.UploadData<LoginAuthetication, Employee>("http://localhost:53412/LoginAuthenticationService.svc/employeeAuthentication/" + loginInfo.EmailId + "/" + loginInfo.Password, loginInfo);

            client.Headers.Add("Content-Type", "application/json");

            var empResponse = client.DownloadString("http://localhost:53412/LoginAuthenticationService.svc/employeeAuthentication/" + loginInfo.EmailId + "/" + loginInfo.Password);
            var empResponseDe = Serializer.Deserialize<Employee>(empResponse);

            //Session["employeeId"] = empResponse.Id;
            //Session["employeeTitle"] = empResponse.Title;
            if (empResponse.Equals(null))
            {
                Response.Write("Invalid User Name or Password");
            }
            else
            {
                if (string.Equals(empResponseDe.Role.Trim(), "HR", StringComparison.OrdinalIgnoreCase))
                {
                    Response.Redirect("http://localhost:62581/HRHome.aspx");
                }

                Response.Redirect("http://localhost:62581/EmployeeHome.aspx");
            }
            Response.Redirect("HRHome.aspx");
        }
    }
}