using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Services
{
    public class VehicleDetailsService : IVehicleDetailservice
    {
        private readonly ICrud<VehicleDetails, IdDTO> _VehicleDetailsRepo;
        private readonly IImageRepo<VehicleDetails, VehicleFormModel> _imageRepo;


        public VehicleDetailsService(ICrud<VehicleDetails, IdDTO> VehicleDetailsRepo, IImageRepo<VehicleDetails, VehicleFormModel> imageRepo)
        {
            _VehicleDetailsRepo = VehicleDetailsRepo;
            _imageRepo = imageRepo;
        }

        public async Task<List<VehicleDetails>?> Add_VehicleDetails(List<VehicleDetails> VehicleDetails)
        {

            List<VehicleDetails> addedVehicleDetails = new List<VehicleDetails>();

            var VehicleDetailsMaster = await _VehicleDetailsRepo.GetAll();

            foreach (var vehicleDetails in VehicleDetails)
            {

                Console.WriteLine(VehicleDetails);

                var myVehicleDetails = await _VehicleDetailsRepo.Add(vehicleDetails);

                if (myVehicleDetails != null)
                {
                    addedVehicleDetails.Add(myVehicleDetails);
                }

            }
            return addedVehicleDetails;

        }

        public async Task<List<VehicleDetails>?> Get_All_VehicleDetails()
        {
            var VehicleDetails = await _VehicleDetailsRepo.GetAll();
            return VehicleDetails;

        }

        public async Task<VehicleDetails> PostImage([FromForm] VehicleFormModel vehicleFormModel)
        {
            if (vehicleFormModel == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _imageRepo.PostImage(vehicleFormModel);
            if (item == null)
            {
                return null;
            }
            return item;
        }
    }
}
