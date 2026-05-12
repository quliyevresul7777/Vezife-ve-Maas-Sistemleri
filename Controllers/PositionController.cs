using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaryManagementSystem.Data;
using SalaryManagementSystem.Models;
using SalaryManagementSystem.DTOs;

namespace SalaryManagementSystem.Controllers;

[ApiController]
[Route("api/positions")]
public class PositionController : ControllerBase
{
    private readonly AppDbContext _context;

    public PositionController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePositionDto dto)
    {
        var position = new Position
        {
            Name = dto.Name,
            BaseSalary = dto.BaseSalary
        };

        _context.Positions.Add(position);
        await _context.SaveChangesAsync();
        return Ok(position);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Positions.ToListAsync());
    }
}
