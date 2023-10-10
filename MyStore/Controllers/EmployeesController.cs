using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Helpers.Models;
using MyStore.Services;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (employeeService.IsHired(person.Firstname, person.Lastname, person.Birthdate))
            {
                ModelState.AddModelError(nameof(person.Firstname), $"The person {person.Firstname} {person.Lastname}, with the date of birth {person.Birthdate}, is already hired.");
                return Conflict(ModelState);
            }

            var personToHire = new Employee();
            personToHire = person.ToEmployee();

            employeeService.InsertNew(personToHire);

            return CreatedAtAction(nameof(GetById), new { id = personToHire.Empid }, personToHire.ToEmployeeModel());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            employeeService.Remove(employee);

            return NoContent();
        }

        [HttpGet]
        public ActionResult<EmployeeModel> Get(string? name, int page)
        {
            var allEmployees = employeeService.GetEmployees(page, name);
            var modelsToReturn = new List<EmployeeModel>();
            foreach (var employee in allEmployees)
            {
                modelsToReturn.Add(employee.ToEmployeeModel());
            }

            return Ok(modelsToReturn);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeModel> GetById(int id)
        {
            var employeeFromDb = employeeService.GetEmployee(id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }

            var model = employeeFromDb.ToEmployeeModel();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public ActionResult<EmployeeModel> Update(int id, EmployeeModel model)
        {
            var existingEmployee = employeeService.GetEmployee(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingEmployee);

            var employeeToUpdate = model.ToEmployee();
            employeeService.Update(employeeToUpdate);

            return Ok(employeeToUpdate.ToEmployeeModel());
        }
    }
}
