using MyStore.Domain;

namespace MyStore.Data
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly StoreContext storeContext;

        public ShipperRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Shipper Add(Shipper shipper)
        {
            var addedEntity = storeContext.Shippers.Add(shipper).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        }

        public int Delete(Shipper shipper)
        {
            storeContext.Shippers.Remove(shipper);
            return storeContext.SaveChanges();
        }

        public IEnumerable<Shipper> GetAll(int page)
        {
            var pageSize = 2;
            var shippers =
                storeContext
                .Shippers
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList();

            return shippers;
        }

        public IQueryable<Shipper> GetAll(int page, string? text)
        {
            var pageSize = 2;
            var shippers = storeContext.Shippers.AsQueryable();

            if (!string.IsNullOrEmpty(text))
            {
                shippers = shippers.Where(c => c.Companyname.Contains(text));
            }

            shippers = shippers.Skip(pageSize * (page - 1)).Take(pageSize);

            return shippers;
        }

        public IQueryable<Shipper> GetAll()
        {
            return storeContext.Shippers;
        }

        public Shipper? GetShipperById(int id)
        {
            return storeContext.Shippers.Find(id);
        }

        public Shipper Update(Shipper shipper)
        {
            var updatedShipper = storeContext.Shippers.Update(shipper).Entity;
            storeContext.SaveChanges();
            return updatedShipper;
        }
    }
}
