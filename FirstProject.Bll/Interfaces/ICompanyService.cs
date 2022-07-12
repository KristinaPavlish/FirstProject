using FirstProject.Bll.Models;

namespace FirstProject.Bll.Interfaces;

public interface ICompanyService
{
   void HireEmployee(Company company, Employee employee);
   uint CalculateTotalHours(Company company);
   double CalculateMaxSalary(Company company);
   List<Employee> CalculateMostExperiencedEmployee(Company company);
   List<Employee> GetEmployeeWithMaxSalary(Company company);
   void RemoveEmployeeByExperienceAge(uint lowerAge, Company company);
   List<Employee> FindEmployeeByLastName(string lastName, Company company);
}