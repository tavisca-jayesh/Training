using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EmployeeRemarkApp.Model
{
    [DataContract]
    public class RemarkListResponse : Result
    {
        [DataMember]
        public List<Remark> ResponseRemarkList { get; set; }

        public RemarkListResponse GetRemarks(string employeeId,string pageSize,string pageNumber)
        {
            HttpClient client = new HttpClient();
            var response = client.GetData<RemarkListResponse>(System.Configuration.ConfigurationManager.AppSettings["EmployeeUrl"] + "/employee/"+employeeId+"/"+pageSize+"/"+pageNumber+"/remark");
            return response;
        }
    }
}
