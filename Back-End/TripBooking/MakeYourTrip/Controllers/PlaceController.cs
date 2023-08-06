using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripBooking.Models;
using TripBooking.Interfaces;
using TripBooking.Exceptions;
using TripBooking.Models.DTO;
using TripBooking.Services;

namespace TripBooking.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _PlaceService;


        public PlaceController(IPlaceService PlaceService)
        {
            _PlaceService = PlaceService;
        }

        [ProducesResponseType(typeof(Place), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<Place>> Add_Place(Place newplace)
        {
           /* try
            {*/
                /* if (additionalCategoryMaster.Id <=0)
                     throw new InvalidPrimaryID();*/
                var myPlace = await _PlaceService.Add_Place(newplace);
                if (myPlace != null)
                    return Created("AdditionalCategory created Successfully", myPlace);
                return BadRequest(new Error(1, $"AdditionalCategory {newplace.Id} is Present already"));
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

        [ProducesResponseType(typeof(Place), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public  async Task<ActionResult<List<Place>>> Get_All_Place()
        {
            var myPlace = await _PlaceService.Get_All_Place();
            if (myPlace?.Count > 0)
                return Ok(myPlace);
            return BadRequest(new Error(10, "No AdditionalCategory are Existing"));
        }

        [ProducesResponseType(typeof(Place), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete]

        public async Task<ActionResult<Place>> Delete_Place(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid Place ID"));
                var myPlace = await _PlaceService.Delete_Place(idDTO);
                if (myPlace != null)
                    return Created("Place deleted Successfully", myPlace);
                return BadRequest(new Error(5, $"There is no Place present for the id {idDTO.IdInt}"));
            }
            
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

       
    }
}
