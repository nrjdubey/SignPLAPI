using Mapster;
using SignPLAPI.Application.Customers.Queries.GetCustomerFriends;
using SignPLAPI.Application.Customers.Response.Queries.GetCustomerFriends;
using SignPLAPI.Contracts.Customers.GetCustomerFriends;

namespace SignPLAPI.Mapping
{
    public class CustomerFriendsMappingConfig : IRegister
    {

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetCustomerFriendsResult, GetCustomerFriendRes>()
                .Map(dest => dest.custmerFriend, src => src.customerF);

        }
    }
}
