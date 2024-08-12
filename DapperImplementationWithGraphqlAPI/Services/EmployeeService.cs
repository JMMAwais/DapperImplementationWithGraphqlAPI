using Azure.Core;
using Dapper;
using DapperImplementationWithGraphqlAPI.Models;
using DapperImplementationWithGraphqlAPI.Schema;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DapperImplementationWithGraphqlAPI.Services
{
    public class EmployeeService:IEmployee
    {
        private readonly IConfiguration _configuration;
        public EmployeeService(IConfiguration configuration)
        {
                _configuration = configuration;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            var sql = "SELECT * FROM Employees";
            var books = sqlConnection.Query<Employee>(sql).ToList();
            return books;
        }


        public async Task<Employee> GetEmployeeById(int Id)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var query = "SELECT * FROM Employees WHERE EmployeeId = @Id";
            var employee = await sqlConnection.QuerySingleOrDefaultAsync<Employee>(query, new { @Id = Id });
            var emp=sqlConnection.QueryFirstOrDefault<Employee>(query, new { Id });
            return emp;
        }


        public async Task<bool> AddEmployee(Employee employee)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var query = "INSERT INTO Employees VALUES (@FirstName, @LastName, @Email,@PhoneNumber, @HireDate,@Jobtitle,@Salery )";
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", employee.FirstName, DbType.String);
            parameters.Add("LastName", employee.LastName, DbType.String);
            parameters.Add("Email", employee.Email, DbType.String);
            parameters.Add("PhoneNumber", employee.PhoneNumber, DbType.String);
            parameters.Add("HireDate", employee.HireDate, DbType.Date);
            parameters.Add("Jobtitle", employee.JobTitle, DbType.String);
            parameters.Add("Salery", employee.Salary, DbType.String);
            await sqlConnection.ExecuteAsync(query, parameters);
            return true;
        }


        public async Task<Employee> UpdateEmployee(int Id, Employee employee)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var query = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber=@PhoneNumber, HireDate=@HireDate,Jobtitle=@Jobtitle, Salery=@Salery WHERE EmployeeId = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int32);
            parameters.Add("FirstName", employee.FirstName,DbType.String);
            parameters.Add("LastName", employee.LastName, DbType.String);
            parameters.Add("Email", employee.Email, DbType.String);
            parameters.Add("PhoneNumber", employee.PhoneNumber, DbType.String);
            parameters.Add("HireDate", employee.HireDate, DbType.Date);
            parameters.Add("Jobtitle", employee.JobTitle, DbType.String);
            parameters.Add("Salery", employee.Salary, DbType.String);
            await sqlConnection.ExecuteAsync(query, parameters);
            return employee;
        }


        public async Task<bool> DeleteEmployeeById(int Id)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var query = "Delete from Employees Where EmployeeId=@Id";
            await sqlConnection.ExecuteAsync(query, new { Id });
            return true;
        }

        public  IEnumerable<Employee> GetByPagination(Pager pager)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection sqlConnection = new SqlConnection(connection);
            var query= (@" select * from Employees
                      order by [EmployeeId]
                      OFFSET      @Offset ROWS 
                      FETCH NEXT  @Next   ROWS ONLY");
            var results = sqlConnection.Query<Employee>(query, pager).ToList();
            return results ;
        }


    }
}
