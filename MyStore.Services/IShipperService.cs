using MyStore.Domain;
using System;
using System.Linq;

namespace MyStore.Services
{
    public interface IShipperService
    {
        Shipper? GetShipper(int id);
    }
}
