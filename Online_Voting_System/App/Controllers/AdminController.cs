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
    [RoutePrefix("api/admin")]

    public class AdminController : ApiController
    {

        [HttpPost]
        [Route("addelection")] // API NO - 1

        public HttpResponseMessage Create(ElectionDTO e)
        {
            var data = ElectionService.Create(e);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, "New Election Created!");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }

        }



        [HttpGet]
        [Route("listelection")] // API NO - 2
        public HttpResponseMessage Get()
        {
            var data = ElectionService.Get();
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpGet]
        [Route("electionbyid/{id}")] // API NO - 3
        public HttpResponseMessage GetbyId(int id)
        {
            var data = ElectionService.GetById(id);

            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }




        [HttpPut]
        [Route("updateelection")] // API NO - 4
        public HttpResponseMessage Update(ElectionUpdateDTO e)
        {
            var success = ElectionService.Update(e);
            if (success)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Election updated successfully");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Update failed");

            }
        }

        [HttpDelete]
        [Route("deleteelection/{id}")] // API NO - 5
        public HttpResponseMessage Delete (int id)
        {
            var deleted = ElectionService.Delete(id);

            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, "ELection deleted!");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Deletion failed");
            }
        }


        // Adding candidates here for an specific election id.

        [HttpPost]
        [Route("addcandidate/{id}")] // API NO - 6

        public HttpResponseMessage AddCandidate(int id, CandidateDTO c)
        {
            var deleted = CandidateService.AddCandidiate(id, c);
            if (deleted)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Candidate added!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Candidate addition failed");
            }


        }


        // Showing the cadidate list of a specific election id

        [HttpGet]
        [Route("candidatelist/{id}")] // API NO - 7

        public HttpResponseMessage CandidateListByElection(int id)
        {
            try
            {
                var listOfcandidate = CandidateService.ListCandidateForAnElection(id);
                if (listOfcandidate != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, listOfcandidate);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No candidates for this election id");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }



        }


        // Deleting a candidate of a specific election id.
        [HttpDelete]
        [Route("deletecandidate/{id_e}/{id_c}")] // API NO - 8
        public HttpResponseMessage DeleteCandidate(int id_e, int id_c)
        {
            try
            {
                var del_candidate = CandidateService.DeleteCandidate(id_e, id_c);

                if (del_candidate)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Candidate deleted successfully!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Candidate deletion failed");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




        // This controller handles the vote count for candidates of an election id
        [HttpGet]
        [Route("votecount/{id_e}")] // API NO - 9

        public HttpResponseMessage VoteCounter (int id_e)
        {
            try
            {
                var results = CandidateService.CandidateVoteCounter(id_e);
                if(results != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, results);

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No candidates found for this election");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }





    }
}
