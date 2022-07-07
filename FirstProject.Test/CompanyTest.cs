using FirstProject.Bll;

namespace FirstProject.Test;

public class CompanyTest
{
        [Test]
        public void CalculateTotalHoursForRightCompany()
        {
                Company company = new Company();
                company.EmployeeList = new List<Employee>();
                // TODO ADD company.HireEmloyee(employee1);
                Employee employee1 = new Employee("Halushchynskyi Dmytro Ivanovych", 12, 7, 8,43);
                Employee employee2 = new Employee(null, 6, 7, 8,22);
                Employee employee3 = new Employee("Ivasiuk Olena Igorovna", 23, 8, 8,98);

                company.EmployeeList.Add(employee1);
                company.EmployeeList.Add(employee2);
                company.EmployeeList.Add(employee3);
                
                Assert.That(company.CalculateTotalHours(), Is.EqualTo(22));
        }
        
        [Test]
        public void CalculateTotalHoursForEmptyCompany()
        {
                Company company = new Company();
                Assert.That(company.CalculateTotalHours(), Is.EqualTo(0));
        }
        
        [Test]
        public void GetMostExperiencedEmployeeForAllTheSameExperience()
        {
                Company company = new Company();
                // TODO employeeList -> private                 
                Employee employee1 = new Employee("Halushchynskyi Dmytro Ivanovych", 10, 7, 8,43);
                Employee employee2 = new Employee(null, 10, 7, 8,34);
                Employee employee3 = new Employee("Ivasiuk Olena Igorovna", 10, 8, 8,53);

                company.EmployeeList.Add(employee1);
                company.EmployeeList.Add(employee2);
                company.EmployeeList.Add(employee3);
                
                Assert.That(company.CalculateTotalHours(), Is.EqualTo(10));

        }
        [Test]
        public void GetMostExperiencedEmployeeForRightExperience()
        {
                Company company = new Company();
                company.EmployeeList = new List<Employee>();
                
                Employee employee1 = new Employee("Halushchynskyi Dmytro Ivanovych", 10, 7, 8,66);
                Employee employee2 = new Employee("Igor", 30, 7, 8,76);
                Employee employee3 = new Employee("Ivasiuk Olena Igorovna", 15, 8, 8,56);

                company.EmployeeList.Add(employee1);
                company.EmployeeList.Add(employee2);
                company.EmployeeList.Add(employee3);
                
                Assert.That(company.CalculateMostExperiencedEmployee(), Is.EqualTo(30));

        }
      [Test]
        public void GetEmployeeWithMaxSalaryForRightSalary()
        {
                Company company = new Company();
                company.EmployeeList = new List<Employee>();
                
                Employee employee1 = new Employee("Ivasiuk Olena Igorovna", 23, 8, 8,45);
                Employee employee2 = new Employee("Halushchynskyi Dmytro Ivanovych", 12, 7, 8,45);
                Employee employee3 = new Employee(null, 6, 7, 8,22);
                Employee employee4 = new Employee("Ivasiuk Olena Igorovna", 23, 8, 8,45);

                company.EmployeeList.Add(employee1);
                company.EmployeeList.Add(employee2);
                company.EmployeeList.Add(employee3);
                company.EmployeeList.Add(employee4);

                List<Employee> employeeWithMaxSalary = new List<Employee>();
                
                employeeWithMaxSalary.Add(employee1);
                employeeWithMaxSalary.Add(employee4);

                Assert.That(company.GetEmployeeWithMaxSalary(), Is.EqualTo(employeeWithMaxSalary));
        }
        
// TODO count right salary
        [Test]
        public void CountEmployeeWithMaxSalaryForRightSalary()
        {
                Company company = new Company();
                company.EmployeeList = new List<Employee>();

                Employee employee1 = new Employee("Ivasiuk Olena Igorovna", 23, 8, 8,34);
                Employee employee2 = new Employee("Halushchynskyi Dmytro Ivanovych", 12, 7, 8,43);
                Employee employee3 = new Employee(null, 6, 7, 8,53);

                company.EmployeeList.Add(employee1);
                company.EmployeeList.Add(employee2);
                company.EmployeeList.Add(employee3);

                Assert.That(company.CalculateMaxSalary(), Is.EqualTo(326));
        }
        [Test]
        public void GetEmployeeWithMaxSalaryForEmptyCompany()
        {
                Company company = new Company();
                company.EmployeeList = new List<Employee>();
                
                Assert.That(company.GetEmployeeWithMaxSalary(), Is.EqualTo(null));
        }

        public void RemoveEmployeeByExperienceAgeForRightCompany()
        {
                Company company = new Company();
                company.EmployeeList = new List<Employee>();
                
                Employee employee1 = new Employee("Ivasiuk Olena Igorovna", 23, 8, 8,35);
                Employee employee2 = new Employee("Halushchynskyi Dmytro Ivanovych", 12, 7, 8,67);
                Employee employee3 = new Employee(null, 6, 7, 8,76);

                company.EmployeeList.Add(employee1);
                company.EmployeeList.Add(employee2);
                company.EmployeeList.Add(employee3);
                
                Company companyAfterRemove = new Company();
                companyAfterRemove.EmployeeList = new List<Employee>();
                companyAfterRemove.EmployeeList.Add(employee1);

                Assert.That(company.RemoveEmployeeByExperienceAge(12), Is.EqualTo(companyAfterRemove));

        }
        public void RemoveEmployeeByExperienceAgeForEmptyCompany()
        {
                Company company = new Company();
                company.EmployeeList = new List<Employee>();

                Assert.That(company, Is.EqualTo(null));
        }

        public void FindEmployeeByLastNameForRightCompany()
        {
         
                Company company = new Company();
                company.EmployeeList = new List<Employee>();
                
                Employee employee1 = new Employee("Ivasiuk Olena Igorovna", 23, 8, 8,45);
                Employee employee2 = new Employee("Halushchynskyi Dmytro Ivanovych", 12, 7, 8,56);
                Employee employee3 = new Employee(null, 6, 7, 8,64);

                company.EmployeeList.Add(employee1);
                company.EmployeeList.Add(employee2);
                company.EmployeeList.Add(employee3);
                
                Company companyAfterFinding = new Company();
                companyAfterFinding.EmployeeList = new List<Employee>();
                companyAfterFinding.EmployeeList.Add(employee1);

                Assert.That(company.FindEmployeeByLastName("Ivasiuk"), Is.EqualTo(employee1));
                
        }

        public void FindEmployeeByLastNameForEmptyCompany()
        {
                Company company = new Company();
                company.EmployeeList = new List<Employee>();
                
                Assert.That(company.FindEmployeeByLastName("Ivasiuk"), Is.EqualTo(null));
        }
        // TODO if is two the same last name in FindEmployeeByLastName();
        
}
