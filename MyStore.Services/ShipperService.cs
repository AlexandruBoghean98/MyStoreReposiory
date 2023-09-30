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
        private readonly IShipperRepository shipperService;

        public ShipperService(IShipperRepository shipperService)
        {
            this.shipperService = shipperService;
        }

        public Shipper? GetShipper(int id)
        {
            return shipperService.GetCategoryById(id);
        }
    }
}
