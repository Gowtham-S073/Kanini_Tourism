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
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryService _GalleryService;


        public GalleryController(IGalleryService GalleryService)
        {
            _GalleryService = GalleryService;
        }

        [ProducesResponseType(typeof(Gallery), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<Gallery>> Add_Gallery(Gallery newplace)
        {
            /* try
             {*/
            /* if (additionalCategoryMaster.Id <=0)
                 throw new InvalidPrimaryID();*/
            var myGallery = await _GalleryService.Add_Gallery(newplace);
            if (myGallery != null)
                return Created("Gallery created Successfully", myGallery);
            return BadRequest(new Error(1, $"Gallery {newplace.Id} is Present already"));
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

        [ProducesResponseType(typeof(Gallery), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<Gallery>>> Get_All_Gallery()
        {
            var myGallerys = await _GalleryService.Get_All_Gallery();
            if (myGallerys?.Count > 0)
                return Ok(myGallerys);
            return BadRequest(new Error(10, "No Gallery are Existing"));
        }

        [ProducesResponseType(typeof(Gallery), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<Gallery>> View_Gallery(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid Gallery ID"));
                var myGallery = await _GalleryService.View_Gallery(idDTO);
                if (myGallery != null)
                    return Created("Gallery", myGallery);
                return BadRequest(new Error(9, $"There is no Gallery present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [ProducesResponseType(typeof(Gallery), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<Gallery>> PostGalleryImage([FromForm] GalleryFormModule GalleryFormModule)
        {
            try
            {
                var createdHotel = await _GalleryService.PostImage(GalleryFormModule);
                return Ok(createdHotel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
