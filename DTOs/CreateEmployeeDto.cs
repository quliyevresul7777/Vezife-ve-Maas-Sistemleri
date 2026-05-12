namespace SalaryManagementSystem.DTOs;

public class CreateEmployeeDto
{
    public string FullName { get; set; }
    public int PositionId { get; set; }
    public DateTime HireDate { get; set; }
}
