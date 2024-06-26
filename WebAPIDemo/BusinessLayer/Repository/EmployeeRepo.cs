using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDemo.BusinessLayer.Interface;
using WebAPIDemo.Data;

namespace WebAPIDemo.BusinessLayer.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task AddEmployee(EmployeeDTO employee)
        {
            if (employee != null)
            {
                Employee employee1 = new()
                {
                    Name = employee.Name,
                    Age = employee.Age,
                    Salary = employee.Salary,
                    PhoneNumber = employee.PhoneNumber,
                    Email = employee.Email,

                };
                _applicationDbContext.Employees.Add(employee1);
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public Task<List<Employee>> GetEmployeeList()
        {
            return _applicationDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _applicationDbContext.Employees.FindAsync(id);
        }

        public async Task UpdateEmployee(int id, Employee employee)
        {
            Employee? emp = _applicationDbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
            {
                throw new Exception("Employee Not Found");
            }
            emp.Name = employee.Name;
            emp.Email = employee.Email;
            emp.Salary = employee.Salary;
            emp.PhoneNumber = employee.PhoneNumber;
            emp.Age = employee.Age;
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            Employee? emp = _applicationDbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
            {
                throw new Exception("Employee Not Found");
            }
            _applicationDbContext.Employees.Remove(emp);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
