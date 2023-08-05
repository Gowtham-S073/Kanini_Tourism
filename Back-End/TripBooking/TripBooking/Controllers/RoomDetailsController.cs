using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripBooking.Models;
using TripBooking.Exceptions;
using TripBooking.Interfaces;
using TripBooking.Models.DTO;

namespace TripBooking.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomDetailsController : ControllerBase
    {
        private readonly IRoomDetailsService _RoomDetailsService;

        public RoomDetailsController(IRoomDetailsService RoomDetailsService)
        {
            _RoomDetailsService = RoomDetailsService;
        }

        [ProducesResponseType(typeof(RoomDetails), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<List<RoomDetails>>> Add_RoomDetails(List<RoomDetails> RoomDetails)
        {

            try
            {
                var myRoomDetails = await _RoomDetailsService.Add_RoomDetails(RoomDetails);

                if (myRoomDetails != null)
                {
                    return Created("RoomDetails created Successfully", myRoomDetails);
                }

                return BadRequest(new Error(1, "No RoomDetails were added."));
            }
            catch (InvalidPrimaryID ip)
            {
                return BadRequest(new Error(2, ip.Message));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }

        }

        [ProducesResponseType(typeof(RoomDetails), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<RoomDetails>>> Get_All_RoomDetails()
        {
            var myRoomDetails = await _RoomDetailsService.Get_All_RoomDetails();
            if (myRoomDetails?.Count > 0)
                return Ok(myRoomDetails);
            return BadRequest(new Error(10, "No RoomDetails are Existing"));
        }

        [ProducesResponseType(typeof(RoomDetails), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<List<RoomdetailsDTO>>> getRoomDetailsByHotel(IdDTO id)
        {
            var myRoomdetails = await _RoomDetailsService.getRoomDetailsByHotel(id);
            if (myRoomdetails?.Count > 0)
                return Ok(myRoomdetails);
            return BadRequest(new Error(10, "No RoomDetails are Existing"));
        }
    }
}
