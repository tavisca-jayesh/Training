using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EmployeeRemarkApp.Model
{
    [DataContract]
    public class EmployeeResponse : Result
    {
        [DataMember]
        public Employee ResponseEmployee { get; set; }

        public EmployeeResponse Save(Employee employee)
        {
           HttpClient client = new HttpClient();
           var empResponse = client.UploadData<Employee, EmployeeResponse>(System.Configuration.ConfigurationManager.AppSettings["EmployeeManagementUrl"] + "/employee", employee);
           return empResponse;
        }

        public EmployeeResponse Authenticate(LoginAuthetication credentials)
        {
            HttpClient client = new HttpClient();
            var response = client.UploadData<LoginAuthetication, EmployeeResponse>(System.Configuration.ConfigurationManager.AppSettings["LoginAuthenticationUrl"] + "/login", credentials);
            return response;
        }
    }
}