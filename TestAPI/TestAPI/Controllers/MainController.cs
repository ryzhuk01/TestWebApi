using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;
using TestAPI.Services.Interfaces;

namespace TestAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MainController : ControllerBase
{
    public MainController(IEmployeeService employeeService,
        IJobTitleService jobTitleService)
    {
        EmployeeService = employeeService;
        JobTitleService = jobTitleService;
    }

    public IEmployeeService EmployeeService { get; }
    public IJobTitleService JobTitleService { get; }

    [HttpGet("Employees")]
    public IActionResult GetAllEmployees()
    {
        try
        {
            return Ok(EmployeeService.GetEmployees());
        }
        catch (Exception ex)
        {
            return ex switch
            {
                _ => Problem(ex.Message)
            };
        }
    }


    [HttpPost("Employee")]
    public IActionResult CreateEmployee([FromBody] Employee employee)
    {
        try
        {
            EmployeeService.CreateEmployee(employee);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            return ex switch
            {
                _ => Problem(ex.Message)
            };
        }
    }

    [HttpDelete("Employee")]
    public IActionResult DeleteEmployee(int id)
    {
        try
        {
            EmployeeService.DeleteEmployeeById(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return ex switch
            {
                KeyNotFoundException => NotFound(ex.Message),
                _ => Problem(ex.Message)
            };
        }
    }

    [HttpPut("Employee")]
    public IActionResult UpdateEmployee(Employee employee)
    {
        try
        {

            EmployeeService.UpdateEmployee(employee);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            return ex switch
            {
                _ => Problem(ex.Message)
            };
        }
    }


    [HttpGet("JobTitles")]
    public IActionResult GetAllJobTitles()
    {
        try
        {
            return Ok(JobTitleService.GetJobTitles());
        }
        catch (Exception ex)
        {
            return ex switch
            {
                _ => Problem(ex.Message)
            };
        }
    }

    [HttpPost("JobTitle")]
    public IActionResult CreateJobTitle([FromBody] JobTitle jobTitle)
    {
        try
        {
            JobTitleService.CreateJobTitles(jobTitle);
            return Ok();
        }
        catch (Exception ex)
        {
            return ex switch
            {
                _ => Problem(ex.Message)
            };
        }
    }

    [HttpDelete("JobTitle")]
    public IActionResult DeleteJobTitle(int id)
    {
        try
        {

            JobTitleService.DeleteJobTitleById(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return ex switch
            {
                InvalidOperationException => BadRequest(ex.Message),
                KeyNotFoundException => NotFound(ex.Message),
                _ => Problem(ex.Message)
            };
        }
    }

    [HttpPut("JobTitle")]
    public IActionResult UpdateJobTitle(JobTitle jobTitle)
    {
        try
        {
            JobTitleService.UpdateJobTitle(jobTitle);
            return Ok(jobTitle);
        }
        catch (Exception ex)
        {
            return ex switch
            {
                _ => Problem(ex.Message)
            };
        }
    }
}