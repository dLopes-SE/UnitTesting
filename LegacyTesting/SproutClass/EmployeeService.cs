using System.Collections.Generic;
using System.Linq;

namespace SproutClass
{
  public class EmployeeService : IEmployeeService
  {
    public List<Employee> GetEmployeesData()
    {
      var result = new List<Employee>();

      // var listFromdb = databaseService.GetEmployees();
      // add the list of employees to the 'result' object

      // Sample data:
      result.Add(new Employee { FirstName = "Harry", LastName = "Potter", UniqueId = 1 });

      var salaryDataService = new EmployeeSalaryService();
      var salaries = salaryDataService.GetEmployeesData();

      // Update the first list with the salaries
      result.Select(x => x.Salary = salaries.FirstOrDefault(s => s.UniqueId == x.UniqueId).Salary);
      return result;
    }
  }
}
