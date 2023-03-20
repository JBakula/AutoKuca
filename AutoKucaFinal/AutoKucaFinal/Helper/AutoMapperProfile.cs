using AutoKucaFinal.DTOs;
using AutoKucaFinal.Models;
using AutoMapper;

namespace AutoKucaFinal.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<FuelType, FuelTypesResponse>();
            CreateMap<Doors, DoorsResponse>();
            CreateMap<TransmissionType, TransmissionTypeResponse>();
            CreateMap<Color, ColorResponse>();
            CreateMap<Brand, BrandResponse>();
            CreateMap<Model,ModelsResponse>();
        }
    }
}
