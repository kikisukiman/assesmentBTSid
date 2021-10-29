using AssesmentWebApi.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using AssesmentWebApi.Repo;
using AssesmentWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssesmentWebApi.Controllers
{

    public class UsersController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage signup([FromBody]User user)
        {
            int result = UserRepo.Instance.signupResult(user);
            if (result == 0)
                return Request.CreateResponse<ApiResult>(HttpStatusCode.OK, new ApiResult(result, "Success"), new JsonMediaTypeFormatter());
            else
                return Request.CreateResponse<ApiResult>(HttpStatusCode.InternalServerError, new ApiResult(result, "Server Error"), new JsonMediaTypeFormatter());
        }

        [HttpPost]
        public HttpResponseMessage signin([FromBody]User user)
        {
            int result = UserRepo.Instance.signinResult(user);
            if (result == 0)
                return Request.CreateResponse<ApiResult>(HttpStatusCode.OK, new ApiResult(result, "Success"), new JsonMediaTypeFormatter());
            else if (result == 2)
                return Request.CreateResponse<ApiResult>(HttpStatusCode.BadRequest, new ApiResult(result, "Wrong Username/Password"), new JsonMediaTypeFormatter());
            else
                return Request.CreateResponse<ApiResult>(HttpStatusCode.InternalServerError, new ApiResult(result, "Server Error"), new JsonMediaTypeFormatter());
        }

        [HttpGet]
        public HttpResponseMessage GetAllUser()
        {
            try{
                IList<User> users = UserRepo.Instance.getAll();
                return Request.CreateResponse<IList<User>>(HttpStatusCode.OK, users, new JsonMediaTypeFormatter());
            }
            catch(Exception e)
                return Request.CreateResponse<ApiResult>(HttpStatusCode.InternalServerError, new ApiResult(1, e.Message), new JsonMediaTypeFormatter());
        }


        // GET api/<ValuesController>/5

    }
}
