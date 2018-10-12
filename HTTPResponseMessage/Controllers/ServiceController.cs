using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTPResponseMessage.Controllers
{
    public class ServiceController : ApiController
    {
        static List<string> serviceData = LoadService();

        public static List<string> LoadService()
        {
            return new List<string>() { "Mobile Recharge", "Bill Payment" };
        }
        // GET: api/Service
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse<IEnumerable<string>>(HttpStatusCode.OK,serviceData);
        }

        // GET: api/Service/5
        public HttpResponseMessage Get(int id)
        {
            if (serviceData.Count > id)
                return Request.CreateResponse<string>(HttpStatusCode.OK, serviceData[id]);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item Not Found");
        }

        // POST: api/Service
        public HttpResponseMessage Post([FromBody]string value)
        {
            serviceData.Add(value);
            return Request.CreateResponse(HttpStatusCode.Created, "Item Added Successfully");
        }

        // PUT: api/Service/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            serviceData[id] = value;
            return Request.CreateResponse(HttpStatusCode.OK, "Item Updated Successfully");
        }

        // DELETE: api/Service/5
        public HttpResponseMessage Delete(int id)
        {
            serviceData.RemoveAt(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Item Deleted Successfully");
        }
    }
}
