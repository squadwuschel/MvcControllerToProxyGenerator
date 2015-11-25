using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProxyGenerator.ProxyTypeAttributes;

namespace ProxyGeneratorDemoPage.Controllers
{
    public class WebApiProxyController : ApiController
    {
        // GET: api/WebApiProxy2
        [CreateAngularJsProxy(ReturnType = typeof(List<string>))]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WebApiProxy2/5
        [CreateAngularJsProxy(ReturnType = typeof(string))]
        public string GetItem(int id)
        {
            return "value";
        }

        // POST: api/WebApiProxy2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/WebApiProxy2/5
        [CreateAngularJsProxy(ReturnType = typeof(void))]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/WebApiProxy2/5
        [CreateAngularJsProxy(ReturnType = typeof(void))]
        public void Delete(int id)
        {
        }
    }
}
