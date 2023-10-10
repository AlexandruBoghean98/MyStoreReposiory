using MyStore.Data;
using MyStore.Domain;

namespace MyStore.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Employee? GetEmployee(int id)
        {
            return employeeRepository.GetEmployeeById(id);
        }

        public IEnumerable<Employee> GetEmployees(int page)
        {
            return employeeRepository.GetAll(page);
        }

        public IEnumerable<Employee> GetEmployees(int page, string? text)
        {
            return employeeRepository.GetAll(page, text);
        }

        public Employee InsertNew(Employee employee)
        {
            return employeeRepository.Add(employee);
        }

        public bool IsHired(string firstName, string lastName, DateTime birthday)
        {
            var employees = employeeRepository.GetAll();
            employees = employees.Where(name =>
                name.Firstname == firstName &&
                name.Lastname == lastName &&
                name.Birthdate == birthday);

            return employees.ToList().Any();
        }

        public int Remove(Employee employee)
        {
            return employeeRepository.Delete(employee);
        }

        public Employee Update(Employee employee)
        {
            return employeeRepository.Update(employee);
        }
    }
}
