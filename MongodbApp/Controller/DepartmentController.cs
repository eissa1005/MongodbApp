using Microsoft.AspNetCore.Mvc;
using MongodbApp.Interfaces;
using MongodbApp.Models;

namespace MongodbApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService service;
        public DepartmentController(IDepartmentService service)
        {
            this.service = service;
        }

        [HttpPost("adddepart")]
        public async Task<IActionResult> CreateDepart([FromBody] Department model)
        {
            var result = await service.CreateAsync(model);
            if (result == null)
                return BadRequest("Depart is empaty");

            return Ok(result);
        }

        [HttpGet("alldepart")]
        public async Task<List<Department>> GetDepartments()
        {
            return await service.GetAllAsync();
        }

        [HttpPost("editdepart")]
        public async Task<Department> Edit([FromBody] Department model)
        {
            return await service.UpdateAsync(model.Id, model);
        }

        [HttpPost("delDpart")]
        public async Task DeleteDepart([FromBody] Department model)
        {
            await service.DeleteAsync(model.Id, model);
        }
    }
}
