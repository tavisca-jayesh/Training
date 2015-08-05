using System;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.EnterpriseLibrary;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.ServiceContract;
using Tavisca.EmployeeManagement.Translator;

namespace Tavisca.EmployeeManagement.ServiceImpl
{
    public class LoginAuthenticationService : IEmployeeAuthenticationService
    {
        public LoginAuthenticationService(IEmployeeManagementManager manager)
        {
            _manager = manager;
        }

        IEmployeeManagementManager _manager;

        public DataContract.EmployeeResponse Authenticate(string loginId,string password)
        {
            DataContract.EmployeeResponse response = new DataContract.EmployeeResponse();
            try
            {
                DataContract.LoginAuthentication EmployeeDetails = new DataContract.LoginAuthentication();
                EmployeeDetails.EmailId = loginId;
                EmployeeDetails.Password = password;
                var result = _manager.Authenticate(EmployeeDetails.ToDomainModel());
                if (result == null) return null;
                //Model.Employee emp = new Model.Employee();
                //emp = result.ToEmployee();
                response.ResponseEmployee = result.ToDataContract();
                return response;
            }
            catch (Exception ex)
            {
                //var rethrow = ExceptionPolicy.HandleException("service.policy", ex);
                //if (rethrow) throw;
                response.ResponseStatus.StatusCode = "500";
                response.ResponseStatus.Message = ex.Message;
                return response;
            }

        }

    }
}

