using FirstProject.Bll.Models;
namespace FirstProject.Bll.Implementations;

public class EmployeeService : IEmployeeService
{
    /// <summary>
    /// calculate wage of employee
    /// wage = number of hours worked * hourly wage
    /// if work experience between 10 and 20: wage = wage + wage * 0,1
    /// if work experience biggest that 20: wage = wage + wage * 0,2
    /// if number of hours worked smaller than rate of completed works: wage = wage - wage * 0,2
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
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
    /// <summary>
    /// get initials of employee second name
    /// + first upper letter of first name and dot
    /// +  first upper letter of middle name and dot
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>

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