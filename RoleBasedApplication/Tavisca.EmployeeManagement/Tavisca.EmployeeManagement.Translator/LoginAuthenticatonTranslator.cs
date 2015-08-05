using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Translator
{
    public static class LoginAuthenticatonTranslator
    {
        public static Model.LoginAuthentication ToDomainModel(this DataContract.LoginAuthentication employeeDetails)
        {
            if (employeeDetails == null) return null;
            return new Model.LoginAuthentication()
            {
                EmailId = employeeDetails.EmailId,
                Password = employeeDetails.Password,
            };
        }

        public static Model.LoginAuthentication ToDataContract(this DataContract.LoginAuthentication employeeDetails)
        {
            if (employeeDetails == null) return null;
            return new Model.LoginAuthentication()
            {
                EmailId = employeeDetails.EmailId,
                Password = employeeDetails.Password,
            };
        }

        public static Model.Employee ToEmployee(this DataContract.LoginAuthentication employeeDetails)
        {
            if (employeeDetails == null) return null;
            return new Model.Employee()
            {
                Email = employeeDetails.EmailId,
                DOJ=DateTime.UtcNow,
                Password = employeeDetails.Password
            };
        }
    }
}
