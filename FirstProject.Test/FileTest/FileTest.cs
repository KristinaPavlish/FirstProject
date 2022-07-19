using FirstProject.Bll.Implementations;
using FirstProject.Bll.Models;

namespace FirstProject.Test.FileTest;

public class FileTest
{
    [Test]
    public void SaveRightCompanyToJson()
    {
        Company company = new Company();
        CompanyService companyService = new CompanyService(new EmployeeService());
        Employee employee1 = new Employee()
        {
            FullName = "Temnyk Ivan Viktorovytch",
            HourlyWage = 35,
            WorkExperience = 10,
            NumberOfHoursWorked = 7,
            RateOfCompletedWorks = 8
        };
        Employee employee2 = new Employee()
        {
            FullName = "Vistak Veronica Stepanivna",
            HourlyWage = 25,
            WorkExperience = 9,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 10
        };
        Employee employee3 = new Employee()
        {
            FullName = "Oprisnyk Dmytro Adamovytch",
            HourlyWage = 32,
            WorkExperience = 23,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        Employee employee4 = new Employee()
        {
            FullName = "Halushchynskyi Dmytro Ivanovych",
            HourlyWage = 15,
            WorkExperience = 23,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        companyService.HireEmployee(company, employee1);
        companyService.HireEmployee(company, employee2);
        companyService.HireEmployee(company, employee3);
        companyService.HireEmployee(company, employee4);
        JsonFileService jsonFileService = new JsonFileService();
        jsonFileService.Save(company, "Company_test.json");
        Assert.That(File.Exists("Company_test.json"), Is.EqualTo(true));

    }
    
    [Test]
    public void SaveWrongCompanyToJson()
    {
        Company company = null;
        JsonFileService jsonFileService = new JsonFileService();
        jsonFileService.Save(company, "Company_test.json");
        Assert.That(File.Exists("Company_test.json"), Is.EqualTo(true));

    }

    [Test]
    public void SaveAndUploadCompanyToJson()
    {
        Company company1 = new Company();
        CompanyService companyService = new CompanyService(new EmployeeService());
        Employee employee1 = new Employee()
        {
            FullName = "Temnyk Ivan Viktorovytch",
            HourlyWage = 35,
            WorkExperience = 10,
            NumberOfHoursWorked = 7,
            RateOfCompletedWorks = 8
        };
        Employee employee2 = new Employee()
        {
            FullName = "Vistak Veronica Stepanivna",
            HourlyWage = 25,
            WorkExperience = 9,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 10
        };
        Employee employee3 = new Employee()
        {
            FullName = "Oprisnyk Dmytro Adamovytch",
            HourlyWage = 32,
            WorkExperience = 23,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        Employee employee4 = new Employee()
        {
            FullName = "Halushchynskyi Dmytro Ivanovych",
            HourlyWage = 15,
            WorkExperience = 23,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        companyService.HireEmployee(company1, employee1);
        companyService.HireEmployee(company1, employee2);
        companyService.HireEmployee(company1, employee3);
        companyService.HireEmployee(company1, employee4);
        JsonFileService jsonFileService = new JsonFileService();
        jsonFileService.Save(company1, "Company_test.json");

        Company company2 = jsonFileService.Upload("Company_test.json");
        Assert.That(company1.Name, Is.EqualTo(company2.Name));
        Assert.That(company1.Employees.Count, Is.EqualTo(company2.Employees.Count));
        for (int i = 0; i < company1.Employees.Count; i++)
        {
            Assert.That(company1.Employees[i].FullName, Is.EqualTo(company2.Employees[i].FullName));
            Assert.That(company1.Employees[i].HourlyWage, Is.EqualTo(company2.Employees[i].HourlyWage));
            Assert.That(company1.Employees[i].WorkExperience, Is.EqualTo(company2.Employees[i].WorkExperience));
            Assert.That(company1.Employees[i].NumberOfHoursWorked, Is.EqualTo(company2.Employees[i].NumberOfHoursWorked));
            Assert.That(company1.Employees[i].RateOfCompletedWorks, Is.EqualTo(company2.Employees[i].RateOfCompletedWorks));
        }
    }
     [Test]
    public void SaveAndUploadCompanyToText()
    {
        Company company1 = new Company();
        CompanyService companyService = new CompanyService(new EmployeeService());
        company1.Name = "Apple";
        Employee employee1 = new Employee()
        {
            FullName = "Temnyk Ivan Viktorovytch",
            HourlyWage = 35,
            WorkExperience = 10,
            NumberOfHoursWorked = 7,
            RateOfCompletedWorks = 8
        };
        Employee employee2 = new Employee()
        {
            FullName = "Vistak Veronica Stepanivna",
            HourlyWage = 25,
            WorkExperience = 9,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 10
        };
        Employee employee3 = new Employee()
        {
            FullName = "Oprisnyk Dmytro Adamovytch",
            HourlyWage = 32,
            WorkExperience = 23,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        Employee employee4 = new Employee()
        {
            FullName = "Halushchynskyi Dmytro Ivanovych",
            HourlyWage = 15,
            WorkExperience = 23,
            NumberOfHoursWorked = 8,
            RateOfCompletedWorks = 8
        };
        companyService.HireEmployee(company1, employee1);
        companyService.HireEmployee(company1, employee2);
        companyService.HireEmployee(company1, employee3);
        companyService.HireEmployee(company1, employee4);
        
        TextFileService textFileService = new TextFileService();
        textFileService.Save(company1, "Company_test.txt");

        Company company2 = textFileService.Upload("Company_test.txt");
        Assert.That(company1.Name, Is.EqualTo(company2.Name));
        Assert.That(company1.Employees.Count, Is.EqualTo(company2.Employees.Count));
        for (var i = 0; i < company1.Employees.Count; i++)
        {
            Assert.Multiple(() =>
            {
                Assert.That(company1.Employees[i].FullName, Is.EqualTo(company2.Employees[i].FullName));
                Assert.That(company1.Employees[i].HourlyWage, Is.EqualTo(company2.Employees[i].HourlyWage));
                Assert.That(company1.Employees[i].WorkExperience, Is.EqualTo(company2.Employees[i].WorkExperience));
                Assert.That(company1.Employees[i].NumberOfHoursWorked, Is.EqualTo(company2.Employees[i].NumberOfHoursWorked));
                Assert.That(company1.Employees[i].RateOfCompletedWorks, Is.EqualTo(company2.Employees[i].RateOfCompletedWorks));
            });
        }
    }

    [Test]
    public void SaveAndUploadCompanyToTextWithWrongParams()
    {
        Company company1 = new Company();
        CompanyService companyService = new CompanyService(new EmployeeService());
        company1.Name = "Apple";
        Employee employee1 = new Employee()
        {
            FullName = "Temnyk Ivan Viktorovytch",
            HourlyWage = 35,
            
            NumberOfHoursWorked = 7,
            RateOfCompletedWorks = 8
        };
        try
        {
            companyService.HireEmployee(company1, employee1);
            Assert.Fail("Exception Expected");
        }
        catch (Exception exception)
        {
            Assert.That(exception.Message, Is.EqualTo("Employee is invalid"));
        }
        TextFileService textFileService = new TextFileService();
        textFileService.Save(company1, "Company_test.txt");

        Company company2 = textFileService.Upload("Company_test.txt");
        Assert.That(company1.Name, Is.EqualTo(company2.Name));
        Assert.That(company1.Employees.Count, Is.EqualTo(company2.Employees.Count));
        for (var i = 0; i < company1.Employees.Count; i++)
        {
            Assert.Multiple(() =>
            {
                Assert.That(company1.Employees[i].FullName, Is.EqualTo(company2.Employees[i].FullName));
                Assert.That(company1.Employees[i].HourlyWage, Is.EqualTo(company2.Employees[i].HourlyWage));
                Assert.That(company1.Employees[i].WorkExperience, Is.EqualTo(company2.Employees[i].WorkExperience));
                Assert.That(company1.Employees[i].NumberOfHoursWorked, Is.EqualTo(company2.Employees[i].NumberOfHoursWorked));
                Assert.That(company1.Employees[i].RateOfCompletedWorks, Is.EqualTo(company2.Employees[i].RateOfCompletedWorks));
            });
        }
    }
    
    [Test]
    public void SaveAndUploadCompanyToJsonWithWrongParams()
    {
        Company company1 = new Company();
        CompanyService companyService = new CompanyService(new EmployeeService());
        company1.Name = "Apple";
        Employee employee1 = new Employee()
        {
            FullName = "Temnyk Ivan Viktorovytch",
            HourlyWage = 35,
            
            NumberOfHoursWorked = 7,
            RateOfCompletedWorks = 8
        };
        try
        {
            companyService.HireEmployee(company1, employee1);
            Assert.Fail("Exception Expected");
        }
        catch (Exception exception)
        {
            Assert.That(exception.Message, Is.EqualTo("Employee is invalid"));
        }
        TextFileService jsonFileService = new TextFileService();
        jsonFileService.Save(company1, "Company_test.json");

        Company company2 = jsonFileService.Upload("Company_test.json");
        Assert.That(company1.Name, Is.EqualTo(company2.Name));
        Assert.That(company1.Employees.Count, Is.EqualTo(company2.Employees.Count));
        for (var i = 0; i < company1.Employees.Count; i++)
        {
            Assert.Multiple(() =>
            {
                Assert.That(company1.Employees[i].FullName, Is.EqualTo(company2.Employees[i].FullName));
                Assert.That(company1.Employees[i].HourlyWage, Is.EqualTo(company2.Employees[i].HourlyWage));
                Assert.That(company1.Employees[i].WorkExperience, Is.EqualTo(company2.Employees[i].WorkExperience));
                Assert.That(company1.Employees[i].NumberOfHoursWorked, Is.EqualTo(company2.Employees[i].NumberOfHoursWorked));
                Assert.That(company1.Employees[i].RateOfCompletedWorks, Is.EqualTo(company2.Employees[i].RateOfCompletedWorks));
            });
        }
    }
} 