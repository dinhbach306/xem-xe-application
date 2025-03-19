using Microsoft.AspNetCore.Mvc;
using XemXe.Application.DTOs.Requests;
using XemXe.Application.Services;

namespace XemXe.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController(ICarService carService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCars()
    {
        var cars = await carService.GetAllCarsAsync();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarById(int id)
    {
        var car = await carService.GetCarByIdAsync(id);
        if (car == null) return NotFound();
        return Ok(car);
    }

    [HttpGet("manufacturer/{manufacturerId}")]
    public async Task<IActionResult> GetCarsByManufacturer(int manufacturerId)
    {
        var cars = await carService.GetCarsByManufacturerAsync(manufacturerId);
        return Ok(cars);
    }

    [HttpPost]
    public async Task<IActionResult> AddCar([FromForm] CreatedCarRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await carService.AddCarAsync(request);
        return CreatedAtAction(nameof(GetCarById), new { id = request.ModelId }, request);
    }
}