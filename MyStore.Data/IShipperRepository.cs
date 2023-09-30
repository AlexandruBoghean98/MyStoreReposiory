using MyStore.Domain;
using System;
using System.Linq;

namespace MyStore.Data
{
    public interface IShipperRepository
    {
        Shipper Add(Shipper shipper);
        int Delete(Shipper shipper);
        IEnumerable<Shipper> GetAll();
        Shipper? GetCategoryById(int id);
        Shipper Update(Shipper shipper);
    }
}
