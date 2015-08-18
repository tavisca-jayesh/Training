using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EmployeeRemarkApp.Model
{
    [DataContract]
    public class RemarkResponse : Result
    {
        [DataMember]
        public Remark ResponseRemark { get; set; }

        public RemarkResponse AddRemark(Remark remark,string employeeId)
        {
            HttpClient client = new HttpClient();
            var response = client.UploadData<Remark, RemarkResponse>("http://localhost:53412/EmployeeManagementService.svc" + "/employee/" + employeeId + "/remark", remark);
            return response;
        
        }
    }
}
