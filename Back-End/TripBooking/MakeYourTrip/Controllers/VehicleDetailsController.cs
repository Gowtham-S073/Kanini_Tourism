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
using TripBooking.Services;

namespace TripBooking.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleDetailsController : ControllerBase
    {
        private readonly IVehicleDetailservice _VehicleDetailservice;

        public VehicleDetailsController(IVehicleDetailservice VehicleDetailservice)
        {
            _VehicleDetailservice = VehicleDetailservice;
        }

        [ProducesResponseType(typeof(VehicleDetails), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<List<VehicleDetails>>> Add_VehicleDetails(List<VehicleDetails> VehicleDetails)
        {

            try
            {
                var myVehicleDetails = await _VehicleDetailservice.Add_VehicleDetails(VehicleDetails);

                if (myVehicleDetails != null)
                {
                    return Created("VehicleDetails created Successfully", myVehicleDetails);
                }

                return BadRequest(new Error(1, "No VehicleDetails were added."));
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

        [ProducesResponseType(typeof(VehicleDetails), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<VehicleDetails>>> Get_All_VehicleDetails()
        {
            var myVehicleDetails = await _VehicleDetailservice.Get_All_VehicleDetails();
            if (myVehicleDetails?.Count > 0)
                return Ok(myVehicleDetails);
            return BadRequest(new Error(10, "No VehicleDetails are Existing"));
        }

        [ProducesResponseType(typeof(PackageDetails), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<PackageDetails>> PostPlaceMaster([FromForm] VehicleFormModel vehicleFormModel)
        {
            try
            {
                var createdHotel = await _VehicleDetailservice.PostImage(vehicleFormModel);
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
