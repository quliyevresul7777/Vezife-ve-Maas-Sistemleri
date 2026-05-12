namespace SalaryManagementSystem.Services;

public class SalaryService
{
    public decimal Calculate(decimal baseSalary, decimal bonus, decimal deduction)
    {
        return baseSalary + bonus - deduction;
    }
}
