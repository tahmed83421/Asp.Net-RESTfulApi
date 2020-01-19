using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using Asp.Net_RESTfulApi.Models;
using Asp.Net_RESTfulApi;

namespace Asp.Net_RESTfulApi.Controllers
{
    public class ValuesController : ApiController
    {
        SampleDbContext db = new SampleDbContext();
        KSAEntities1 db2 = new KSAEntities1();
        
        // GET api/values
        public List<string> st = new List<string>()
        { "value0","value1","value2"};

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return st;
        }


     /* [BasicAuthentication]
        public HttpResponseMessage Get( string gender="All")
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            switch (username.ToLower())
            {
                case "All":
                    return Request.CreateResponse(HttpStatusCode.OK, db2.Employees.ToList());
                case "male":
                    return Request.CreateResponse(HttpStatusCode.OK, db2.Employees.Where(x => x.Gender == "male").ToList());
                case "female":
                    return Request.CreateResponse(HttpStatusCode.OK, db2.Employees.Where(x => x.Gender == "female").ToList());

                default:
                    return Request.CreateResponse(HttpStatusCode.BadRequest,"please Select USername Correctly");
            }
        
        }
    

      */
      [HttpGet]
        // GET api/values/5
        public HttpResponseMessage LoadStudentById(int id)
        {

            return Request.CreateResponse(HttpStatusCode.OK,st[id]);
            //try
            //{
            //    using (SampleDbContext DB = new SampleDbContext())
            //    {
            //       var entity =  DB.tblStudents.FirstOrDefault(x => x.Id == id);
            //        if(entity != null)
            //        {
            //            return Request.CreateResponse(HttpStatusCode.OK, entity);
            //        }
            //        else
            //        {
            //            return Request.CreateResponse(HttpStatusCode.BadRequest, "not found");
            //        }
                   


            //    }
            //}
            //catch (Exception ex)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            //}
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody] tblStudent student)
        {
            try
            {
                using (SampleDbContext DB = new SampleDbContext())
                {
                    DB.tblStudents.Add(student);
                    DB.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, student);
                    message.Headers.Location = new Uri(Request.RequestUri + student.Id.ToString());
                    return message;


                }
            }
            catch (Exception ex)
            {
              return  Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody] tblStudent student)
        {
            try
            {

                using (SampleDbContext db = new SampleDbContext())
                {
                    var entity = db.tblStudents.FirstOrDefault(x => x.Id == id);
                    entity.Name = student.Name;
                    entity.TotalMarks = student.TotalMarks;
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, student);
                    message.Headers.Location = new Uri(Request.RequestUri + student.Id.ToString());
                    return message;

                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
           
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (SampleDbContext DB = new SampleDbContext())
                {
                  var entity=  DB.tblStudents.FirstOrDefault(x => x.Id == id);
                    if(entity!=null)
                    {
                        DB.tblStudents.Remove(entity);
                        DB.SaveChanges();
                       return Request.CreateErrorResponse(HttpStatusCode.OK, "DONE!");
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Not Fouunf");
                    }
                   

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
