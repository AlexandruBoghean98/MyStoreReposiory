using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Helpers;
using MyStore.Helpers.Models;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShipperRepository repository;

        public ShippersController(IShipperRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Create(ShipperModel shipperModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shipperToSave = shipperModel.ToShipper();
            repository.Add(shipperToSave);

            return CreatedAtAction(nameof(GetById), new { id = shipperToSave.Shipperid }, shipperToSave.ToShipperModel());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var shipper = repository.GetCategoryById(id);
            if (shipper == null)
            {
                return NotFound();
            }
            repository.Delete(shipper);

            return NoContent();
        }

        [HttpGet]
        public IEnumerable<ShipperModel> Get()
        {
            var allShippers = repository.GetAll();

            var shipperModelsToReturn = new List<ShipperModel>();
            foreach (var shipper in allShippers)
            {
                shipperModelsToReturn.Add(shipper.ToShipperModel());
            }

            return shipperModelsToReturn;
        }

        [HttpGet("{id}")]
        public ActionResult<ShipperModel> GetById(int id)
        {
            var shipper = repository.GetCategoryById(id);
            if (shipper == null)
            {
                return NotFound();
            }

            return Ok(shipper.ToShipperModel());
        }

        [HttpPut("{id}")]
        public ActionResult<ShipperModel> Update(int id, ShipperModel shipperModel)
        {
            var existingShipper = repository.GetCategoryById(id);
            if (existingShipper == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingShipper);

            var shipperToUpdate = shipperModel.ToShipper();
            repository.Update(shipperToUpdate);

            return Ok(shipperToUpdate.ToShipperModel());
        }

    }
}
