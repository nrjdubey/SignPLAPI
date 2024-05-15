using Mapster;
using SignPLAPI.Application.Customers.Response.Commands.CreatCustomerFriendsDetailsResult;
using SignPLAPI.Contracts.Customers.CreateCustomerFriendsDetails;

namespace SignPLAPI.Mapping
{
    public class CreateCustomerFriendsMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateCustomerFriendsDetailsResult, CreateCustomersFriendsDetailsResponse>()
                .Map(dest => dest.Code, src => src.CustomersAggregators.Code)
                .Map(dest => dest.Name, src => src.CustomersAggregators.Name)
                .Map(dest => dest.ContactNo, src => src.CustomersAggregators.ContactNo)
                .Map(dest => dest.CustomerFriendsDetails, src => src.CustomersAggregators.CustomersFriends);

        }
    }
}
