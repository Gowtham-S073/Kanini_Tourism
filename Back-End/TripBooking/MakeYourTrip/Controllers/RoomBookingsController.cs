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
    public class RoomBookingsController : ControllerBase
    {
        private readonly IRoomBookingService _RoomBookingService;


        public RoomBookingsController(IRoomBookingService RoomBookingService)
        {
            _RoomBookingService = RoomBookingService;
        }

        [ProducesResponseType(typeof(RoomBooking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<RoomBooking>> Add_RoomBooking(RoomBooking newHotel)
        {
            /* try
             {*/
            /* if (RoomBooking.Id <=0)
                 throw new InvalidPrimaryID();*/
            var myRoomBooking = await _RoomBookingService.Add_RoomBooking(newHotel);
            if (myRoomBooking != null)
                return Created("RoomBooking created Successfully", myRoomBooking);
            return BadRequest(new Error(1, $"RoomBooking {newHotel.Id} is Present already"));
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


        [ProducesResponseType(typeof(RoomBooking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<RoomBooking>>> Get_all_RoomBooking()
        {
            var myRoomBookings = await _RoomBookingService.Get_all_RoomBooking();
            if (myRoomBookings?.Count > 0)
                return Ok(myRoomBookings);
            return BadRequest(new Error(10, "No RoomBookings are Existing"));
        }

        [ProducesResponseType(typeof(RoomBooking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<RoomBooking>> View_RoomBooking(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid RoomBooking ID"));
                var myRoomBooking = await _RoomBookingService.View_RoomBooking(idDTO);
                if (myRoomBooking != null)
                    return Created("RoomBooking", myRoomBooking);
                return BadRequest(new Error(9, $"There is no RoomBooking present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
