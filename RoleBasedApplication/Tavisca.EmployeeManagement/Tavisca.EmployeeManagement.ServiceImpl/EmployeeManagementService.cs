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
    public class EmployeeManagementService : IEmployeeManagementService
    {
        public EmployeeManagementService(IEmployeeManagementManager manager)
        {
            _manager = manager;
        }

        IEmployeeManagementManager _manager;

        public DataContract.EmployeeResponse Create(DataContract.Employee employee)
        {
            DataContract.EmployeeResponse response = new DataContract.EmployeeResponse();
            try
            {
                var result = _manager.Create(employee.ToDomainModel());
                if (result == null) return null;
                response.ResponseEmployee = result.ToDataContract();
                return response;
            }
            catch (Exception ex)
            {
                response.ResponseStatus.StatusCode = "500";
                response.ResponseStatus.Message = ex.Message;
                //var rethrow = ExceptionPolicy.HandleException("service.policy", ex);
                //if (rethrow) throw;
                return response;
            }
        }

        public DataContract.RemarkResponse AddRemark(string employeeId, DataContract.Remark remark)
        {
            DataContract.RemarkResponse response = new DataContract.RemarkResponse();
            try
            {
                var result = _manager.AddRemark(employeeId, remark.ToDomainModel());
                if (result == null) return null;
                response.ResponseRemark = result.ToDataContract();
                return response;
            }
            catch (Exception ex)
            {
                response.ResponseStatus.StatusCode = "500";
                response.ResponseStatus.Message = ex.Message;
                //var rethrow = ExceptionPolicy.HandleException("service.policy", ex);
                return response;
            }
        }

        public DataContract.EmployeeResponse Authenticate(DataContract.LoginAuthentication employeeDetails)
        {
            DataContract.EmployeeResponse response = new DataContract.EmployeeResponse();
            try
            {
                var result = _manager.Authenticate(employeeDetails.ToDomainModel());
                if (result == null) return null;
                Model.Employee emp = new Model.Employee();
                emp = employeeDetails.ToEmployee();
                response.ResponseEmployee=emp.ToDataContract();
                return response;
            }
            catch (Exception ex)
            {
                response.ResponseStatus.StatusCode = "500";
                response.ResponseStatus.Message = ex.Message;
                //var rethrow = ExceptionPolicy.HandleException("service.policy", ex);
                return response;
            }
        }

    }
}
