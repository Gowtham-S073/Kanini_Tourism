using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using TripBooking.Repos;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using NuGet.Packaging;

namespace TripBooking.Services
{
    public class PackageService: IPackageService
    {
        private readonly ICrud<Package, IdDTO> _packageMasterRepo;
        private readonly ICrud<Place, IdDTO> _placeRepository;
        private readonly ICrud<PackageDetails, IdDTO> _PackageDetails;
        private readonly ICrud<Hotel, IdDTO> _hotelRepository;
        private readonly ICrud<Vehicle, IdDTO> _vehicleMasterRepo;
        private readonly ICrud<VehicleDetails, IdDTO> _VehicleDetailsRepo;
        private readonly IImageRepo<Package, PackageFormModel> _imageRepo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PackageService(ICrud<Package, IdDTO> PackageMasterRepo,
            ICrud<Place, IdDTO> placemasterRepo,ICrud<PackageDetails, IdDTO> packageDetailsMasterRepo
            , ICrud<Hotel, IdDTO> hotelMasterRepository, ICrud<Vehicle, IdDTO> vehicleMasterRepo,
            ICrud<VehicleDetails, IdDTO> VehicleDetailsRepo, 
            IImageRepo<Package, PackageFormModel> imageRepo,IWebHostEnvironment hostEnvironment)
        {
            _packageMasterRepo = PackageMasterRepo;
            _placeRepository = placemasterRepo;
            _PackageDetails = packageDetailsMasterRepo;
            _hotelRepository = hotelMasterRepository;
            _vehicleMasterRepo = vehicleMasterRepo;
            _VehicleDetailsRepo = VehicleDetailsRepo;
            _imageRepo = imageRepo;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<Package?> Add_PackageDetails(Package PackageMaster)
        {
            var packageMastertable = await _packageMasterRepo.GetAll();
            var newpackageMaster = packageMastertable?.SingleOrDefault(h => h.Id == PackageMaster.Id);
            if (newpackageMaster == null)
            {
                var myPackage = await _packageMasterRepo.Add(PackageMaster);
                if (myPackage != null)
                    return myPackage;
            }
            return null;

        }
        public async Task<List<Package>?> Get_All_PackageDetails()
        {
            var images = await _packageMasterRepo.GetAll();
            if (images == null)
            {
                return null;
            }

            var imageList = new List<Package>();
            foreach (var image in images)
            {
                if (image == null)
                {
                    continue; // Skip this iteration and move to the next image in the loop
                }

                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploadsFolder, image.Imagepath);

                var imageBytes = System.IO.File.ReadAllBytes(filePath);
                var tourData = new Package
                {
                    Id = image.Id,
                    PackagePrice = image.PackagePrice,
                    PackageName = image.PackageName,
                    TravelAgentId = image.TravelAgentId,
                    Region = image.Region,
                    Imagepath = Convert.ToBase64String(imageBytes)
                };
                imageList.Add(tourData);
            }
            return imageList;
        }


        public async Task<Package?> View_Package(IdDTO idDTO)
        {
            var packageMaster = await _packageMasterRepo.GetValue(idDTO);
            return packageMaster;
        }

