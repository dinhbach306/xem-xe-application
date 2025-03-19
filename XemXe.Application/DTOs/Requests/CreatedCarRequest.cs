using Microsoft.AspNetCore.Http;

namespace XemXe.Application.DTOs.Requests;

public class CreatedCarRequest
{
    public int ModelId { get; set; }
    public int ColorId { get; set; }
    public decimal Price { get; set; }
    public int Year { get; set; }
    public bool IsAvailable { get; set; }
    public List<IFormFile> Images { get; set; } = new List<IFormFile>();
}