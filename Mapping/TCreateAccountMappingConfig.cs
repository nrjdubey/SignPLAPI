using Mapster;
using SignPLAPI.Application.Accounts.Response.Commands;
using SignPLAPI.Contracts.Accounts.CreateAccount;

namespace SignPLAPI.Mapping
{
    public class TCreateAccountMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TCreateAccountResult, TCreateAccountResponse>()
                .Map(dest => dest.AccountId, src => src.Account.AccountId)
                .Map(dest => dest.Frequency, src => src.Account.Frequency)
                .Map(dest => dest.Created, src => src.Account.Created)
                .Map(dest => dest.Balance, src => src.Account.Balance)
                .Map(dest => dest.AccountTypesId, src => src.Account.AccountTypesId);
        }
    }
}
