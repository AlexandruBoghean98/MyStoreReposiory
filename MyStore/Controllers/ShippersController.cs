using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly StoreContext context;
        public ShippersController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Shipper> Get()
        {
            var allShoppers = context.Shippers.ToList();
            return allShoppers;
        }

        [HttpGet("{id}")]
        public Shipper GetById(int id)
        {
            var shipper = context.Shippers.Find(id);
            return shipper;
        }

        [HttpPost]
        public Shipper Create(Shipper shipperToAdd)
        {
            context.Shippers.Add(shipperToAdd);
            context.SaveChanges();

            return shipperToAdd;
        }

        [HttpPut("{id}")]
        public Shipper Update(int id, Shipper shipper)
        {
            var shipperToUpdate = context.Shippers.Find(id);
            if(shipperToUpdate != null)
            {
                TryUpdateModelAsync(shipperToUpdate);
                context.Shippers.Update(shipper);
                context.SaveChanges();
            }

            return shipper;
        }


        [HttpDelete("{id}")]
        public Shipper? Delete(int id)
        {
            var shipper = context.Shippers.Find(id);
            if (shipper != null)
            {
                context.Shippers.Remove(shipper);
                context.SaveChanges();
            }

            return null;
        }

    }
}
