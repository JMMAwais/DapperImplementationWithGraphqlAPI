using DapperImplementationWithGraphqlAPI.Models;
using DapperImplementationWithGraphqlAPI.Mutations;
using DapperImplementationWithGraphqlAPI.Queries;
using DapperImplementationWithGraphqlAPI.Schema;
using DapperImplementationWithGraphqlAPI.Services;
using DapperImplementationWithGraphqlAPI.Types;
using HotChocolate.Execution;
using System.Collections;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IEmployee,EmployeeService>();

builder.Services.AddGraphQLServer().AddQueryType<EmployeeQuery>().AddSorting().AddFiltering().AddMutationType<EmployeeMutation>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