        public async Task<Package> PostDashboardImage([FromForm] PackageFormModel packageFormModel)
        {
            if (packageFormModel == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _imageRepo.PostImage(packageFormModel);
            if (item == null)
            {
                return null;
            }
            return item;
        }



       

        public async Task<PackageDTO?> Get_Package_Details(IdDTO id)
        {
            var placeData = await _placeRepository.GetAll();
            var packageMasterData = await _packageMasterRepo.GetAll();
            var packageDetailsData = await _PackageDetails.GetAll();
            var hotelMasterData = await _hotelRepository.GetAll();
            var vehicleMasterData = await _vehicleMasterRepo.GetAll();
            var VehicleDetailsData = await _VehicleDetailsRepo.GetAll();

            var places = (from pd in packageDetailsData
                          join pl in placeData on pd.PlaceId equals pl.Id
                          where pd.PackageId == id.IdInt
                          select pl).Distinct().ToList();

            var vehiclesGroupedByPlace = (from vd in VehicleDetailsData
                                          join vm in vehicleMasterData on vd.VehicleId equals vm.Id
                                          join pl in placeData on vd.PlaceId equals pl.Id
                                          where places.Any(p => p.Id == pl.Id) // Filter vehicles for places linked to the package
                                          group new { vd, vm } by pl into g
                                          select new
                                          {
                                              PlaceId = g.Key.Id,
                                              Vehicles = g.Select(async item => new VehicleDTO
                                              {
                                                  VehicleDetailsId = item.vd.VehicleId,
                                                  CarPrice = item.vd.CarPrice,
                                                  VehicleName = item.vm.VehicleName,
                                                  NumberOfSeats = item.vm.NumberOfSeats,
                                                  VehicleImagepath = await getImage(item.vd.VehicleImagepath),
                                              }).ToList()
                                          }).ToList();

            var result = (from pm in packageMasterData
                          where pm.Id == id.IdInt
                          select new PackageDTO
                          {
                              PackageName = pm.PackageName,
                              PackagePrice = pm.PackagePrice,
                              TravelAgentId = pm.TravelAgentId,
                              Region = pm.Region,
                              Imagepath = pm.Imagepath,

                              placeList = (from pm1 in packageMasterData
                                           join pd in packageDetailsData on pm1.Id equals pd.PackageId
                                           join pl in placeData on pd.PlaceId equals pl.Id
                                           where pm1.Id == id.IdInt
                                           select new PlaceDTO
                                           {
                                               placeId = pl.Id,
                                               PlaceName = pl.PlaceName,
                                               DayNumber = pd.DayNumber,
                                               PlaceImagepath=pd.PlaceImagepath,
                                               HotelList = (from hm in hotelMasterData
                                                            where hm.PlaceId == pl.Id
                                                            select new HotelDTO
                                                            {
                                                                HotelId = hm.Id,
                                                                HotelName = hm.HotelName,
                                                                HotelImagepath = hm.HotelImagepath, // Just assign the path here
                                                            }).ToList(),
                                           }).ToList(),
                          }).FirstOrDefault();

            if (result != null && !string.IsNullOrEmpty(result.Imagepath))
            {
                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploadsFolder, result.Imagepath);

                // Check if the image file exists
                if (File.Exists(filePath))
                {
                    var imageBytes = await File.ReadAllBytesAsync(filePath);
                    result.Imagepath = Convert.ToBase64String(imageBytes);
                } // Calculate the image data for the package
            }

            // Populate the VechileList for each place
            if (result != null && result.placeList != null)
            {
                foreach (var place in result.placeList)
                {
                    place.PlaceImagepath = await getImage(place.PlaceImagepath);

                    foreach (var hotel in place.HotelList)
                    {
                        hotel.HotelImagepath = await getImage(hotel.HotelImagepath);
                    }
                }

                foreach (var place in result.placeList)
                {
                    var vehiclesForPlace = vehiclesGroupedByPlace.FirstOrDefault(g => g.PlaceId == place.placeId)?.Vehicles;
                    if (vehiclesForPlace != null)
                    {
                        place.VechileList = new List<VehicleDTO>();
                        foreach (var vehicleTask in vehiclesForPlace)
                        {
                            var vehicle = await vehicleTask; // Await the task to get the VehicleDTO
                            place.VechileList.Add(vehicle); // Add the VehicleDTO to VechileList
                        }
                    }
                }
            }


            return result;
        }

        [NonAction]
        public async Task<string?> getImage(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                // Handle the case where the path is null or empty
                return null;
            }
            var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
            var filePath = Path.Combine(uploadsFolder, path);

            // Check if the image file exists
            if (File.Exists(filePath))
            {
                var imageBytes = await File.ReadAllBytesAsync(filePath);
                string image = Convert.ToBase64String(imageBytes);
                return image;
            }
            return null;
        }


    }
}
