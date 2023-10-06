using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Helpers.Models;
using MyStore.Services;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomersController>

        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Create(CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: buisiness rules
            //if (categoryService.IsDuplicated(model.CategoryName))
            //{
            //    ModelState.AddModelError(nameof(model.CategoryName), $"Category {model.CategoryName} already exists");
            //    return Conflict(ModelState);
            //}
            var customerToSave = new Customer();
            customerToSave = model.ToCustomer();

            customerService.InsertNew(customerToSave);

            //return Ok(categoryToAdd);
            return CreatedAtAction(nameof(GetById), new { id = customerToSave.Custid }, customerToSave.ToCustomerModel());
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            customerService.Remove(customer);

            return NoContent();
        }

        [HttpGet]
        public IEnumerable<CustomerModel> Get(string? text, int pag = 1)
        {
            var allCustomers = customerService.GetCustomers(pag, text);

            var modelToReturn = new List<CustomerModel>();
            foreach (var customer in allCustomers)
            {
                modelToReturn.Add(customer.ToCustomerModel());
            }

            return modelToReturn;
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerModel> GetById(int id)
        {
            var customerFromDb = customerService.GetCustomer(id);
            if (customerFromDb == null)
            {
                return NotFound();
            }

            var model = customerFromDb.ToCustomerModel();

            return Ok(model);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public ActionResult<CustomerModel> Update(int id, CustomerModel model)
        {
            var existingCustomer = customerService.GetCustomer(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingCustomer);

            var customerToUpdate = model.ToCustomer();
            customerService.Update(customerToUpdate);

            return Ok(customerToUpdate.ToCustomerModel());
        }
    }
}
