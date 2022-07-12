using FirstProject.Bll.Implementations;
using FirstProject.Bll.Models;

namespace FirstProject.Test.CompanyTest;

public class CompanyTest
{
        [Test]
        public void HireEmployeeTest()
        {
                Company company = new Company();
                CompanyService companyService = new CompanyService(new EmployeeService());
                company.Name = "Apple";
                Employee employee = new Employee()
                {
                        FullName = "Halushchynskyi Dmytro Ivanovych",
                        HourlyWage = 6,
                        WorkExperience = 7,
                        NumberOfHoursWorked = 8,
                        RateOfCompletedWorks = 34
                };
                companyService.HireEmployee(company, employee);
                Assert.That(company.Employees.Last(), Is.EqualTo(employee));
        }

        [Test]
        public void HireInvalidEmployeeTest()
        {
                Company company = new Company();
                CompanyService companyService = new CompanyService(new EmployeeService());
                Employee employee = new Employee()
                {
                        FullName = "Halushchynskyi Dmytro Ivanovych",
                        HourlyWage = 6,
                        NumberOfHoursWorked = 8,
                        RateOfCompletedWorks = 34
                };
                try
                {
                        companyService.HireEmployee(company, employee);
                        Assert.Fail("Exception Expected");
                }
                catch (Exception e)
                {
                        Assert.That(e.Message, Is.EqualTo("Employee is invalid"));
                }
        }

