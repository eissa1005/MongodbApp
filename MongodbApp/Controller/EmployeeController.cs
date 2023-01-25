using Microsoft.AspNetCore.Mvc;
using MongodbApp.Models;
using MongodbApp.Services;

namespace MongodbApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeServices services;
        public EmployeeController(EmployeeServices services)
        {
            this.services = services;
        }

        [HttpPost("addemployee")]
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            return await services.CreateAsync(employee);
        }

        [HttpGet("getemployee")]
        public async Task<Employee> GetEmployee(string id)
        {
            return await services.GetAsync(id);
        }

        [HttpGet("allemployee")]
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await services.GetAllAsync();
        }

        [HttpPost("editemployee")]
        public async Task<Employee> Edit(string id, Employee employee)
        {
            return await services.UpdateAsync(id, employee);
        }

        [HttpDelete("delemployee")]
        public async Task Delete(string id,Employee employee)
        {
            await services.DeleteAsync(id, employee);
        }

    }
}
