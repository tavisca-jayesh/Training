using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRemarkApp.Model
{
    [DataContract]
    public class Status
    {
        [DataMember]
        public string StatusCode { get; set; }

        [DataMember]
        public string Message { get; set; }

        public static Status Success { get { return new Status() { StatusCode = "200", Message = "Success" }; } }
    }
}