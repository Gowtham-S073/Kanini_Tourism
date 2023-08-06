using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripBooking.Models;
using TripBooking.Interfaces;
using TripBooking.Services;
using TripBooking.Exceptions;
using TripBooking.Models.DTO;

namespace TripBooking.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _HotelService;


        public HotelController(IHotelService HotelService)
        {
            _HotelService = HotelService;
        }

        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<Hotel>> Add_Hotel(Hotel newHotel)
        {
            /* try
             {*/
            /* if (HotelMaster.Id <=0)
                 throw new InvalidPrimaryID();*/
            var myHotel = await _HotelService.Add_Hotel(newHotel);
            if (myHotel != null)
                return Created("Hotel created Successfully", myHotel);
            return BadRequest(new Error(1, $"Hotel {newHotel.Id} is Present already"));
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


        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<Hotel>>> Get_All_Hotel()
        {
            var myHotel = await _HotelService.Get_All_Hotel();
            if (myHotel?.Count > 0)
                return Ok(myHotel);
            return BadRequest(new Error(10, "No Hotel are Existing"));
        }

        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<Hotel>> View_Hotel(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid Hotel ID"));
                var myHotel = await _HotelService.View_Hotel(idDTO);
                if (myHotel != null)
                    return Created("Hotel", myHotel);
                return BadRequest(new Error(9, $"There is no Hotel present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<Hotel>> PostHotelDetails([FromForm] HotelFormModule hotelFormModule)
        {
            try
            {
                var createdHotel = await _HotelService.PostImage(hotelFormModule);
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
