namespace FirstProject.Bll.Models;
public class Employee
{
    public string FullName { get; set; }
    public uint WorkExperience{ get; set; }
    public uint NumberOfHoursWorked{ get; set; }
    public uint RateOfCompletedWorks{ get; set; }
    public uint HourlyWage{ get; set; }

    public bool IsValid()
    {
        var result = !string.IsNullOrEmpty(FullName) && WorkExperience != 0 && NumberOfHoursWorked != 0 &&
                     RateOfCompletedWorks != 0 && HourlyWage != 0;
        return result;
    }
}