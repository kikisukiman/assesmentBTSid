using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

using AssesmentWebApi.Model;

namespace AssesmentWebApi.Controllers
{
    public class ShoppingController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            User user = new User();

            return Request.CreateResponse(HttpStatusCode.OK, user, new JsonMediaTypeFormatter());
        }

    }
}
