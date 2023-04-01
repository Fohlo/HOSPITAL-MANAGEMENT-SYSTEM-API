using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMS.BLL.Request;
using SAMS.Models;
using SAMS.Models.Request;

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        // GET: api/Request
        [HttpGet]
        public ErrorMDL Get(string session)
        {
            try
            {
                var clause = "REQUEST?$filter = U_Status eq 'Open'";
                return new ErrorMDL { Success = JsonConvert.SerializeObject(RequestBLL.GetRequest(session, clause)) };
            }
            catch (Exception ex)
            {
                return new ErrorMDL
                {
                    Error = ex.Message
                };
            }
        }

        // POST: api/Request
        [HttpPost]
        public ErrorMDL Post(PostrequestMDL request, string session)
        {
            try
            {
                return new ErrorMDL { Success = JsonConvert.SerializeObject(RequestBLL.Post(session, request))};
            }
            catch (Exception ex)
            {
                return new ErrorMDL
                {
                    Error = ex.Message
                };
            }
        }

        [HttpPost]
        [Route("Approve")]
        public ErrorMDL Patch(PatchrequestMDL request, string session)
        {
            try
            {
                return new ErrorMDL { Success = JsonConvert.SerializeObject(RequestBLL.Patch(session, request)) };
            }
            catch (Exception ex)
            {
                return new ErrorMDL
                {
                    Error = ex.Message
                };
            }
        }

    }
}
