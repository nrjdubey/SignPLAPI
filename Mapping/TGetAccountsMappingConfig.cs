 using Mapster;
using SignPLAPI.Application.Accounts.Response.Queries;
using SignPLAPI.Contracts.Accounts.GetAccounts;

namespace SignPLAPI.Mapping
{
    public class TGetAccountsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TGetAccountsResult, TGetAccountsResponse>()
                .Map(dest => dest.Accounts, src => src.account);
        }
    }
}
