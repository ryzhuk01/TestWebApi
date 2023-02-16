using TestAPI.Data.Interfaces;
using TestAPI.Models;
using TestAPI.Services.Interfaces;

namespace TestAPI.Services;

public class EmployeeService : IEmployeeService
{
    public EmployeeService(IRepository<Employee> employeeRepository)
    {
        EmployeeRepository = employeeRepository;
    }
    private IRepository<Employee> EmployeeRepository { get; }

    public IList<Employee> GetEmployees()
    {
        try
        {
            return EmployeeRepository.GetAll(d => d.JobTitles).ToList();

        }
        catch (Exception) { throw; }
    }
    public void CreateEmployee(Employee employee)
    {
        try
        {
            EmployeeRepository.Add(employee);
            EmployeeRepository.SaveChanges();

        }
        catch (Exception) { throw; }
    }
    public void DeleteEmployeeById(int id)
    {
        try
        {
            var employee = EmployeeRepository.GetById(id);

            if(employee is null)
                throw new KeyNotFoundException(
                    "There is no employee with such id");

            EmployeeRepository.Delete(employee);
            EmployeeRepository.SaveChanges();

        }
        catch (Exception) { throw; }
    }

    public void UpdateEmployee(Employee employee)
    {
        try
        {
            EmployeeRepository.Update(employee);
            EmployeeRepository.SaveChanges();

        }
        catch (Exception) { throw; }
    }
}
