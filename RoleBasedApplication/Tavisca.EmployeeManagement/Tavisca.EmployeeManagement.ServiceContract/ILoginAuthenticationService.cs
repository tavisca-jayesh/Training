using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.DataContract;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Tavisca.EmployeeManagement.ServiceContract
{
    [ServiceContract]
    public interface ILoginAuthenticationService
    {
        [WebInvoke(Method = "POST", UriTemplate = "/login", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        EmployeeResponse Authenticate(LoginAuthentication details);
    }
}