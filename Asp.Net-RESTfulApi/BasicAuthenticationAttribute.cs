using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Security.Principal;

namespace Asp.Net_RESTfulApi
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
             string decodedauthenticationToken= Encoding.UTF8.GetString(  Convert.FromBase64String(authenticationToken));

                string[] UsernamePasswordArray = decodedauthenticationToken.Split(':');
                string username = UsernamePasswordArray[0];
                string password = UsernamePasswordArray[1];
                if (EmployeeSecurity.Login(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
            }
          
        }
    }
}