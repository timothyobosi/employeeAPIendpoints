using Microsoft.AspNetCore.Mvc;
using empAI.Data;
using empAI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Swashbuckle.AspNetCore.Annotations;

namespace empAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeesController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            // Ensure we are using the correct model and fields
            var employees = await _context.Employees
                .Select(emp => new
                {
                    emp.EmployeeId,
                    emp.EmployeeFirstName,
                    emp.EmployeeLastName,
                    emp.EmployeeDateOfBirth
                    // Make sure you're only selecting the fields that exist in the current database schema
                }).ToListAsync();

            return Ok(employees);
        }

        // GET: api/Employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
            var employee = await _context.Employees
                .Where(emp => emp.EmployeeId == id)
                .Select(emp => new Employee
                {
                    EmployeeId = emp.EmployeeId,
                    EmployeeFirstName = emp.EmployeeFirstName,
                    EmployeeLastName = emp.EmployeeLastName,
                    EmployeeDateOfBirth = emp.EmployeeDateOfBirth
                    // Again, ensure you're selecting the fields that exist in the database
                }).FirstOrDefaultAsync();

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if necessary
                return StatusCode(500, "Internal server error");
            }
        }


        // PUT: api/Employees/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(string id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Employees/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchEmployee(string id, [FromBody] JsonPatchDocument<Employee> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            // Retrieve the employee by ID
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
                return NotFound();

            // Apply the patch to the employee object
            patchDoc.ApplyTo(employee, ModelState);

            // Check if there are any model validation errors
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            

            // Save changes to the database
            _context.SaveChanges();

            return NoContent();
        }



    }
}
