using System.Runtime.Intrinsics.X86;
using FirstProject.Bll.Enums;
using FirstProject.Bll.Interfaces;
using FirstProject.Bll.Models;

namespace FirstProject.Bll.Implementations;

public class TextFileService:IFileService
{
    public StatusEnum Save(Company company, string fileName)
    {
        try
        {
            string text = company.Name + '\n';
            foreach (var employee in company.Employees)
            {
                text += employee.FullName + ", " + employee.HourlyWage + ", " + employee.WorkExperience +
                        ", " + employee.NumberOfHoursWorked + ", " + employee.RateOfCompletedWorks + '\n';
            }
            
            File.WriteAllText(fileName, text);
            return StatusEnum.Success;
        }
        catch (Exception exception)
        {
            return StatusEnum.Error;
        }
    }

    public Company Upload(string fileName)
    {
        Company company = new Company();
        company.Employees = new List<Employee>();
        string[] lines = File.ReadAllLines(fileName);
        company.Name = lines[0];
        foreach (var employee in lines)
        {
            Employee employees = new Employee();
            if (string.IsNullOrEmpty(employee))
            {
                continue;
            }

            string[] splittedEmployee = employee.Split(", ");
            if (splittedEmployee.Count() == 1)
            {
                continue;
            }

            employees.FullName = splittedEmployee[0];
            employees.HourlyWage = Convert.ToUInt32(splittedEmployee[1]);
            employees.WorkExperience = Convert.ToUInt32(splittedEmployee[2]);
            employees.NumberOfHoursWorked = Convert.ToUInt32(splittedEmployee[3]);
            employees.RateOfCompletedWorks = Convert.ToUInt32(splittedEmployee[4]);
            company.Employees.Add(employees);
        }

        return company;
    }
}