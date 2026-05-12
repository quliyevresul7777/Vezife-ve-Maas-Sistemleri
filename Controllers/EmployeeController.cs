using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaryManagementSystem.Data;
using SalaryManagementSystem.Models;
using SalaryManagementSystem.DTOs;

namespace SalaryManagementSystem.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            FullName = dto.FullName,
            PositionId = dto.PositionId,
            HireDate = dto.HireDate
        };

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return Ok(employee);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Employees.Include(x => x.Position).ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var employee = await _context.Employees.Include(x => x.Position)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (employee == null) return NotFound();
        return Ok(employee);
    }
}
