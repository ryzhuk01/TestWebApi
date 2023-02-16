using TestAPI.Models;

namespace TestAPI.Services.Interfaces;

public interface IEmployeeService
{
    public IList<Employee> GetEmployees();
    public void CreateEmployee(Employee employee);
    public void DeleteEmployeeById(int id);
    public void UpdateEmployee(Employee employee);

}
