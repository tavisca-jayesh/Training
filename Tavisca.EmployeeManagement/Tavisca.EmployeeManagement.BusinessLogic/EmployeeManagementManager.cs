using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.BusinessLogic
{
    public class EmployeeManagementManager : IEmployeeManagementManager
    {
        public EmployeeManagementManager(IEmployeeStorage storage)
        {
            _storage = storage;
        }

        IEmployeeStorage _storage;

        public Employee Create(Employee employee)
        {
            employee.DOJ = DateTime.UtcNow;
            employee.Validate();
            return _storage.Save(employee);
        }

        public Remark AddRemark(string employeeId, Remark remark)
        {
            remark.Validate();
            var employee = _storage.Get(employeeId);
            if(employee.Remarks == null) employee.Remarks = new List<Remark>();
            remark.CreateTimeStamp = DateTime.UtcNow;
            employee.Remarks.Add(remark);
            _storage.AddRemark(employeeId, remark);
            return remark;
        }

        public Employee Authenticate(LoginAuthentication employeeDetails)
        {
             employeeDetails.Validate();
            return _storage.Authenticate(employeeDetails);
        }
    }
}
