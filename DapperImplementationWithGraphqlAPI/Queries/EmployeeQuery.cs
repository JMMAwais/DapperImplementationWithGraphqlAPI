using DapperImplementationWithGraphqlAPI.Models;
using DapperImplementationWithGraphqlAPI.Services;
using Microsoft.Extensions.Hosting;

namespace DapperImplementationWithGraphqlAPI.Queries
{
    public class EmployeeQuery
    {


        [UseSorting]
        [UseFiltering]
       // [UsePaging(IncludeTotalCount = true)]
        public IEnumerable<Employee> GetEmployees([Service] IEmployee employeeservice)
        {
            return employeeservice.GetAllEmployees();
        }

        public async Task<Employee> GetEmployeeById([Service] IEmployee employeeService, int Id)
        {
            return await employeeService.GetEmployeeById(Id);
        }
        public  IEnumerable<Employee> GetByPagination([Service] IEmployee employeeService, Pager pager)
        {
            return  employeeService.GetByPagination(pager);
        }

    }
}
