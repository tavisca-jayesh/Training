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
using System.IO;
using System.Runtime.Serialization.Json;

namespace TempWebFormApp
{
    public partial class EmployeeHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LoadGridView(sender,e);
            }
            
        }

        protected void LoadGridView(object sender, EventArgs e)
        {
            Remark remark = new Remark();
            var employeeId = "Akash";//EmployeeIdBox.Text;
            WebClient remarkReadClient = new WebClient();
            remarkReadClient.Headers.Add("Content-Type", "application/json");
            //get remark service call
            
            var remarkResponse = remarkReadClient.DownloadString("http://localhost:53412/EmployeeService.svc/employee/" + employeeId + "/"+GridView1.PageSize+"/"+(GridView1.PageIndex+1)+"/remark");
            var remarkResponseDe = Serializer.Deserialize<List<Remark>>(remarkResponse);
            GridView1.VirtualItemCount=Int32.Parse(remarkResponseDe[GridView1.PageSize].Text);
            Remark last = remarkResponseDe[GridView1.PageSize];

            remarkResponseDe.Remove(last);
            GridView1.DataSource = remarkResponseDe;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGridView(sender,e);
        }

        protected void EmployeeIdSubmit_Click(object sender, EventArgs e)
        {
            //change password here
            var employeeId = "1231";
            var newPassword = EmployeeIdBox.Text;
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
            ser.WriteObject(stream1, newPassword);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            string d = sr.ReadToEnd();
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var response = client.UploadString("http://http://localhost:53412/ChangePasswordService.svc/"+employeeId+"/"+newPassword, "POST", d);
        }

        protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
        {
            //change password here
            var employeeId = "1231";
            var newPassword = EmployeeIdBox.Text;
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
            ser.WriteObject(stream1, newPassword);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            string d = sr.ReadToEnd();
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var response = client.UploadString("http://http://localhost:53412/ChangePasswordService.svc/" + employeeId + "/" + newPassword, "POST", d);
        }

        protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
        {
            //change password here
            var employeeId = "1231";
            var newPassword = EmployeeIdBox.Text;
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
            ser.WriteObject(stream1, newPassword);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            string d = sr.ReadToEnd();
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var response = client.UploadString("http://http://localhost:53412/ChangePasswordService.svc/" + employeeId + "/" + newPassword, "POST", d);
        }

    }
}