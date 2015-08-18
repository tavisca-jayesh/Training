using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EmployeeRemarkApp.Model
{
    [DataContract]
    public class Remark
    {
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public DateTime CreateTimeStamp { get; set; }
    }
}