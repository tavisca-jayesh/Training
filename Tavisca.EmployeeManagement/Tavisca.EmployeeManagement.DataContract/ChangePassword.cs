using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Tavisca.EmployeeManagement.DataContract
{
    [DataContract]
    public class ChangePassword
    {
        public ChangePassword() { }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Password { get; set; }
        
        [DataMember]
        public string NewPassword { get; set; }
    }
}
