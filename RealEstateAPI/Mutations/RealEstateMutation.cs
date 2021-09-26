using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using RealEstate.DataAccess.Repositories.Contracts;
using RealEstate.Database.Models;
using RealEstate.Types.Property;

namespace RealEstate.API.Mutations
{
    public class RealEstateMutation : ObjectGraphType
    {
        public RealEstateMutation(IPropertyRepository propertyRepository)
        {
            Name = nameof(RealEstateMutation);

            Field<PropertyType>(
                "addProperty",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PropertyInputType>> {Name = "property"}),
                resolve: context =>
                {
                    var property = context.GetArgument<Property>("property");
                    return propertyRepository.Add(property);
                });

            Field<BooleanGraphType>(
               "testScalar",
               arguments: new QueryArguments(),
               resolve: context =>
               {
                   return true;
               });
        }
    }
}
