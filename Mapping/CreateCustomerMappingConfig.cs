using Mapster;
using SignPLAPI.Application.Adminstrator.Response;
using SignPLAPI.Application.Customers.Commands;
using SignPLAPI.Application.Customers.Response.Commands;
using SignPLAPI.Contracts.Adminstrator.AddAccountCredit;
using SignPLAPI.Contracts.Customers.CreateCustomers;
using SignPLAPI.Contracts.Customers.GetCustomers;
using System.Net;

namespace SignPLAPI.Mapping
{
    public class CreateCustomerMappingConfig : IRegister
    {

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateCustomerResponse, TCreateCustomersResponse>()
                .Map(dest => dest.Code, src => src.customerResponse.Code)
                .Map(dest => dest.Name, src => src.customerResponse.Name)
                .Map(dest => dest.LastName, src => src.customerResponse.LastName)
                .Map(dest => dest.Contactno, src => src.customerResponse.ContactNo)
                .Map(dest => dest.Address, src => src.customerResponse.Address)
                .Map(dest => dest.Email, src => src.customerResponse.Email);
        }
    }
}
