using DapperImplementationWithGraphqlAPI.Models;
using GraphQL.Types;

namespace DapperImplementationWithGraphqlAPI.Types
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType()
        {
            Field(x => x.EmployeeId);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.Email);
            Field(x => x.PhoneNumber);
            Field(x => x.HireDate);
            Field(x => x.JobTitle);
            Field(x => x.Salary);
        }

    }

   
}

//public class UserType : ObjectType<User>
//{
//    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
//    {
//        descriptor.Field(x => x.Id);
//        descriptor.Field(x => x.Name);
//        descriptor.Field(x => x.Email);
//    }
//}