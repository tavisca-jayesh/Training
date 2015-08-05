using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Model
{
    public class ChangePassword
    {
        public string Id { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Id))
                throw new Exception("FirstName cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(this.Password))
                throw new Exception("Email cannot be null or empty."); 
            
            if (string.IsNullOrWhiteSpace(this.NewPassword))
                throw new Exception("Email cannot be null or empty.");
        }
    }
}
