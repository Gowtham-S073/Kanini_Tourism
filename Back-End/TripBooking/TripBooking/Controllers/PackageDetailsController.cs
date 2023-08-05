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
using TripBooking.Services;
using TripBooking.Models.DTO;

namespace TripBooking.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PackageDetailsController : ControllerBase
    {
        private readonly IPackageDetailsService _PackageDetailsService;

        public PackageDetailsController(IPackageDetailsService PackageDetailsService)
        {
            _PackageDetailsService = PackageDetailsService;
        }

        [ProducesResponseType(typeof(PackageDetails), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<List<PackageDetails>>> Add_PackageDetails(List<PackageDetails> PackageDetails)
        {

            try
            {
                var myPackageDetails = await _PackageDetailsService.Add_PackageDetails(PackageDetails);

                if (myPackageDetails!= null)
                {
                    return Created("PackageDetails created Successfully", myPackageDetails);
                }

                return BadRequest(new Error(1, "No PackageDetails were added."));
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

        [ProducesResponseType(typeof(PackageDetails), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<PackageDetails>>> Get_All_PackageDetails()
        {
            var myPackageDetailss = await _PackageDetailsService.Get_All_PackageDetails();
            if (myPackageDetailss?.Count > 0)
                return Ok(myPackageDetailss);
            return BadRequest(new Error(10, "No PackageDetails are Existing"));
        }


        [ProducesResponseType(typeof(PackageDetails), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<PackageDetails>> PostPlace([FromForm] PlaceFormModel placeFormModel)
        {
            try
            {
                var createdHotel = await _PackageDetailsService.PostImage(placeFormModel);
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
