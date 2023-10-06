using MyStore.Domain;

namespace MyStore.Data
{
    public interface ICustomerRepository
    {
        Customer Add(Customer customer);
        int Delete(Customer customer);
        IQueryable<Customer> GetAll();
        IEnumerable<Customer> GetAll(int page);
        IQueryable<Customer> GetAll(int page, string? text);
        Customer? GetCustomerById(int id);
        Customer Update(Customer customer);

    }
}
