using MyStore.Domain;
using System;
using System.Linq;

namespace MyStore.Services
{
    public interface IShipperService
    {
        IEnumerable<Shipper> GetShippers(int page);
        IEnumerable<Shipper> GetShippers(int page, string? text);
        Shipper? GetShipperById(int id);
        Shipper InsertNew(Shipper shipper);
        Shipper Update(Shipper shipper);
        int Remove(Shipper shipper);
    }
}
