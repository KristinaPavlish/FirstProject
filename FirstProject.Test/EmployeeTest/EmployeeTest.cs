using FirstProject.Bll;
namespace FirstProject.Test;

public class EmployeeTests
{
    [Test]
    public void InitiateEmployeeWithRightParams()
    {
        Employee employee = new Employee("Halushchynskyi Dmytro Ivanovych", 12, 7, 8,43);
        Assert.That(employee.ToString(), Is.EqualTo("Halushchynskyi Dmytro Ivanovych"));
    }

    [Test]
    public void TotalSalaryForRightParams()
    {
        Employee employee = new Employee("Halushchynskyi Dmytro Ivanovych", 9, 8, 8,34);
        var actual = employee.CalculationOfWages();
        var expected = 8 * 34;
        Assert.That(actual, Is.EqualTo(expected));
    }
    // create all unit tests for method in employee class  
}