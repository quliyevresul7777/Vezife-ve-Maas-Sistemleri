using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaryManagementSystem.Data;
using SalaryManagementSystem.DTOs;
using SalaryManagementSystem.Models;
using SalaryManagementSystem.Services;

namespace SalaryManagementSystem.Controllers;

[ApiController]
[Route("api/salaries")]
public class SalaryController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly SalaryService _service;

    public SalaryController(AppDbContext context, SalaryService service)
    {
        _context = context;
        _service = service;
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> Calculate(CreateSalaryDto dto)
    {
        var employee = await _context.Employees
            .Include(x => x.Position)
            .FirstOrDefaultAsync(x => x.Id == dto.EmployeeId);

        if (employee == null) return NotFound();

        var final = _service.Calculate(employee.Position.BaseSalary, dto.Bonus, dto.Deduction);

        var salary = new Salary
        {
            EmployeeId = dto.EmployeeId,
            Month = dto.Month,
            Year = dto.Year,
            Bonus = dto.Bonus,
            Deduction = dto.Deduction,
            FinalSalary = final,
            CreatedDate = DateTime.UtcNow
        };

        _context.Salaries.Add(salary);
        await _context.SaveChangesAsync();

        return Ok(salary);
    }

    [HttpGet("{employeeId}")]
    public async Task<IActionResult> GetByEmployee(int employeeId)
    {
        var salaries = await _context.Salaries
            .Where(x => x.EmployeeId == employeeId)
            .ToListAsync();

        return Ok(salaries);
    }
}
