using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Helpers.Models;
using MyStore.Services;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShipperService shipperService;

        public ShippersController(IShipperService shipperService)
        {
            this.shipperService = shipperService;
        }

        [HttpPost]
        public IActionResult Create(ShipperModel shipperModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shipperToSave = new Shipper();
            shipperToSave = shipperModel.ToShipper();

            return CreatedAtAction(nameof(GetById), new { id = shipperToSave.Shipperid }, shipperToSave.ToShipperModel());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var shipper = shipperService.GetShipperById(id);
            if (shipper == null)
            {
                return NotFound();
            }
            shipperService.Remove(shipper);

            return NoContent();
        }

        [HttpGet]
        public IEnumerable<ShipperModel> Get(string? text, int page = 1)
        {
            var allShippers = shipperService.GetShippers(page, text);

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
            var shipper = shipperService.GetShipperById(id);
            if (shipper == null)
            {
                return NotFound();
            }

            return Ok(shipper.ToShipperModel());
        }

        [HttpPut("{id}")]
        public ActionResult<ShipperModel> Update(int id, ShipperModel shipperModel)
        {
            var existingShipper = shipperService.GetShipperById(id);
            if (existingShipper == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingShipper);

            var shipperToUpdate = shipperModel.ToShipper();
            shipperService.Update(shipperToUpdate);

            return Ok(shipperToUpdate.ToShipperModel());
        }

    }
}
