using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Translator
{
    public static class ChangePasswordTranslator
    {
        public static Model.ChangePassword ToDomainModel(this DataContract.ChangePassword newCredentials)
        {
            if (newCredentials == null) return null;
            return new Model.ChangePassword()
            {
                Id = newCredentials.Id,
                Password = newCredentials.Password,
                NewPassword = newCredentials.NewPassword
            };
        }
    }
}
