using GraphQL.Types;
using RealEstate.Types.Property;
using RealEstate.DataAccess.Repositories.Contracts;
using RealEstate.Types.Payment;

namespace RealEstate.API.Queries
{
    public class RealEstateQuery : ObjectGraphType
    {
        public RealEstateQuery(IPropertyRepository propertyRepository, IPaymentRepository paymentRepository)
        {
            Field<ListGraphType<PropertyType>>(
                "properties",
                resolve: context => propertyRepository.GetAll());

            Field<PropertyType>(
                "property",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => propertyRepository.GetById(context.GetArgument<int>("id")));

            Field<ListGraphType<PaymentType>>(
               "payments",
               resolve: context => paymentRepository.GetAll());
        }
    }
}