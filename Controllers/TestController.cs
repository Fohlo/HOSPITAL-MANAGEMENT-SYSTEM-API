using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMS.BLL.Calls;
using SAMS.BLL.Test;
using SAMS.Models;
using SAMS.Models.Test;

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("Getspecific")]
        public ErrorMDL Getspec(string session, int DocEntry)
        {
            try
            {
                var clause = "test?$filter = U_CallDoc eq "+DocEntry+"";
                var get = TestBLL.GetTests(session, clause);
                var result = new TestMDL();
                if (get.Count !=0)
                {
                    result = get[0];
                }

                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(result)
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
        [Route("ByDate")]
        public ErrorMDL Get(string session)
        {
            try
            {
                string clause = "";
                var get = TestBLL.GetTests(session, clause);

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
        [Route("Create")]
        public ErrorMDL Create(string session, int DocEntry)
        {
            try
            {
                var get = TestBLL.CreateTest(session, DocEntry);

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
        [Route("PatchTest")]
        public ErrorMDL PatchTest(string session, int DocEntry, string result)
        {
            try
            {
                var get = TestBLL.testResults(session, DocEntry, result);
               
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

        // POST: api/Test
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Test/5
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
