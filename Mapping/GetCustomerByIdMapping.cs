using Mapster;
using MediatR;
using SignPLAPI.Application.Customers.Response.Queries;
using SignPLAPI.Contracts.Customers.GetCustomersById;

namespace SignPLAPI.Mapping
{
    public class GetCustomerByIdMapping : IRequest
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetCustByIdResponse, TGetCustomersByIdRes>()
                .Map(dest => dest.clist, src => src.models);
        }
    }
}
