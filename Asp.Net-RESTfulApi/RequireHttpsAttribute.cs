﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Asp.Net_RESTfulApi
{
    public class RequireHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Found);
                actionContext.Response.Content = new StringContent("<p>Use Https instrad of Http</p>",Encoding.UTF8,"text/html");
                UriBuilder uriBuilder = new UriBuilder(actionContext.Request.RequestUri);
                uriBuilder.Scheme = Uri.UriSchemeHttps;
                uriBuilder.Port = 44358;
                actionContext.Response.Headers.Location = uriBuilder.Uri;

            }
            else
            {
                base.OnAuthorization(actionContext);
            }
           
        }
    }
}