using FirstProject.Bll.Interfaces;
using FirstProject.Bll.Models;
namespace FirstProject.Bll.Implementations;

public class CompanyService : ICompanyService
{
    
    private IEmployeeService employeeService;

    public CompanyService(IEmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }

    /// <summary>
    /// add employee to the company 
    /// </summary>
    /// <param name="company"></param>
    /// <param name="employee"></param>
    /// <exception cref="Exception"></exception>
    public void HireEmployee(Company company, Employee employee)
    {
        if (company == null)
        {
            throw new Exception("Company is not provided");
        }
        if (company.Employees == null)
        {
            company.Employees = new List<Employee>();
        }
        if (!employee.IsValid())
        {
            throw new Exception("Employee is invalid");
        }
        company.Employees.Add(employee);
    }

    /// <summary>
    /// Calculate the total number of hours reported by all employees of the company
    /// </summary>
    /// <returns> totalNumberOfHoursWorked </returns>
    public uint CalculateTotalHours(Company company)
    {
        if (company.Employees.Count == 0)
        {
            throw new Exception("Object reference not set to an instance of an object.");
        }
        uint totalNumberOfHoursWorked = 0;
        foreach (var hours in company.Employees)
        {
            totalNumberOfHoursWorked += hours.NumberOfHoursWorked;
        }
        return totalNumberOfHoursWorked;    
    }
    
    /// <summary>
    /// Find the most experienced employee
    /// </summary>
    /// <returns>years of experience</returns>
    public List<Employee> CalculateMostExperiencedEmployee(Company company)
    {
        var maxExperience = company.Employees.Select(x => x.WorkExperience).Max();
        return company.Employees.Where(x => x.WorkExperience == maxExperience).ToList() ;
    }

    /// <summary>
    /// Calculate the highest salary of an employee
    /// </summary>
    /// <returns>salary</returns>
    public double CalculateMaxSalary(Company company)
    {
        return company.Employees.Max(x => employeeService.CalculationOfWages(x));
    }
    
    /// <summary> Find employee with the highest salary and return Employee </summary>
    /// <returns> Employee </returns>
    public List<Employee>? GetEmployeeWithMaxSalary(Company company)
    {
        if (company.Employees.ToList().Count == 0)
        {
            throw new Exception("Company is empty");
        }
        var maxSalary = company.Employees.Max(x => employeeService.CalculationOfWages(x));
        return company.Employees.Count == 0? null: company.Employees.Where(x => employeeService.CalculationOfWages(x) == maxSalary).ToList();
    }


    /// <summary> Remove from the company employees whose experience is less than the specified number </summary>
    /// <param name="lowerAge"></param>
    /// <param name="company"></param>
    /// <returns> Company </returns>
    /// <exception cref="NotImplementedException"></exception>
    public void RemoveEmployeeByExperienceAge(uint lowerAge, Company company)
    {
        foreach (var employee in company.Employees.ToList())
        {
            if (employee.WorkExperience < lowerAge)
            {
                company.Employees.Remove(employee);
            }
        }
    }

    /// <summary> Find Employee by the last name </summary>
    /// <param name="lastName"></param>
    /// <param name="company"></param>
    /// <returns> Employee </returns>
    /// <exception cref="NotImplementedException"></exception>
    public List<Employee> FindEmployeeByLastName(string lastName, Company company)
    {
        return company.Employees == null
            ? new List<Employee>()
            : company.Employees.Where(x => x.FullName.Split(' ').FirstOrDefault() == lastName).ToList();
    }
}