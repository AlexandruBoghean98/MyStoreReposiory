using MyStore.Domain;

namespace MyStore.Data
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAll();
        Employee? GetEmployeeById(int id);
        Employee Add(Employee employee);
        int Delete(Employee employee);
        Employee Update(Employee employee);
        IEnumerable<Employee> GetAll(int page);
        IQueryable<Employee> GetAll(int page, string text);
    }
}
