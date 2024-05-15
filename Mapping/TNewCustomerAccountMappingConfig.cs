using Mapster;
using SignPLAPI.Application.Adminstrator.Response;
using SignPLAPI.Contracts.Adminstrator.NewCustomerAccount;

namespace SignPLAPI.Mapping
{
    public class TNewCustomerAccountMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TNewCustomerAccountResult, TNewCustomerAccountResponse>()
                .Map(dest => dest.DispositionId, src => src.DispositionCustomerAccount.DispositionId)
                .Map(dest => dest.Customer, src => src.DispositionCustomerAccount.Customer)
                .Map(dest => dest.Account, src => src.DispositionCustomerAccount.Account)
                .Map(dest => dest.User, src => src.DispositionCustomerAccount.User);


        }
    }

}
