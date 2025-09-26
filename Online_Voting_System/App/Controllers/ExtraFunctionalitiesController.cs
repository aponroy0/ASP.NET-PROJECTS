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

    public class ExtraFunctionalitiesController : ApiController
    {

        [Route("search")]
        [HttpGet]

        public HttpResponseMessage SearchElection (string search = "")
        {
            try
            {
                var searchResults = ElectionSearchService.Search(search);
                if(searchResults != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, searchResults);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                   "No elections found matching the search criteria.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [Route("report/{id_e}")]
        [HttpGet]

        public HttpResponseMessage Report(int id_e)
        {
            try
            {
                var reportChart = ReportService.Report(id_e);
                if (reportChart != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, reportChart);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No election reports found!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }


    }
}
