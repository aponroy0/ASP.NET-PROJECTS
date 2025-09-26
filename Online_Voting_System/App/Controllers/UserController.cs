using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("registration")] // API NO - 1

        public HttpResponseMessage Create(UserDTO u)
        {
            var data = UserService.Create(u);
            try
            {
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Registration Successfull!");

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Registration failed!");

                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }


        }


        [HttpPost]
        [Route("login")] // API NO - 2

        public HttpResponseMessage Login(LoginDTO Log)
        {

            var data = UserService.Login(Log);

            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid email or password.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Login successful");

        }



        // casting vote
        // Here are sending user id and election id . We are sending user id cause we are not using jwt

        [HttpPost]
        [Route("castvote/{id_u}/{id_e}")] // API NO - 3
        public HttpResponseMessage CastVote(int id_u, int id_e, VoteDTO v)
        {
            try
            {
                var cast_vote = UserService.CastVote(id_u, id_e, v);

                if (cast_vote)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Vote casted successfully!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Vote casting failed");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
