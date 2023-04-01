using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMS.BLL.Floors;
using SAMS.Models;
using SAMS.Models.Floor;


namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorsController : ControllerBase
    {
        // GET: api/Floors
        [HttpGet]
        public ErrorMDL Get(string session)
        {
            try
            {
                var getfloors = FloorBLL.GetFloors(session);
                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(getfloors)
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

        // GET: api/Floors/5
        [HttpGet]
        [Route("GetFloorByID")]
        public ErrorMDL Get(string session, int FloorID)
        {
            try
            {
                var getfloor = FloorBLL.GetFloor(session, FloorID);
                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(getfloor)
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

        // POST: api/Floors
        [HttpPost]
        public ErrorMDL Post( string session, int floorid, EditFloor floor)
        {
            try
            {
                var data = FloorBLL.EditRoom(session, floorid, floor);

                return new ErrorMDL
                {
                    Success = "Room Has Been Assigned"
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

        // PUT: api/Floors/5
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