        [Test]
        public void TestCalculateTotalHoursWithRightParams()
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
                        HourlyWage = 55,
                        WorkExperience = 23,
                        NumberOfHoursWorked = 8,
                        RateOfCompletedWorks = 8
                };
                Employee employee4 = new Employee()
                {
                        FullName = "Halushchynskyi Dmytro Ivanovych",
                        HourlyWage = 32,
                        WorkExperience = 12,
                        NumberOfHoursWorked = 8,
                        RateOfCompletedWorks = 8
                };
                companyService.HireEmployee(company, employee1);
                companyService.HireEmployee(company, employee2);
                companyService.HireEmployee(company, employee3);
                companyService.HireEmployee(company, employee4);

                Assert.That(companyService.CalculateTotalHours(company), Is.EqualTo(31));
        }

        [Test]
        public void TestCalculateTotalHoursWithOneEmployee()
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
                companyService.HireEmployee(company, employee1);
                Assert.That(companyService.CalculateTotalHours(company), Is.EqualTo(7));

        }

        [Test]
        public void TestCalculateTotalHoursWithoutInitializationOfHours()
        {
                Company company = new Company();
                CompanyService companyService = new CompanyService(new EmployeeService());
                Employee employee1 = new Employee()
                {
                        FullName = "Temnyk Ivan Viktorovytch",
                        HourlyWage = 35,
                        WorkExperience = 10,
                        RateOfCompletedWorks = 8
                };
                try
                {
                        companyService.HireEmployee(company, employee1);
                        Assert.Fail("Exception Expected");
                }
                catch (Exception e)
                {
                        Assert.That(e.Message, Is.EqualTo("Employee is invalid"));
                }
        }

        [Test]
        public void TestCalculateTotalHoursWithZero()
        {
                Company company = new Company();
                CompanyService companyService = new CompanyService(new EmployeeService());
                Employee employee1 = new Employee()
                {
                        FullName = "Temnyk Ivan Viktorovytch",
                        HourlyWage = 35,
                        NumberOfHoursWorked = 0,
                        WorkExperience = 10,
                        RateOfCompletedWorks = 8
                };
                try
                {
                        companyService.HireEmployee(company, employee1);
                        Assert.Fail("Exception Expected");
                }
                catch (Exception e)
                {
                        Assert.That(e.Message, Is.EqualTo("Employee is invalid"));
                }
        }

        [Test]
        public void TestCalculateTotalHoursWithEmptyCompany()
        {
                Company company = new Company();
                CompanyService companyService = new CompanyService(new EmployeeService());
                try
                {
                        companyService.CalculateTotalHours(company);
                        Assert.Fail("Exception Expected");
                }
                catch (Exception e)
                {
                        Assert.That(e.Message, Is.EqualTo("Object reference not set to an instance of an object."));
                }
        }

        [Test]
        public void TestCalculateMostExperiencedEmployeeWithOneEmployee()
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
                companyService.HireEmployee(company, employee1);
                List<Employee> EmployeeList = new List<Employee>();
                EmployeeList.Add(employee1);
                Assert.That(companyService.CalculateMostExperiencedEmployee(company), Is.EqualTo(EmployeeList));
        }

        [Test]
        public void TestCalculateMostExperiencedEmployeeWithRightParams()
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
                        HourlyWage = 55,
                        WorkExperience = 23,
                        NumberOfHoursWorked = 8,
                        RateOfCompletedWorks = 8
                };
                Employee employee4 = new Employee()
                {
                        FullName = "Halushchynskyi Dmytro Ivanovych",
                        HourlyWage = 32,
                        WorkExperience = 12,
                        NumberOfHoursWorked = 8,
                        RateOfCompletedWorks = 8
                };
                companyService.HireEmployee(company, employee1);
                companyService.HireEmployee(company, employee2);
                companyService.HireEmployee(company, employee3);
                companyService.HireEmployee(company, employee4);
                List<Employee> EmployeeList = new List<Employee>();
                EmployeeList.Add(employee3);
                Assert.That(companyService.CalculateMostExperiencedEmployee(company), Is.EqualTo(EmployeeList));
        }

        [Test]
        public void TestCalculateMostExperiencedEmployeeWithTwoTheSameExperience()
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
                        HourlyWage = 55,
                        WorkExperience = 23,
                        NumberOfHoursWorked = 8,
                        RateOfCompletedWorks = 8
                };
                Employee employee4 = new Employee()
                {
                        FullName = "Halushchynskyi Dmytro Ivanovych",
                        HourlyWage = 32,
                        WorkExperience = 23,
                        NumberOfHoursWorked = 8,
                        RateOfCompletedWorks = 8
                };
                companyService.HireEmployee(company, employee1);
                companyService.HireEmployee(company, employee2);
                companyService.HireEmployee(company, employee3);
                companyService.HireEmployee(company, employee4);
                List<Employee> EmployeeList = new List<Employee>();
                EmployeeList.Add(employee3);
                EmployeeList.Add(employee4);
                Assert.That(companyService.CalculateMostExperiencedEmployee(company), Is.EqualTo(EmployeeList));
        }

        [Test]
        public void TestCalculateMaxSalaryWithRightParams()
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
                        HourlyWage = 25,
                        WorkExperience = 23,
                        NumberOfHoursWorked = 8,
                        RateOfCompletedWorks = 8
                };
                Employee employee4 = new Employee()
                {
                        FullName = "Halushchynskyi Dmytro Ivanovych",
                        HourlyWage = 32,
                        WorkExperience = 23,
                        NumberOfHoursWorked = 8,
                        RateOfCompletedWorks = 8
                };
                companyService.HireEmployee(company, employee1);
                companyService.HireEmployee(company, employee2);
                companyService.HireEmployee(company, employee3);
                companyService.HireEmployee(company, employee4);

                Assert.That(companyService.CalculateMaxSalary(company), Is.EqualTo(32 * 8 + 32 * 8 * 0.2));
        }
        [Test]
        public void TestCalculateMaxSalaryWithOneEmployee()
        {
                Company company = new Company();
                CompanyService companyService = new CompanyService(new EmployeeService());
          
                Employee employee4 = new Employee()
                {
                        FullName = "Halushchynskyi Dmytro Ivanovych",
                        HourlyWage = 32,
                        WorkExperience = 23,
                        NumberOfHoursWorked = 8,
                        RateOfCompletedWorks = 8
                };
                
                companyService.HireEmployee(company, employee4);
                Assert.That(companyService.CalculateMaxSalary(company), Is.EqualTo(32 * 8 + 32 * 8 * 0.2));
        }
        
        [Test]
        public void GetEmployeeWithMaxSalaryWithTwoTheSameSalary()
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
                        HourlyWage = 32,
                        WorkExperience = 23,
                        NumberOfHoursWorked = 8,
                        RateOfCompletedWorks = 8
                };
                companyService.HireEmployee(company, employee1);
                companyService.HireEmployee(company, employee2);
                companyService.HireEmployee(company, employee3);
                companyService.HireEmployee(company, employee4);
                
                List<Employee> EmployeeList = new List<Employee>();
                EmployeeList.Add(employee3);
                EmployeeList.Add(employee4);

                Assert.That(companyService.GetEmployeeWithMaxSalary(company), Is.EqualTo(EmployeeList));
        }
        
        [Test]
        public void GetEmployeeWithMaxSalaryWithRightParams()
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
                
                List<Employee> EmployeeList = new List<Employee>();
                EmployeeList.Add(employee3);
                Assert.That(companyService.GetEmployeeWithMaxSalary(company), Is.EqualTo(EmployeeList));
        }
        
        [Test]
        public void RemoveEmployeeByExperienceAgeWithRightParams()
        {
                Company company = new Company();
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
                companyService.HireEmployee(company, employee1);
                companyService.HireEmployee(company, employee2);
                companyService.HireEmployee(company, employee3);
                companyService.HireEmployee(company, employee4);
                companyService.RemoveEmployeeByExperienceAge(11, company);
                
                companyService.HireEmployee(company1, employee3);
                companyService.HireEmployee(company1, employee4);
                
                company.Employees.RemoveAll(x => company1.Employees.Contains(x));
                Assert.That(company.Employees.Count, Is.EqualTo(0));
                Assert.That(company.Employees.Count, Is.EqualTo(company.Employees.Count(x => x.WorkExperience < 11)));
        }
        
         [Test]
        public void RemoveEmployeeByExperienceAgeRemovingAllEmployee()
        {
                Company company = new Company();
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
                companyService.HireEmployee(company, employee1);
                companyService.HireEmployee(company, employee2);
                companyService.HireEmployee(company, employee3);
                companyService.HireEmployee(company, employee4);
                
                companyService.RemoveEmployeeByExperienceAge(50, company);
                company.Employees.RemoveAll(x => company1.Employees.Contains(x));
                Assert.That(company.Employees.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void FindEmployeeByLastNameWithOneParam()
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
                companyService.HireEmployee(company, employee1);
                List<Employee> EmployeeList = new List<Employee>();
                EmployeeList.Add(employee1);
               
                Assert.That(companyService.FindEmployeeByLastName("Temnyk", company), Is.EqualTo(EmployeeList));
        }
        [Test]
        public void FindEmployeeByLastNameWithRightParams()
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
                Employee employee5 = new Employee()
                {
                        FullName = "Temnyk Ivan Viktorovytch",
                        HourlyWage = 35,
                        WorkExperience = 10,
                        NumberOfHoursWorked = 7,
                        RateOfCompletedWorks = 8
                };  
                companyService.HireEmployee(company, employee1);
                companyService.HireEmployee(company, employee2);
                companyService.HireEmployee(company, employee3);
                companyService.HireEmployee(company, employee4);
                companyService.HireEmployee(company, employee5);
                List<Employee> EmployeeList = new List<Employee>();
                EmployeeList.Add(employee1);
                EmployeeList.Add(employee5);
               
                Assert.That(companyService.FindEmployeeByLastName("Temnyk", company), Is.EqualTo(EmployeeList));
        }

        [Test]
        public void FindEmployeeByLastNameWithEmptyCompany()
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
                companyService.HireEmployee(company, employee1);
                List<Employee> EmployeeList = new List<Employee>();
                Assert.That(companyService.FindEmployeeByLastName("Halushchynskyi", company), Is.EqualTo(EmployeeList));

        }
}
