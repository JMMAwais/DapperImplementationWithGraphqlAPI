using DapperImplementationWithGraphqlAPI.Models;

namespace DapperImplementationWithGraphqlAPI.Services
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployees();
        Task<Employee> GetEmployeeById(int Id);
        Task<bool> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(int Id, Employee employee);
        Task<bool> DeleteEmployeeById(int Id);
        IEnumerable<Employee> GetByPagination(Pager pager);

    }
}
