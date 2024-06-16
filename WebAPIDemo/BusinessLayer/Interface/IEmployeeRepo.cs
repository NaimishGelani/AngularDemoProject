using WebAPIDemo.Data;

namespace WebAPIDemo.BusinessLayer.Interface
{
    public interface IEmployeeRepo
    {
        Task AddEmployee(Employee employee);

        Task<List<Employee>> GetEmployeeList();

        Task<Employee> GetEmployeeById(int id);

        Task UpdateEmployee(int id, Employee employee);

        Task DeleteEmployee(int id);
    }
}
