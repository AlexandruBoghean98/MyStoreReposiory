using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository shipperRepository;

        public ShipperService(IShipperRepository shipperRepository)
        {
            this.shipperRepository = shipperRepository;
        }

        public Shipper? GetShipperById(int id)
        {
            return shipperRepository.GetShipperById(id);
        }

        public IEnumerable<Shipper> GetShippers(int page)
        {
            return shipperRepository.GetAll(page);
        }

        public IEnumerable<Shipper> GetShippers(int page, string? text)
        {
            return shipperRepository.GetAll(page, text);
        }

        public Shipper InsertNew(Shipper shipper)
        {
            return shipperRepository.Add(shipper);
        }

        public int Remove(Shipper shipper)
        {
            return shipperRepository.Delete(shipper);
        }
        public Shipper Update(Shipper shipper)
        {
            return shipperRepository.Update(shipper);
        }

    }
}
