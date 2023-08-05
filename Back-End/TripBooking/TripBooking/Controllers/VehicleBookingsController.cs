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
    public class VehicleBookingsController : ControllerBase
    {
        private readonly IVehicleBookingService _VehicleBookingService;


        public VehicleBookingsController(IVehicleBookingService VehicleBookingService)
        {
            _VehicleBookingService = VehicleBookingService;
        }

        [ProducesResponseType(typeof(VehicleBooking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<VehicleBooking>> Add_VehicleBooking(VehicleBooking newHotel)
        {
            /* try
             {*/
            /* if (VehicleBooking.Id <=0)
                 throw new InvalidPrimaryID();*/
            var myVehicleBooking = await _VehicleBookingService.Add_VehicleBooking(newHotel);
            if (myVehicleBooking != null)
                return Created("VehicleBooking created Successfully", myVehicleBooking);
            return BadRequest(new Error(1, $"VehicleBooking {newHotel.Id} is Present already"));
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


        [ProducesResponseType(typeof(VehicleBooking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<VehicleBooking>>> Get_All_VehicleBooking()
        {
            var myVehicleBookings = await _VehicleBookingService.Get_All_VehicleBooking();
            if (myVehicleBookings?.Count > 0)
                return Ok(myVehicleBookings);
            return BadRequest(new Error(10, "No VehicleBookings are Existing"));
        }

        [ProducesResponseType(typeof(VehicleBooking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<VehicleBooking>> View_VehicleBooking(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid VehicleBooking ID"));
                var myVehicleBooking = await _VehicleBookingService.View_VehicleBooking(idDTO);
                if (myVehicleBooking != null)
                    return Created("VehicleBooking", myVehicleBooking);
                return BadRequest(new Error(9, $"There is no VehicleBooking present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
