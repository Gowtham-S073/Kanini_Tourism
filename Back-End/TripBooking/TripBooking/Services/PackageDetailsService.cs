using TripBooking.Interfaces;
using TripBooking.Models;
using TripBooking.Models.DTO;
using TripBooking.Repos;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Services
{
    public class PackageDetailsService: IPackageDetailsService
    {
        private readonly ICrud<PackageDetails, IdDTO> _PackageDetails;
        private readonly IImageRepo<PackageDetails, PlaceFormModel> _imageRepo;


        public PackageDetailsService(ICrud<PackageDetails, IdDTO> PackageDetailsMasterRepo, IImageRepo<PackageDetails, PlaceFormModel> imageRepo)
        {
            _PackageDetails = PackageDetailsMasterRepo;
            _imageRepo = imageRepo;
        }

        public async Task<List<PackageDetails>?> Add_PackageDetails(List<PackageDetails> PackageDetails)
        {

            List<PackageDetails> addedPackageDetails = new List<PackageDetails>();

            var PackageDetailsMasters = await _PackageDetails.GetAll();

            foreach (var packageDetails in PackageDetails)
            {

                Console.WriteLine(packageDetails);

                var myPackageDetails = await _PackageDetails.Add(packageDetails);

                if (myPackageDetails != null)
                {
                    addedPackageDetails.Add(myPackageDetails);
                }

            }
            return addedPackageDetails;

        }

        public async Task<List<PackageDetails>?> Get_All_PackageDetails()
        {
            var PackageDetails = await _PackageDetails.GetAll();
            return PackageDetails;

        }

        public async Task<PackageDetails> PostImage([FromForm] PlaceFormModel placeFormModel)
        {
            if (placeFormModel == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _imageRepo.PostImage(placeFormModel);
            if (item == null)
            {
                return null;
            }
            return item;
        }
    }
}
