using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.BusinessLogic
{
    class ChangePasswordManager : IChangePasswordManager
    {
        public ChangePasswordManager(IEmployeeStorage storage)
        {
            _storage = storage;
        }

        IEmployeeStorage _storage;

        public bool ChangingPassword(ChangePassword newCredentials)
        {
            return _storage.changePassword(newCredentials);
        }
    }
}
