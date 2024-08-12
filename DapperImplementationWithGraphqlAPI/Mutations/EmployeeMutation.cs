using DapperImplementationWithGraphqlAPI.Models;
using DapperImplementationWithGraphqlAPI.Services;

namespace DapperImplementationWithGraphqlAPI.Mutations
{
    public class EmployeeMutation
    {
        public async Task<bool> CreateEmployee([Service] EmployeeService eployeeServive, Employee input)
        {
            var Employee = new Employee { FirstName = input.FirstName, LastName = input.LastName, Email = input.Email, PhoneNumber = input.PhoneNumber, HireDate=input.HireDate, JobTitle=input.JobTitle,Salary= input.Salary };
            return await eployeeServive.AddEmployee(Employee);
        }

        public async Task<Employee> UpdateEmployee([Service] EmployeeService employeeService, Employee employeeInput, int Id)
        {
            // var Employee= new Employee { FirstName = input.FirstName, LastName = input.LastName ,Email = input.Email, DateofBirth=input.DateofBirth,PhoneNumber=input.PhoneNumber };
            return await employeeService.UpdateEmployee(Id, employeeInput);
        }

        public async Task<bool> DeleteEmployee([Service] EmployeeService employeeService, int Id)
        {
            return await employeeService.DeleteEmployeeById(Id);
        }
    }
}
