using Mapster;
using SignPLAPI.Application.Accounts.Response.Commands;
using SignPLAPI.Contracts.Transactions.Transfer;

namespace SignPLAPI.Mapping
{

    public class TTransferMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TTransferResult, TTransferResponse>()
                .Map(dest => dest.TransactionId, src => src.Transfer.TransactionId)
                .Map(dest => dest.RetrieverAccount, src => src.Transfer.AccountId)
                .Map(dest => dest.Date, src => src.Transfer.Date)
                .Map(dest => dest.Operation, src => src.Transfer.Operation)
                .Map(dest => dest.Amount, src => src.Transfer.Amount)
                .Map(dest => dest.Balance, src => src.Transfer.Balance)
                .Map(dest => dest.SenderAccount, src => src.Transfer.Account);
        }
    }
}
