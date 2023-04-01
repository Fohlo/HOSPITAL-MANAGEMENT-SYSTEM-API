using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMS.BLL.Calls;
using SAMS.Models;
using SAMS.Models.CALLS;

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallsController : ControllerBase
    {
        // GET: api/Calls
        [HttpGet]
        [Route("Getspecific")]
        public ErrorMDL Get(string session, int DocEntry)
        {
            try
            {
                var get = CallsBLL.getCall(session, DocEntry);

                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(get)
                };
            }
            catch (Exception ex )
            {
                return new ErrorMDL
                {
                    Error = ex.Message
                };
            }
        }
        [HttpGet]
        public ErrorMDL Get(string session)
        {
            try
            {
                var get = CallsBLL.getCalls(session);

                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(get)
                };
            }
            catch (Exception ex)
            {
                return new ErrorMDL
                {
                    Error = ex.Message
                };
            }
        }

        [HttpGet]
        [Route("GetByID")]
        public ErrorMDL Get(string session, string PatientID)
        {
            try
            {
                var get = CallsBLL.getCallByID(session, PatientID);

                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(get)
                };
            }
            catch (Exception ex)
            {
                return new ErrorMDL
                {
                    Error = ex.Message
                };
            }
        }


        // POST: api/Calls
        [HttpPost]
        public ErrorMDL Post(string session, AddCallsMDL call)
        {
            try
            {
                var Post = CallsBLL.CreateCall(session, call);
                return new ErrorMDL
                {
                    Success = "Document Has been Created"
                };
            }
            catch (Exception ex)
            {
                return new ErrorMDL
                {
                    Error = ex.Message
                };
            }
        }

        // PUT: api/Calls/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
