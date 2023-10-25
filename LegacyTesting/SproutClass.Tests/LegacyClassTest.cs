using Moq;

namespace SproutClass.Tests
{
  public class EmployeesTest
  {
    [Fact]
    public void GetEmployeesData_ReturnsSalaries()
    {
      // Create new mock from the instance and set an object return to mock simulate that return
      var currentDataObj = new Mock<IEmployeeService>();
      currentDataObj.Setup(x => x.GetEmployeesData()).Returns(new List<Employee> { new Employee() { UniqueId = 1, Salary = 100 } });
      var salaryData = new EmployeeSalaryService().GetEmployeesData();

      Assert.Equivalent(currentDataObj.Object.GetEmployeesData(), salaryData);
    }
  }
}