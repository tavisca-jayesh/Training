using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.Interface
{
    public interface IEmployeeStorage
    {
        Employee Save(Employee employee);

        Employee Get(string employeeId);

        List<Employee> GetAll();

        Remark AddRemark(string employeeId, Remark remark);

        List<Remark> GetRemarks(string employeeId, string pageSize, string pageNumber);

        Employee Authenticate(LoginAuthentication employeeDetails);

        bool changePassword(ChangePassword newCredentials);
    }
}
