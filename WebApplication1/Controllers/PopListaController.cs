using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class PopListaController : ApiController
    {
        // GET: api/PopLista
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PopLista/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PopLista
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PopLista/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PopLista/5
        public void Delete(int id)
        {
        }
   


}
}
