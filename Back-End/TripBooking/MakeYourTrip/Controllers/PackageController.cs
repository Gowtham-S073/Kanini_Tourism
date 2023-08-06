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
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _PackageService;

        public PackageController(IPackageService PackageService)
        {
            _PackageService = PackageService;
        }

        [ProducesResponseType(typeof(Package), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<Package>> Add_PackageDetails(Package newplace)
        {
            /* try
             {*/
            /* if (additionalCategoryMaster.Id <=0)
                 throw new InvalidPrimaryID();*/
            var myPackage = await _PackageService.Add_PackageDetails(newplace);
            if (myPackage != null)
                return Created("Package created Successfully", myPackage);
            return BadRequest(new Error(1, $"Package {newplace.Id} is Present already"));
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

        [ProducesResponseType(typeof(Package), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<Package>>> Get_All_PackageDetails()
        {
            var myPackage = await _PackageService.Get_All_PackageDetails();
            if (myPackage?.Count > 0)
                return Ok(myPackage);
            return BadRequest(new Error(10, "No PackageDetai are Existing"));
        }

        [ProducesResponseType(typeof(Package), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<Package>> View_Package(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid Package ID"));
                var myPackage = await _PackageService.View_Package(idDTO);
                if (myPackage != null)
                    return Created("Package", myPackage);
                return BadRequest(new Error(9, $"There is no Package present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [ProducesResponseType(typeof(PackageDTO), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<PackageDTO>> Get_Package_Details(IdDTO id)
        {
            var result = await _PackageService.Get_Package_Details(id);
            if(result!= null)
            {
                return Ok(result);
            }
            return BadRequest(new Error(9, $"There is no Package present for the id {id.IdInt}"));

        }

        [ProducesResponseType(typeof(Package), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<Package>> PostPackageImage([FromForm] PackageFormModel packageFormModel)
        {
            try
            {
                var createdHotel = await _PackageService.PostDashboardImage(packageFormModel);
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
