namespace SalaryManagementSystem.DTOs;

public class CreateSalaryDto
{
    public int EmployeeId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal Bonus { get; set; }
    public decimal Deduction { get; set; }
}
