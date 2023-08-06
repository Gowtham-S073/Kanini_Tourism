using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripBooking.Models;
using TripBooking.Interfaces;

namespace TripBooking.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _RoomTypeService;


        public RoomTypeController(IRoomTypeService RoomTypeService)
        {
            _RoomTypeService = RoomTypeService;
        }

        [ProducesResponseType(typeof(RoomType), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<RoomType>> Add_RoomType(RoomType newplace)
        {
            /* try
             {*/
            /* if (additionalCategoryMaster.Id <=0)
                 throw new InvalidPrimaryID();*/
            var myRoomType = await _RoomTypeService.Add_RoomType(newplace);
            if (myRoomType != null)
                return Created("RoomType created Successfully", myRoomType);
            return BadRequest(new Error(1, $"RoomType {newplace.Id} is Present already"));
            /*}
            catch (InvalidPrimaryID ip)
            {
                return BadRequest(new Error(2, ip.Message));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }*/
        }

        [ProducesResponseType(typeof(RoomType), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<RoomType>>> Get_all_RoomType()
        {
            var myRoomTypes = await _RoomTypeService.Get_all_RoomType();
            if (myRoomTypes?.Count > 0)
                return Ok(myRoomTypes);
            return BadRequest(new Error(10, "No RoomType are Existing"));
        }
    }
}
