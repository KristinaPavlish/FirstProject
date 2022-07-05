using Microsoft.VisualBasic;
namespace FirstProject.Bll;

public class Employee
{
    private string _fullName;
    private int _workExperience;
    private int _numberOfHoursWorked;
    private int _rateOfCompletedWorks;

    public Employee(string fullName, int workExperience, int numberOfHoursWorked, int rateOfCompletedWorks)
    {
        this._fullName = fullName;
        this._workExperience = workExperience;
        this._numberOfHoursWorked = numberOfHoursWorked;
        this._rateOfCompletedWorks = rateOfCompletedWorks;
    }
    public double CalculationOfWages(int rateOfPayPerHour)
    {
        double salary = _numberOfHoursWorked * rateOfPayPerHour;
        
        if (_numberOfHoursWorked < _rateOfCompletedWorks)
        {
            salary -= salary * 0.2;
        }

        if (_workExperience >= 10 && _workExperience <= 20)
        {
            salary += salary * 0.1;
        }

        if (_workExperience > 20)
        {
            salary += salary * 0.2;
        }

        return salary;
    }

    public string InitialsOfEmployee()
    {
        if (string.IsNullOrEmpty(_fullName))
        {
            return "";
        }
        string[] fullNameOfEmployee = _fullName.Split();
        string firstWordOfFullName = fullNameOfEmployee.First();

        string initials = "";
        initials = firstWordOfFullName + " ";


        string[] initialsWithoutSurname = string.Join(" ", _fullName.Split().Skip(1)).Split();

        initials += string.Join("", initialsWithoutSurname.Select(x => x.Substring(0, 1).ToUpper() + "."));

      /*foreach (string name in initialsWithoutSurname)
        {
            initials += name.Substring(0, 1).ToUpper() + ".";
        }*/

        return initials;
    }


}