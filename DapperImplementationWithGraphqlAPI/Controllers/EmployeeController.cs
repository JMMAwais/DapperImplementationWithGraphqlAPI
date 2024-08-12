using Dapper;
using DapperImplementationWithGraphqlAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperImplementationWithGraphqlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
                _configuration = configuration;
        }
        // GET: api/<EmployeeController>
        //[HttpGet]
        //public List<Employee> Get()
        //{
        //    var connection = _configuration.GetConnectionString("DefaultConnection");
        //    SqlConnection sqlConnection = new SqlConnection(connection);
        //    var sql = "SELECT * FROM Employees";
        //    var books = sqlConnection.Query<Employee>(sql).ToList();
        //    return books;
        //}

        //[HttpGet("GetById")]
        //public async Task<Employee> GetEmployeeById(int Id)
        //{
        //    var connection = _configuration.GetConnectionString("DefaultConnection");
        //    SqlConnection sqlConnection = new SqlConnection(connection);
        //    var query = "SELECT * FROM Employees WHERE EmployeeId = @Id";
     
        //    var employee = await sqlConnection.QuerySingleOrDefaultAsync<Employee>(query, new { Id });
        //    return employee;
        //}

    }
}
