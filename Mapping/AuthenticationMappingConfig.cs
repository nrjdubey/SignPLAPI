using Mapster;
using SignPLAPI.Application.Authentication.Common;
using SignPLAPI.Contracts.Authentication;

namespace SignPLAPI.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.user)
                .Map(dest => dest.userId, src => src.user.UserId);

        }
    }
}
