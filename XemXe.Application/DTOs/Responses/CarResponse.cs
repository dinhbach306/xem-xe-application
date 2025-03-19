namespace XemXe.Application.DTOs.Responses;

public class CarResponse
{
    public int Id { get; set; }
    public ManufacturerResponse Manufacturer { get; set; }
    public CarModelResponse Model { get; set; }
    public CarTypeResponse Type { get; set; }
    public ColorResponse Color { get; set; }
    public decimal Price { get; set; }
    public int Year { get; set; }
    public bool IsAvailable { get; set; }
    public List<string> ImageUrls { get; set; } = new List<string>();
}