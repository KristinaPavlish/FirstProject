using FirstProject.Bll.Implementations;
using FirstProject.Bll.Models;

namespace FirstProject.Test.EmployeeTest;

public class EmployeeTests
{
    [Test]
    public void TotalSalaryForRightParams()
    {
        EmployeeService employeeService = new EmployeeService();
        Employee employee = new Employee
        {
            FullName = "Halushchynskyi Dmytro Ivanovych",
            HourlyWage = 34,
            WorkExperience = 7,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        Assert.That(employeeService.CalculationOfWages(employee), Is.EqualTo(8 * 34));
    }
    
    [Test]
    public void TotalSalaryForMoreThanTwentyYearsOfExperience()
    {
        EmployeeService employeeService = new EmployeeService();
        Employee employee = new Employee
        {
            FullName = "Halushchynskyi Dmytro Ivanovych",
            HourlyWage = 34,
            WorkExperience = 21,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        Assert.That(employeeService.CalculationOfWages(employee), Is.EqualTo((8 * 34) + 8 * 34 * 0.2));
    }
    
    [Test]
    public void TotalSalaryForExperienceBetweenTenAndTwenty()
    {
        EmployeeService employeeService = new EmployeeService();
        Employee employee = new Employee
        {
            FullName = "Halushchynskyi Dmytro Ivanovych",
            HourlyWage = 34,
            WorkExperience = 15,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        Assert.That(employeeService.CalculationOfWages(employee), Is.EqualTo((8 * 34) + 8 * 34 * 0.1));
    }
    
    [Test]
    public void SalaryForMoreThanTwentyYearsOfExperienceAndHoursWorkedLessThanNormOfHours()
    {
        EmployeeService employeeService = new EmployeeService();
        Employee employee = new Employee
        {
            FullName = "Halushchynskyi Dmytro Ivanovych",
            HourlyWage = 34,
            WorkExperience = 21,
            NumberOfHoursWorked = 7,
            RateOfCompletedWorks = 8
        };
        double salary = 7 * 34;
        salary -= salary * 0.2;
        salary +=  salary * 0.2;
        
        var expected = (7 * 34 - 7 * 34 * 0.2) + 7 * 34 * 0.2;
        Assert.That(employeeService.CalculationOfWages(employee), Is.EqualTo(salary));
    }
    
    [Test]
    public void TotalSalaryForExperienceBetweenTenAndTwentyAndHoursWorkedLessThanNormOfHours()
    {
        EmployeeService employeeService = new EmployeeService();
        Employee employee = new Employee
        {
            FullName = "Halushchynskyi Dmytro Ivanovych",
            HourlyWage = 34,
            WorkExperience = 15,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        double salary = 7 * 34;
        salary -= salary * 0.2;
        salary +=  salary * 0.1;
        Assert.That(employeeService.CalculationOfWages(employee), Is.EqualTo((8 * 34) + 8 * 34 * 0.1));
    }
    
    [Test]
    public void InitiateEmployeeWithRightParams()
    {
        Employee employee = new Employee
        {
            FullName = "Halushchynskyi Dmytro Ivanovych",
            HourlyWage = 34,
            WorkExperience = 7,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        EmployeeService employeeService = new EmployeeService();
        Assert.That(employeeService.InitialsOfEmployee(employee), Is.EqualTo("Halushchynskyi D.I."));
    }
    
    [Test]
    public void InitiateEmployeeWithoutName()
    {
        Employee employee = new Employee
        {
            FullName = "Halushchynskyi Ivanovych",
            HourlyWage = 34,
            WorkExperience = 7,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        EmployeeService employeeService = new EmployeeService();
        Assert.That(employeeService.InitialsOfEmployee(employee), Is.EqualTo("Halushchynskyi I."));
    }
    
    [Test]
    public void InitiateEmployeeOnlyWithSurname()
    {
        Employee employee = new Employee
        {
            FullName = "Halushchynskyi",
            HourlyWage = 34,
            WorkExperience = 7,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        EmployeeService employeeService = new EmployeeService();
        Assert.That(employeeService.InitialsOfEmployee(employee), Is.EqualTo("Halushchynskyi"));
    }
    
    [Test]
    public void InitiateEmployeeWithEmptyFullName()
    {
        Employee employee = new Employee
        {
            FullName = "",
            HourlyWage = 34,
            WorkExperience = 7,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        EmployeeService employeeService = new EmployeeService();
        Assert.That(employeeService.InitialsOfEmployee(employee), Is.EqualTo(""));
    }
    
    [Test]
    public void InitiateEmployeeWithNullFullName()
    {
        Employee employee = new Employee
        {
            FullName = null,
            HourlyWage = 34,
            WorkExperience = 7,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        EmployeeService employeeService = new EmployeeService();
        Assert.That(employeeService.InitialsOfEmployee(employee), Is.EqualTo(""));
    }
    
    [Test]
    public void InitiateEmployeeFullNameWithNum()
    {
        Employee employee = new Employee
        {
            FullName = "343232 7hg23 4yge",
            HourlyWage = 34,
            WorkExperience = 7,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        EmployeeService employeeService = new EmployeeService();
        Assert.That(employeeService.InitialsOfEmployee(employee), Is.EqualTo("343232 7.4."));
    }
    
    [Test]
    public void InitiateEmployeeWithoutNameAndWithNum()
    {
        Employee employee = new Employee
        {
            FullName = "343232 874jhd",
            HourlyWage = 34,
            WorkExperience = 7,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        EmployeeService employeeService = new EmployeeService();
        Assert.That(employeeService.InitialsOfEmployee(employee), Is.EqualTo("343232 8."));
    }
    
    [Test]
    public void InitiateEmployeeSurnameWithNum()
    {
        Employee employee = new Employee
        {
            FullName = "343232",
            HourlyWage = 34,
            WorkExperience = 7,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        EmployeeService employeeService = new EmployeeService();
        Assert.That(employeeService.InitialsOfEmployee(employee), Is.EqualTo("343232"));
    }
    
    [Test]
    public void InitiateEmployeeFullNameContainsManySymbols()
    {
        Employee employee = new Employee
        {
            FullName = "343232kngkjnsr;ojwe;rj;krjsfg;ksjdfg;kjnr;tnw'oet;rwjtnowritn;ownowen;rweijntwe;oitowei4tnreoitntfnikewtfnkotoworg;job'trbotro ;osrfn;eiortn;oeritn;oetnr jfdkjfkejtroeroerigvkvgvgvyuubhbhwerrbhlwlwrhefbhlbhfebhrolrhebouerhv",
            HourlyWage = 34,
            WorkExperience = 7,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        EmployeeService employeeService = new EmployeeService();
        Assert.That(employeeService.InitialsOfEmployee(employee), Is.EqualTo("343232kngkjnsr;ojwe;rj;krjsfg;ksjdfg;kjnr;tnw'oet;rwjtnowritn;ownowen;rweijntwe;oitowei4tnreoitntfnikewtfnkotoworg;job'trbotro ;.J."));
    }
}