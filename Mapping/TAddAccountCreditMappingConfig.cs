using Mapster;
using SignPLAPI.Application.Adminstrator.Response;
using SignPLAPI.Contracts.Adminstrator.AddAccountCredit;

namespace SignPLAPI.Mapping
{
    public class TAddAccountCreditMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TAddAccountCreditResult, TAddAccountCreditResponse>()
                .Map(dest => dest.TransactionId, src => src.Transfer.TransactionId)
                .Map(dest => dest.RetrieverAccount, src => src.Transfer.AccountId)
                .Map(dest => dest.Date, src => src.Transfer.Date)
                .Map(dest => dest.Operation, src => src.Transfer.Operation)
                .Map(dest => dest.Amount, src => src.Transfer.Amount)
                .Map(dest => dest.Balance, src => src.Transfer.Balance);
        }
    }
}
