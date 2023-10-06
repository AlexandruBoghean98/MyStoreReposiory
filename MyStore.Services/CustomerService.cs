using MyStore.Data;
using MyStore.Domain;

namespace MyStore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IQueryable<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }

        public Customer? GetCustomer(int id)
        {
            return customerRepository.GetCustomerById(id);
        }

        public IEnumerable<Customer> GetCustomers(int page)
        {
            return customerRepository.GetAll(page);
        }

        public IEnumerable<Customer> GetCustomers(int page, string? text)
        {
            throw new NotImplementedException();
        }

        public Customer InsertNew(Customer customer)
        {
            return customerRepository.Add(customer);
        }

        public int Remove(Customer customer)
        {
            return customerRepository.Delete(customer);
        }

        public Customer Update(Customer customer)
        {
            return customerRepository.Update(customer);
        }
    }
}
