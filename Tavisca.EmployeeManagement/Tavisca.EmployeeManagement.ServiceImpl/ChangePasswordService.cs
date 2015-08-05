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
    public class ChangePasswordService : IChangePasswordService
    {
        public ChangePasswordService(IChangePasswordManager manager)
        {
            _manager = manager;
        }

        IChangePasswordManager _manager;

        public DataContract.ChangePasswordResponse ChangingPassword(DataContract.ChangePassword newCredentials)
        {
            DataContract.ChangePasswordResponse response = new DataContract.ChangePasswordResponse();
            try
            {
                var result = _manager.ChangingPassword(newCredentials.ToDomainModel());
                if (result == null) throw new ArgumentException();
                response.ResponseChangePassword = result;
                return response;
            }
            catch (Exception ex)
            {
                response.ResponseStatus.StatusCode = "500";
                response.ResponseStatus.Message = ex.Message;
                return response;
            }

            //DataContract.EmployeeResponse response = new DataContract.EmployeeResponse();
            //try
            //{
            //    var result = _manager.Create(employee.ToDomainModel());
            //    if (result == null) return null;
            //    response.ResponseEmployee = result.ToDataContract();
            //    return response;
            //}
            //catch (Exception ex)
            //{
            //    response.ResponseStatus.StatusCode = "500";
            //    response.ResponseStatus.Message = ex.Message;
            //    //var rethrow = ExceptionPolicy.HandleException("service.policy", ex);
            //    //if (rethrow) throw;
            //    return response;
            //}
        }
    }
}
