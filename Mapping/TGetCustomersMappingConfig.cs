using Mapster;
using SignPLAPI.Application.Accounts.Response.Queries;
using SignPLAPI.Application.Customers.Response.Queries;
using SignPLAPI.Contracts.Accounts.GetAccounts;
using SignPLAPI.Contracts.Customers.GetCustomers;

namespace SignPLAPI.Mapping
{
    public class TGetCustomersMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetCustomersResponse, TGetCustomerResponse>()
                .Map(dest => dest.customerlist, src => src.customerM);
        }
    }
}
