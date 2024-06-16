using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.BusinessLayer.Interface;
using WebAPIDemo.Data;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] Employee employeeModel)
        {
            await _employeeRepo.AddEmployee(employeeModel);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployeeList()
        {
            List<Employee> list = await _employeeRepo.GetEmployeeList();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            Employee? employee = await _employeeRepo.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployeeById([FromRoute] int id, [FromBody] Employee employee)
        {
            await _employeeRepo.UpdateEmployee(id, employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeById([FromRoute] int id)
        {
            if(id ==0)
            {
                return BadRequest();
            }
            await _employeeRepo.DeleteEmployee(id);
            return Ok();
        }   
    }
}
