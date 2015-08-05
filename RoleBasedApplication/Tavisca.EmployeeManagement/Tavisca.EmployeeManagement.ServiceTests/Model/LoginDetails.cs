using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.ServiceTests.Model
{
    [DataContract]
    internal class LoginDetails
    {
        [DataMember]
        public string EmailId { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}
