using Mapster;
using XemXe.Application.DTOs.Requests;
using XemXe.Application.DTOs.Responses;
using XemXe.Domain.Entities;

namespace XemXe.Application.Mappings;

public class CarMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreatedCarRequest, Car>();
        config.NewConfig<Manufacturer, ManufacturerResponse>();
        config.NewConfig<CarModel, CarModelResponse>();
        config.NewConfig<CarType, CarTypeResponse>();
        config.NewConfig<Color, ColorResponse>();
        
        config.NewConfig<Car, CarResponse>()
            .Map(dest => dest.Manufacturer, src => src.CarModel.Manufacturer)
            .Map(dest => dest.Model, src => src.CarModel)
            .Map(dest => dest.Type, src => src.CarModel.CarType);
    }
}

public static class MappingConfig
{
    public static IRegister GetRegister() => new CarMappingRegister();
}