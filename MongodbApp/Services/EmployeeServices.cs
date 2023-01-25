using MongodbApp.Interfaces;
using MongodbApp.Models;

namespace MongodbApp.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeServices(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> GetAsync(string id)
        {
            return await _employeeRepository.GetAsync(id);
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }
        public async Task<Employee> CreateAsync(Employee entity)
        {
            return await _employeeRepository.CreateAsync(entity);
        }
        public async Task<Employee> UpdateAsync(string id, Employee entity)
        {
            return await _employeeRepository.UpdateAsync(id, entity);
        }
        public async Task DeleteAsync(string id, Employee entity)
        {
            await _employeeRepository.DeleteAsync(id, entity);
        }
    }
}
