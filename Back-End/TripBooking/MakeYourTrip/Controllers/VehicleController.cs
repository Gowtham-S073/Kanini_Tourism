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
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _VehicleService;


        public VehicleController(IVehicleService VehicleMasterService)
        {
            _VehicleService = VehicleMasterService;
        }

        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<Vehicle>> Add_Vehicle(Vehicle newplace)
        {
            /* try
             {*/
            /* if (additionalCategoryMaster.Id <=0)
                 throw new InvalidPrimaryID();*/
            var myVehicleMaster = await _VehicleService.Add_Vehicle(newplace);
            if (myVehicleMaster != null)
                return Created("VehicleMaster created Successfully", myVehicleMaster);
            return BadRequest(new Error(1, $"VehicleMaster {newplace.Id} is Present already"));
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

        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<Vehicle>>> Get_all_VehicleMaster()
        {
            var myVehicleMasters = await _VehicleService.Get_all_VehicleMaster();
            if (myVehicleMasters?.Count > 0)
                return Ok(myVehicleMasters);
            return BadRequest(new Error(10, "No VehicleMaster are Existing"));
        }

        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<Vehicle>> View_VehicleMaster(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid VehicleMaster ID"));
                var myVehicleMaster = await _VehicleService.View_VehicleMaster(idDTO);
                if (myVehicleMaster != null)
                    return Created("VehicleMaster", myVehicleMaster);
                return BadRequest(new Error(9, $"There is no VehicleMaster present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

    }
}
