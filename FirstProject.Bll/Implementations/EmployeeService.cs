using FirstProject.Bll.Models;
namespace FirstProject.Bll.Implementations;

public class EmployeeService : IEmployeeService
{
    public double CalculationOfWages(Employee employee)
    {
        double salary = employee.NumberOfHoursWorked * employee.HourlyWage;
        
        if (employee.NumberOfHoursWorked  < employee.RateOfCompletedWorks)
        {
            salary -= salary * 0.2;
        }

        if (employee.WorkExperience >= 10 && employee.WorkExperience <= 20)
        {
            salary += salary * 0.1;
        }

        if (employee.WorkExperience > 20)
        {
            salary += salary * 0.2;
        }

        return salary;
    }

    public string InitialsOfEmployee(Employee employee)
    {
        if (string.IsNullOrEmpty(employee.FullName))
        {
            return "";
        }
        string[] fullNameOfEmployee = employee.FullName.Split();
        string firstWordOfFullName = fullNameOfEmployee.First();
        if (fullNameOfEmployee.Length == 1)
        {
            return employee.FullName;
        }

        string initials = "";
        initials = firstWordOfFullName + " ";


        string[] initialsWithoutSurname = string.Join(" ", employee.FullName.Split().Skip(1)).Split();

        initials += string.Join("", initialsWithoutSurname.Select(x => x.Substring(0, 1).ToUpper() + "."));

        return initials;
    }
}