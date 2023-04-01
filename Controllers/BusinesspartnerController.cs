using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMS.BLL.BusinessPartner;
using SAMS.Models;
using SAMS.Models.Business_Partner;

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinesspartnerController : ControllerBase
    {
        // GET: api/Businesspartner
        [HttpGet]
        public ErrorMDL  Get(string session, string Cardcode)
        {
            try
            {
                var clause = "BusinessPartners?$filter = CardCode eq '" + Cardcode + "'";
                var get = BPBLL.getBusinessPartner(session,clause);

                if (get.Count>0)
                {
                    return new ErrorMDL
                    {
                        Success = JsonConvert.SerializeObject(get)
                    };
                }
                else
                {
                    return new ErrorMDL
                    {

                    };
                }
            }
            catch (Exception ex)
            {
                return new ErrorMDL
                {
                    Error = ex.Message
                };
            }
            
        }

        // GET: api/Businesspartner/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Businesspartner
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Businesspartner/5
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
