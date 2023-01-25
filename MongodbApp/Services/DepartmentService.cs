using MongodbApp.Interfaces;
using MongodbApp.Models;

namespace MongodbApp.Services;
public class DepartmentService : IDepartmentService
{
    private readonly IRepository<Department> _departmentService;

    public DepartmentService(IRepository<Department> departmentService)
    {
        _departmentService = departmentService;
    }
    public async Task<Department> GetAsync(string id)
    {
        return await _departmentService.GetAsync(id);
    }
    public async Task<List<Department>> GetAllAsync()
    {
        return await _departmentService.GetAllAsync();
    }
    public async Task<Department> CreateAsync(Department entity)
    {
        return await _departmentService.CreateAsync(entity);
    }
    public async Task<Department> UpdateAsync(string id, Department entity)
    {
        return await _departmentService.UpdateAsync(id, entity);
    }
    public async Task DeleteAsync(string id, Department entity)
    {
        await _departmentService.DeleteAsync(id, entity);
    }
}
