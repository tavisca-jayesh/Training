using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.EnterpriseLibrary;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.ServiceContract;
using Tavisca.EmployeeManagement.Translator;

namespace Tavisca.EmployeeManagement.ServiceImpl
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IEmployeeManager manager)
        {
            _manager = manager;
        }

        IEmployeeManager _manager;

        public DataContract.EmployeeResponse Get(string employeeId)
        {
            DataContract.EmployeeResponse response = new DataContract.EmployeeResponse();
            try
            {
                var result = _manager.Get(employeeId);
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

        public DataContract.EmployeeListResponse GetAll()
        {
            DataContract.EmployeeListResponse response = new DataContract.EmployeeListResponse();
            try
            {
                var result = _manager.GetAll();
                if (result == null) return null;
                response.ResponseEmployeeList = result.Select(employee => employee.ToDataContract()).ToList();
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

        public DataContract.RemarkListResponse GetRemarks(string employeeId, string pageSize, string pageNumber)
        {
            DataContract.RemarkListResponse response = new DataContract.RemarkListResponse();
            try
            {
                var result = _manager.GetRemarks(employeeId, pageSize, pageNumber);
                if (result == null) return null;
                response.ResponseRemarkList = result.Select(employee => employee.ToDataContract()).ToList();
                return response;
            }
            catch (Exception ex)
            {
                response.ResponseStatus.StatusCode = "500";
                response.ResponseStatus.Message = ex.Message;
                return response;
            }

        }
    }
}
