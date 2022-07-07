namespace FirstProject.Bll;

public class Company
{
    public List<Employee> EmployeeList { get; set; }

    public Company()
    {
        EmployeeList = new List<Employee>();
    }
    

    /// <summary>
    /// calculate the total number of hours reported by all employees of the company
    /// </summary>
    /// <returns> totalNumberOfHoursWorked </returns>
    public uint CalculateTotalHours()
    {
        if (EmployeeList.Count == 0)
        {
            return 0;
        }
        uint totalNumberOfHoursWorked = 0;
        foreach (var hours in EmployeeList)
        {
            totalNumberOfHoursWorked += hours.GetNumberOfHoursWorked();
        }

        return totalNumberOfHoursWorked;
    }
    

    /// <summary>
    /// find the most experienced employee
    /// </summary>
    /// <returns>years of experience</returns>
    //TODO return Employee
    public uint CalculateMostExperiencedEmployee()
    {
        uint mostExperiencedEmployee = EmployeeList.Select(x => x.GetExperience()).Max();

        return mostExperiencedEmployee;
    }
    
    /// <summary> find employee with the highest salary and return Employee </summary>
    /// <returns> Employee </returns>
    public List<Employee> GetEmployeeWithMaxSalary()
    {
        var maxSalary = EmployeeList.Max(x => x.CalculationOfWages());
        return EmployeeList.Count == 0 ? null : EmployeeList.Where(x => x.CalculationOfWages() == maxSalary).ToList();
    }
    
    /// <summary>
    /// calculate the highest salary of an employee
    /// </summary>
    /// <returns></returns>
    public double CalculateMaxSalary()
    {
        var salary = EmployeeList.Select(x => x.CalculationOfWages()).Max();
        
        return salary;
    }

    /// <summary> remove from the company employees whose experience is less than the specified number </summary>
    /// <param name="lowerAge"></param>
    /// <returns> Company </returns>
    /// <exception cref="NotImplementedException"></exception>
    public Company RemoveEmployeeByExperienceAge(uint lowerAge)
    {
        throw new NotImplementedException();
    }

    /// <summary> Find Employee by the last name </summary>
    /// <param name="lastName"></param>
    /// <returns> Employee </returns>
    /// <exception cref="NotImplementedException"></exception>
    public Employee FindEmployeeByLastName(string lastName)
    {
        throw new NotImplementedException();
    }
    
}