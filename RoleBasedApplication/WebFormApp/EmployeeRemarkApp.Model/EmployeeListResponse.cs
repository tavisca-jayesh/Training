using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRemarkApp.Model
{
    [DataContract]
    public class EmployeeListResponse : Result
    {
        [DataMember]
        public List<Employee> ResponseEmployeeList { get; set; }

        public EmployeeListResponse GetAllEmployees()
        {
            HttpClient client = new HttpClient();
           var empResponse = client.GetData<EmployeeListResponse>(System.Configuration.ConfigurationManager.AppSettings["EmployeeUrl"] + "/employee");
           return empResponse;
        }
    }
}