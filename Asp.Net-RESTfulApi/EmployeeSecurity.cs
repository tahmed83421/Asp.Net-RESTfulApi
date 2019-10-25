using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asp.Net_RESTfulApi.Models;

namespace Asp.Net_RESTfulApi
{
    public class EmployeeSecurity
    {
        public static bool Login(string username , string password)
        {
            using (LocalTestEntities db = new LocalTestEntities())
            {
               return db.Users.Any(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && 
               x.Password == password);
              

            }
        }
    }
}