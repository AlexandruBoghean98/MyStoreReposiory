using MyStore.Domain;

namespace MyStore.Data
{
    public interface IShipperRepository
    {
        Shipper Add(Shipper shipper);
        int Delete(Shipper shipper);
        IQueryable<Shipper> GetAll();
        IEnumerable<Shipper> GetAll(int page);
        IQueryable<Shipper> GetAll(int page, string? text);
        Shipper? GetShipperById(int id);
        Shipper Update(Shipper shipper);

    }
}
