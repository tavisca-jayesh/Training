using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.ServiceContract;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Translator;
using Tavisca.EmployeeManagement.EnterpriseLibrary;

namespace Tavisca.EmployeeManagement.ServiceImpl
{
    public class LoginAuthenticationService : ILoginAuthenticationService
    {
        public LoginAuthenticationService(ILoginAuthenticationManager manager)
        {
            _manager = manager;
        }

        ILoginAuthenticationManager _manager;

        public DataContract.EmployeeResponse Authenticate(DataContract.LoginAuthentication employeeDetails)
        {
            DataContract.EmployeeResponse response = new DataContract.EmployeeResponse();
            try
            {
                var result = _manager.Authenticate(employeeDetails.ToDomainModel());
                if (result == null) return null;
                response.ResponseEmployee = result.ToDataContract();
                return response;
            }
            catch (Exception ex)
            {
                response.ResponseStatus.StatusCode = "401";
                response.ResponseStatus.Message = ex.Message;
                return response;
            }
        }
    }
}

