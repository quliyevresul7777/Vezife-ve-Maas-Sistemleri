namespace SalaryManagementSystem.Models;

public class Salary
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal Bonus { get; set; }
    public decimal Deduction { get; set; }
    public decimal FinalSalary { get; set; }
    public DateTime CreatedDate { get; set; }
}
