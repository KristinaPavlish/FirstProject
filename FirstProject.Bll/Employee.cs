namespace FirstProject.Bll;
// TODO refactor code to use Employee model 
// TODO employee on this file become to Employee service to process employee model

public class Employee
{
    private string _fullName;
    private uint _workExperience;
    private uint _numberOfHoursWorked;
    private uint _rateOfCompletedWorks;
    private uint _hourlyWage;

    public override string ToString()
    {
        return _fullName;
    }

    public string GetName()
    {
        return _fullName;
    }

    public uint GetRateOfCompletedWorks()
    {
        return _rateOfCompletedWorks;
    }

    public uint GetNumberOfHoursWorked()
    {
        return _numberOfHoursWorked;
    }

    public uint GetExperience()
    {
        return _workExperience;
    }
    
    public Employee(string fullName, uint workExperience, uint numberOfHoursWorked, uint rateOfCompletedWorks, uint hourlyWage)
    {
       _fullName = fullName;
       _workExperience = workExperience;
       _numberOfHoursWorked = numberOfHoursWorked;
       _rateOfCompletedWorks = rateOfCompletedWorks;
       _hourlyWage = hourlyWage;
    }
    public Employee(){}
    public double CalculationOfWages()
    {
        double salary = _numberOfHoursWorked * _hourlyWage;
        
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

        return initials;
    }


}