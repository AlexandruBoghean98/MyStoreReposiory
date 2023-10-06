using MyStore.Domain;

namespace MyStore.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreContext storeContext;
        public CustomerRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }
        public Customer Add(Customer customer)
        {
            var addedEntity = storeContext.Customers.Add(customer).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        }

        public int Delete(Customer customer)
        {
            storeContext.Customers.Remove(customer);
            return storeContext.SaveChanges();
        }

        public IQueryable<Customer> GetAll()
        {
            return storeContext.Customers;
        }

        public IEnumerable<Customer> GetAll(int page)
        {
            var pageSize = 2;
            var customers =
                 storeContext
                .Customers
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList();

            return customers;
        }

        public IQueryable<Customer> GetAll(int page, string? text)
        {
            var pageSize = 2;
            var customers = storeContext.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(text))
            {
                customers = customers.Where(c => 
                    c.Companyname.Contains(text) || c.Contactname.Contains(text));
            }

            customers = customers.Skip(pageSize * (page - 1))
                .Take(pageSize);

            return customers;
        }

        public Customer? GetCustomerById(int id)
        {
            return storeContext.Customers.Find(id);
        }

        public Customer Update(Customer customer)
        {
            var updatedCustomer = storeContext.Customers.Update(customer).Entity;
            storeContext.SaveChanges();
            return updatedCustomer;
        }
    }
}
