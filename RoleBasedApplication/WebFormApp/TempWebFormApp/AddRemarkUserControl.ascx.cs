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
    public partial class AddRemarkUserControl : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            HRHome EmpView = new HRHome();
            Remark remark = new Remark();
            remark.Text = RemarkText.Value;
            remark.CreateTimeStamp = DateTime.UtcNow;
            var employeeId = EmployeeIdText.Text;

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Remark));
            ser.WriteObject(stream1, remark);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            string d = sr.ReadToEnd();
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var response = client.UploadString("http://localhost:53412/EmployeeManagementService.svc/employee/" + employeeId + "/remark", "POST", d);
            EmpView.EmployeeView(sender, e);
        }
    }
}