using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly StoreContext storeContext;
        public EmployeeRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }
        public Employee Add(Employee employee)
        {
            var addedEntity = storeContext.Employees.Add(employee).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        }

        public int Delete(Employee employee)
        {
            storeContext.Employees.Remove(employee);
            return storeContext.SaveChanges();
        }

        public IQueryable<Employee> GetAll()
        {
            return storeContext.Employees;
        }

        public IEnumerable<Employee> GetAll(int page)
        {
            var pageSize = 2;
            var employees = 
                 storeContext
                .Employees
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList();

            return employees;
        }

        public IQueryable<Employee> GetAll(int page, string text)
        {
            throw new NotImplementedException();
        }

        public Employee? GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
