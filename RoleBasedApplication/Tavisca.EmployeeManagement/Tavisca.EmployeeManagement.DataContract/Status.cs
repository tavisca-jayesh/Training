using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Tavisca.EmployeeManagement.DataContract
{
    [DataContract]
    public class Status
    {
        [DataMember]
        public string StatusCode { get; set; }

        [DataMember]
        public string Message { get; set; }

        public static Status Success { get { return new Status() { StatusCode = "200", Message = "Success" }; } }
    }
}

//public DataContract.AuthenticateEmployeeResponse Authenticate(DataContract.Credentials creds)
//       {
//           DataContract.AuthenticateEmployeeResponse response = new DataContract.AuthenticateEmployeeResponse();
//           try
//           {
//               var result = _manager.Authenticate(creds.UserName, creds.Password);
//               if (result == null) return response;
//               response.AuthenticatedEmployee= result.ToDataContract();
//               return response;
//           }
//           catch (Exception ex)
//           {
//               Exception newEx;
//               var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
//               response.ResponseStatus.Code = "500";
//               response.ResponseStatus.Message = ex.Message;
//               return response;
//           }

//       }
//       public DataContract.ChangePasswordResponse ChangePassword(DataContract.PasswordChange pass)
//       {
//           DataContract.ChangePasswordResponse response = new DataContract.ChangePasswordResponse();
//           try
//           {
//               var result = _manager.ChangePassword(pass.EmployeeId, pass.OldPassword, pass.NewPassword);
//               DataContract.Employee emp = new DataContract.Employee();

//               if (result)
//               {
//                   return response;
//               }
//               response.ResponseStatus.Code = "500";
//               response.ResponseStatus.Message ="Failed";
//               return response;

//           }
//           catch (Exception ex)
//           {
//               Exception newEx;
//               var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
//               response.ResponseStatus.Code = "500";
//               response.ResponseStatus.Message = ex.Message;
//               return response;
//           }

