using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Interface
{
    public interface ILoginAuthenticateManager
    {
        Model.Employee Authenticate(Model.LoginAuthentication employeeDetails);
    }
}
