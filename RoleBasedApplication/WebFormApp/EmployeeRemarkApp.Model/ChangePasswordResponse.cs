using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EmployeeRemarkApp.Model
{
    [DataContract]
    public class ChangePasswordResponse : Result
    {
        [DataMember]
        public bool ResponseChangePassword { get; set; }

        public ChangePasswordResponse changePwd(ChangePassword newCredentials)
        {
            HttpClient client = new HttpClient();
            var response = client.UploadData<ChangePassword, ChangePasswordResponse>(System.Configuration.ConfigurationManager.AppSettings["ChangePasswordUrl"] + "/changePassword", newCredentials);
            return response;
        }
    }
}
