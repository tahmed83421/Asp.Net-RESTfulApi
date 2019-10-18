using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Asp.Net_RESTfulApi.Controllers
{
    public class ValuesController : ApiController
    {
        SampleDbContext db = new SampleDbContext();
        // GET api/values
        public List<string> st = new List<string>()
        { "value0","value1","value2"};
        public IEnumerable<tblStudent> Get()
        {
            
            return db.tblStudents.ToList();
        }
    

      

        // GET api/values/5
        public IEnumerable< tblStudent> Get(int id)
        {
            return db.tblStudents.Where(x => x.Id == id).ToList();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            st.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            st[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            st.RemoveAt(id);
        }
    }
}
