using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EmployeeRemarkApp.Model
{
    [DataContract]
    public class LoginAuthetication
    {
        [DataMember]
        public string EmailId { get; set; }
        [DataMember]
        public string Password { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.EmailId))
                throw new Exception("Email-id cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(this.Password))
                throw new Exception("Password cannot be null or empty.");
        }
    }
}