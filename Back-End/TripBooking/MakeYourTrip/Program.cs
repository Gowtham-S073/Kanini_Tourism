using TripBooking.Interfaces;
using TripBooking.Models.DTO;
using TripBooking.Models;
using TripBooking.Repos;
using TripBooking.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenGenerate, TokenService>();
builder.Services.AddScoped<ICrud<User, UserDTO>, UserRepository>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<ICrud<Place, IdDTO>, PlaceRepository>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<ICrud<Hotel, IdDTO>, HotelRepository>();
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<ICrud<Package, IdDTO>, PackageRepository>();
builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
builder.Services.AddScoped<ICrud<RoomType, IdDTO>, RoomTypeRepository>();
builder.Services.AddScoped<IRoomDetailsService, RoomDetailsService>();
builder.Services.AddScoped<ICrud<RoomDetails, IdDTO>, RoomDetailsRepository>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<ICrud<Vehicle, IdDTO>, VehicleRepository>();
builder.Services.AddScoped<IVehicleDetailservice, VehicleDetailsService>();
builder.Services.AddScoped<ICrud<VehicleDetails, IdDTO>, VehicleDetailsRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICrud<Booking, IdDTO>, BookingRepository>();
builder.Services.AddScoped<IVehicleBookingService, VehicleBookingService>();
builder.Services.AddScoped<ICrud<VehicleBooking, IdDTO>, VehicleBookingRepository>();
builder.Services.AddScoped<IRoomBookingService, RoomBookingService>();
builder.Services.AddScoped<ICrud<RoomBooking, IdDTO>, RoomBookingRepository>();
builder.Services.AddScoped<IPackageDetailsService, PackageDetailsService>();
builder.Services.AddScoped<ICrud<PackageDetails, IdDTO>, PackageDetailsRepository>();
builder.Services.AddScoped<IImageRepo<Package, PackageFormModel>, PackageRepository>();
builder.Services.AddScoped<IImageRepo<PackageDetails, PlaceFormModel>, PackageDetailsRepository>();
builder.Services.AddScoped<IImageRepo<VehicleDetails, VehicleFormModel>, VehicleDetailsRepository>();
builder.Services.AddScoped<IImageRepo<Hotel, HotelFormModule>, HotelRepository>();
builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<ICrud<Gallery, IdDTO>, GalleryRepository>();
builder.Services.AddScoped<IImageRepo<Gallery, GalleryFormModule>, GalleryRepository>();



















builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                           new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "Bearer"
                                 }
                             },
                             new string[] {}

                     }
                 });
});



builder.Services.AddDbContext<TripBookingContext>(
    optionsAction: options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(name: "SQLConnection")));

builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AngularCORS", options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AngularCORS");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
