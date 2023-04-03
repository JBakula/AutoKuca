using AutoKucaFinal.DTOs;
using AutoKucaFinal.Models;
using Microsoft.AspNetCore.Hosting;

namespace AutoKucaFinal.Services.CarRepo
{
    public class CarService:ICarService
    {
        private readonly AutoKucaDbContext _context;
        public static IWebHostEnvironment _webHostEnvironment;

        public CarService(AutoKucaDbContext context,IWebHostEnvironment webHostEnvironment) 
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public bool AddCar(CarRequest carRequest)
        {
            var color = _context.Colors.Find(carRequest.ColorId);
            var transmissionType = _context.TransmissionTypes.Find(carRequest.TransmissionTypeId);
            var doors = _context.Doors.Find(carRequest.DoorsId);
            var fuelType = _context.FuelTypes.Find(carRequest.FuelTypeId);
            var model = _context.Models.Find(carRequest.ModelId);

            var newCar = new Car()
            {
                Year = carRequest.Year,
                Price = carRequest.Price,
                NumberOfKilometers = carRequest.NumberOfKilometers,
                Volume = carRequest.Volume,
                HorsePower = carRequest.HorsePower,
                KW = carRequest.KW,
                ColorId = carRequest.ColorId,
                Color = color,
                TransmissionTypeId = carRequest.TransmissionTypeId,
                TransmissionType = transmissionType,
                DoorsId = carRequest.DoorsId,
                Doors = doors,
                FuelTypeId = carRequest.FuelTypeId,
                FuelType = fuelType,
                ModelId = carRequest.ModelId,
                Model = model,
                CoverImage = GenerateCoverImagePath(carRequest.CoverImage),
                CreatedAt = DateTime.Now
            };
            _context.Cars.Add(newCar);
            _context.SaveChanges();

            foreach(var image in carRequest.OtherImages)
            {
                var newImage = new Image()
                {
                    CarId = newCar.CarId,
                    Car = newCar,
                    ImageName = GenerateCoverImagePath(image)
                };
                _context.Images.Add(newImage);
                _context.SaveChanges();
            }
            return true;
        }
        public string GenerateCoverImagePath(IFormFile image)
        {
            try
            {
                string path = _webHostEnvironment.WebRootPath + "\\images\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using(FileStream fileStream = File.Create(path+image.FileName))
                {
                    image.CopyTo(fileStream);
                    fileStream.Flush();
                    return path+image.FileName;
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
        public bool UpdateCar(CarRequest carRequest, int id)
        {
            var car = _context.Cars.Find(id);

            var color = _context.Colors.Find(carRequest.ColorId);
            var transmissionType = _context.TransmissionTypes.Find(carRequest.TransmissionTypeId);
            var doors = _context.Doors.Find(carRequest.DoorsId);
            var fuelType = _context.FuelTypes.Find(carRequest.FuelTypeId);
            var model = _context.Models.Find(carRequest.ModelId);

            if (car.CoverImage != null)
            {
                File.Delete(car.CoverImage);
            }
            if(_context.Images.Where(i => i.CarId == id).Count() > 0)
            {
                foreach(var image in _context.Images.Where(i=>i.CarId == id))
                {
                    File.Delete(image.ImageName);
                    _context.Images.Remove(image);
                }
            }
            car.Year = carRequest.Year;
            car.Price = carRequest.Price;
            car.NumberOfKilometers = carRequest.NumberOfKilometers;
            car.Volume = carRequest.Volume;
            car.HorsePower = carRequest.HorsePower;
            car.KW = carRequest.KW;
            car.CoverImage = GenerateCoverImagePath(carRequest.CoverImage);
            car.ModelId = carRequest.ModelId;
            car.Model = model;
            car.ColorId = carRequest.ColorId;
            car.Color = color;
            car.TransmissionTypeId = carRequest.TransmissionTypeId;
            car.TransmissionType = transmissionType;
            car.FuelTypeId = carRequest.FuelTypeId;
            car.FuelType = fuelType;
            car.DoorsId = carRequest.DoorsId;
            car.Doors = doors;

            _context.SaveChanges();

            foreach(var image in carRequest.OtherImages)
            {
                Image newImage = new Image()
                {
                    ImageName = GenerateCoverImagePath(image),
                    CarId = car.CarId,
                    Car = car
                };
                _context.Images.Add(newImage);
                _context.SaveChanges();
            }
            return true;

        }
        public bool DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                foreach(var image in _context.Images.Where(i=>i.CarId == id)) 
                {
                    _context.Images.Remove(image);
                }
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public CarResponsePaginated GetCars(int page)
        {
            var numberOfCarsPerPage = 4f;
            var numberOfPages = NumberOfPages(numberOfCarsPerPage);

            var cars = _context.Cars
                               .OrderByDescending(c => c.CreatedAt)
                               .Skip((page - 1) * (int)numberOfPages)
                               .Take((int)numberOfCarsPerPage)
                               .Select(c => new
                               {
                                   c.CarId,
                                   c.Model.Brand.BrandName,
                                   c.Model.ModelName,
                                   c.Year,
                                   c.CoverImage,
                                   c.NumberOfKilometers,
                                   c.FuelType.FuelTypeName,
                                   c.Price,
                                   c.CreatedAt
                               })
                               .ToList();
            var carsResponse = new List<CarResponse>();
            foreach(var car in cars)
            {
                carsResponse.Add(new CarResponse()
                {
                    CarId = car.CarId,
                    BrandName = car.BrandName,
                    ModelName = car.ModelName,
                    Year = car.Year,
                    CoverImage = car.CoverImage,
                    NumberOfKilometers = car.NumberOfKilometers,
                    FuelTypeName = car.FuelTypeName,
                    Price = car.Price,
                    CreatedAt = car.CreatedAt
                });
            }

            var carResponsePaginated = new CarResponsePaginated()
            {
                cars = carsResponse,
                CurrentPage = page,
                NumberOfPages = (int)numberOfPages
            };
            return carResponsePaginated;

            
        }
        public double NumberOfPages(float numberofItemsPerPage)
        {
            return Math.Ceiling(_context.Cars.Count() / numberofItemsPerPage);
        }
        public bool IsModelExist(int id)
        {
            return _context.Models.Any(m => m.ModelId == id);
        }
        public CarDetailsResponse GetSingleCar(int id)
        {
            var car = _context.Cars
                              .Where(c=>c.CarId == id)
                              .Select(c => new
                              {
                                  c.CarId,
                                  c.Year,
                                  c.Price,
                                  c.NumberOfKilometers,
                                  c.Volume,
                                  c.HorsePower,
                                  c.KW,
                                  c.CoverImage,
                                  c.Model.ModelName,
                                  c.Model.Brand.BrandName,
                                  c.Color.ColorName,
                                  c.Doors.DoorsNumber,
                                  c.TransmissionType.TransmissionTypeName,
                                  c.FuelType.FuelTypeName,
                                  c.CreatedAt

                              })
                              .FirstOrDefault();

            var images = _context.Images.Where(i => i.CarId == id).ToList();
            List<ImageResponse> imageResponseList = new List<ImageResponse>();
            foreach(var image in images)
            {
                imageResponseList.Add(new ImageResponse()
                {
                    ImageName = image.ImageName
                });
            }
            CarDetailsResponse carDetails = new CarDetailsResponse()
            {
                CarId = car.CarId,
                Price = car.Price,
                Year = car.Year,
                NumberOfKilometers = car.NumberOfKilometers,
                Volume = car.Volume,
                HorsePower = car.HorsePower,
                KW = car.KW,
                CoverImage = car.CoverImage,
                ModelName = car.ModelName,
                BrandName = car.BrandName,
                ColorName = car.ColorName,
                DoorsNumber = car.DoorsNumber,
                TransmissionTypeName = car.TransmissionTypeName,
                FuelTypeName = car.FuelTypeName,
                Images = imageResponseList,
                CreatedAt = car.CreatedAt
            };

            return carDetails;
        }
        public bool IsCarExist(int id) {
            return _context.Cars.Any(c => c.CarId == id);
        }
    }
        
}
