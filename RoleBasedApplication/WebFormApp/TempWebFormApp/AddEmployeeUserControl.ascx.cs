using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TempWebFormApp.Models;

namespace TempWebFormApp
{
    public partial class AddEmployeeUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EmpSubmitButton_Click(object sender, ImageClickEventArgs e)
        {

            Employee employee = new Employee();
            employee.Id = 131;
            employee.Title = TitleBox.Text;
            employee.FirstName = FirstNameBox.Text;
            employee.LastName = LastNameBox.Text;
            employee.Email = EmailBox.Text;
            employee.Phone = PhoneBox.Text;
            employee.Password = "asdf123";
            employee.Role = employee.Title;

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Employee));
            ser.WriteObject(stream1, employee);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            string d = sr.ReadToEnd();
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var responsejson = client.UploadString("http://localhost:53412/EmployeeManagementService.svc/employee", "POST", d);
            var response = Serializer.Deserialize<EmployeeResponse>(responsejson);
            if (response.ResponseStatus.StatusCode == "200")
            {
                HRHome EmployeeView = new HRHome();
                EmployeeView.EmployeeView(sender, e);
            }
            else
            {
                //error respose
            }
        }
    }
}