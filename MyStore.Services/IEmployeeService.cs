using MyStore.Domain;
using System;
using System.Linq;

namespace MyStore.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees(int page);
        IEnumerable<Employee> GetEmployees(int page, string? text);
        Employee? GetEmployee(int id);
        Employee InsertNew(Employee employee);
        bool IsHired(string firstNameEmployee, string lastNameEmployee, DateTime birthday);
        int Remove(Employee employee);
        Employee Update(Employee employee);
    }
}
