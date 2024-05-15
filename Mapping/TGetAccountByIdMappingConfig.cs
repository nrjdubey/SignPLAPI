using Mapster;
using SignPLAPI.Application.Accounts.Response.Queries;
using SignPLAPI.Contracts.Accounts.GetAccount;

namespace SignPLAPI.Mapping
{

    public class TGetAccountByIdMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TGetTransactionsByAccIdResult, TGetTransactionsByAccIdResultResponse>()
                .Map(dest => dest.Transactions, src => src.Account);

        }
    }
}
