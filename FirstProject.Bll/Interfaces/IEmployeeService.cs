using FirstProject.Bll.Models;

public interface IEmployeeService
{
    double CalculationOfWages(Employee employee);
    string InitialsOfEmployee(Employee employee);
}