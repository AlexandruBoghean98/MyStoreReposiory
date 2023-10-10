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

        public static Customer ToCustomer(this CustomerModel model)
        {
            var customer = new Customer();

            customer.Custid = model.Custid;
            customer.Companyname = model.Companyname;
            customer.Contactname = model.Contactname;
            customer.Contacttitle = model.Contacttitle;
            customer.Address = model.Address;
            customer.City = model.City;
            customer.Region = model.Region;
            customer.Postalcode = model.Postalcode;
            customer.Country = model.Country;
            customer.Phone = model.Phone;
            customer.Fax = model.Fax;

            return customer;
        }

        public static CustomerModel ToCustomerModel(this Customer customerObject)
        {
            var model = new CustomerModel();

            model.Custid = customerObject.Custid;
            model.Companyname = customerObject.Companyname;
            model.Contactname = customerObject.Contactname;
            model.Contacttitle = customerObject.Contacttitle;
            model.Address = customerObject.Address;
            model.City = customerObject.City;
            model.Region = customerObject.Region;
            model.Postalcode = customerObject.Postalcode;
            model.Country = customerObject.Country;
            model.Phone = customerObject.Phone;
            model.Fax = customerObject.Fax;

            return model;
        }

        public static Employee ToEmployee(this EmployeeModel model)
        {
            var employee = new Employee();

            employee.Empid = model.Empid;
            employee.Firstname = model.Firstname;
            employee.Lastname = model.Lastname;
            employee.Title = model.Title;
            employee.Phone = model.Phone;
            employee.Birthdate = model.Birthdate;
            employee.Address = model.Address;
            employee.City = model.City;
            employee.Region = model.Region;
            employee.Postalcode = model.Postalcode;
            employee.Country = model.Country;
            employee.Titleofcourtesy = model.Titleofcourtesy;
            employee.Hiredate = model.Hiredate;
            employee.Mgrid = model.Mgrid;

            return employee;
        }

        public static EmployeeModel ToEmployeeModel(this Employee employeeObject)
        {
            var employeeModel = new EmployeeModel();

            employeeModel.Empid = employeeObject.Empid;
            employeeModel.Firstname = employeeObject.Firstname;
            employeeModel.Lastname = employeeObject.Lastname;
            employeeModel.Title = employeeObject.Title;
            employeeModel.Phone = employeeObject.Phone;
            employeeModel.Birthdate = employeeObject.Birthdate;
            employeeModel.Address = employeeObject.Address;
            employeeModel.City = employeeObject.City;
            employeeModel.Region = employeeObject.Region;
            employeeModel.Postalcode = employeeObject.Postalcode;
            employeeModel.Country = employeeObject.Country;
            employeeModel.Titleofcourtesy = employeeObject.Titleofcourtesy;
            employeeModel.Hiredate = employeeObject.Hiredate;
            employeeModel.Mgrid = employeeObject.Mgrid;

            return employeeModel;
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
