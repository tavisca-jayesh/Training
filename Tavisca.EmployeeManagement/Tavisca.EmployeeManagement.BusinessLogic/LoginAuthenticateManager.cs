using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.BusinessLogic
{
    public class LoginAuthenticateManager
    {
        public LoginAuthenticateManager(IEmployeeStorage storage)
        {
            _storage = storage;
        }

        IEmployeeStorage _storage;

        public Employee Authenticate(Model.LoginAuthentication employeeDetails)
        {
            employeeDetails.Validate();
            return _storage.Authenticate(employeeDetails);
        }
    }
}
