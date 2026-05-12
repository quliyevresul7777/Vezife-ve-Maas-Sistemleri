namespace SalaryManagementSystem.Models;

public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int PositionId { get; set; }
    public Position Position { get; set; }
    public DateTime HireDate { get; set; }
}
