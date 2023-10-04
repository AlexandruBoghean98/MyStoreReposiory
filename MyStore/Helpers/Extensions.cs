using MyStore.Domain;
using MyStore.Helpers.Models;

namespace MyStore.Helpers
{
    public static class Extensions
    {

        public static Category ToCategory(this CategoryModel model)
        {
            var category = new Category();

            category.Categoryid = model.CategoryId;
            category.Description = model.Description;
            category.Categoryname = model.CategoryName;

            return category;
        }

        public static CategoryModel ToCategoryModel(this Category domainObject)
        {
            var model = new CategoryModel();

            model.CategoryId = domainObject.Categoryid;
            model.Description = domainObject.Description;
            model.CategoryName = domainObject.Categoryname;

            return model;
        }

        public static Shipper ToShipper(this ShipperModel model)
        {
            var shipper = new Shipper();

            shipper.Shipperid = model.Shipperid;
            shipper.Companyname = model.Companyname;
            shipper.Phone = model.Phone;

            return shipper;
        }

        public static ShipperModel ToShipperModel(this Shipper shipperObject)
        {
            var model = new ShipperModel();

            model.Shipperid = shipperObject.Shipperid;
            model.Companyname = shipperObject.Companyname;
            model.Phone = shipperObject.Phone;

            return model;
        }
    }
}
