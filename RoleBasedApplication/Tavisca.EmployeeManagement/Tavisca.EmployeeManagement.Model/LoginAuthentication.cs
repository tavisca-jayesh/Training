using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Model
{
    public class LoginAuthentication
    {
        public string EmailId { get; set; }

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
