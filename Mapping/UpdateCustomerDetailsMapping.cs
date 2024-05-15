using Mapster;
using SignPLAPI.Application.Customers.Response.Commands.UpdateCustomerDetailsResult;
using SignPLAPI.Contracts.Customers.UpdateCustomerDetails;

namespace SignPLAPI.Mapping
{
    public class UpdateCustomerDetailsMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateCustomerResult, TUpdateCustomersDetailsRes>()
                .Map(dest => dest.Code, src => src.upcustomerResponse.Code)
                .Map(dest => dest.Name, src => src.upcustomerResponse.Name)
                .Map(dest => dest.LastName, src => src.upcustomerResponse.LastName)
                .Map(dest => dest.Contactno, src => src.upcustomerResponse.ContactNo)
                .Map(dest => dest.Address, src => src.upcustomerResponse.Address)
                .Map(dest => dest.Email, src => src.upcustomerResponse.Email);
        }
    }
}
