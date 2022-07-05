using FirstProject.Bll;

namespace FirstProject.Test;

public class Tests
{
    [Test]
    public void InitiateEmployeeWithRightParams()
    {
        Employee employee = new Employee("Halushchynskyi Dmytro Ivanovych", 12, 7, 8);

        Assert.That(employee.ToString(), Is.EqualTo("Halushchynskyi Dmytro Ivanovych"));
    }

    [Test]
    public void TotalSalaryForRightParams()
    {
        Employee employee = new Employee("Halushchynskyi Dmytro Ivanovych", 9, 8, 8);
        var actual = employee.CalculationOfWages(45);
        var expected = 8 * 45;
        Assert.That(actual, Is.EqualTo(expected));
    }
}