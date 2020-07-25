using Anshan.Framework.Domain.Exceptions;
using IdentityModel.Client;
using System;
using System.Threading.Tasks;

namespace Anshan.Framework.Security
{
    public class OAuthService : IOAuthService
    {
        public async Task<TokenResponseResult> GetTokenByCredential(OAuthCredentialModel model)
        {
            var client = await GetClient(model.Authority, model.ClientId, model.ClientSecret);

            var response = await client.RequestResourceOwnerPasswordAsync(model.UserName, model.Password, model.Scope);

            if (response.IsError)
                throw new DomainException("1", "نام کابری یا رمز عبور اشتباه است");

            return NormalToken(response);
        }

        public async Task<TokenResponseResult> GetTokenByRefreshToken(OAuthRefreshTokenModel model)
        {
            var client = await GetClient(model.Authority, model.ClientId, model.ClientSecret);
            var response = await client.RequestRefreshTokenAsync(model.RefreshToken);

            if (response.IsError)
                throw new DomainException("1", "نام کابری یا رمز عبور اشتباه است");

            return NormalToken(response);
        }

        private static async Task<TokenClient> GetClient(string authority, string clientId, string clientSecret)
        {
            var discoveryResponse = await DiscoveryClient.GetAsync(authority);
            if (discoveryResponse.IsError) throw new Exception(discoveryResponse.Error);

            return new TokenClient(discoveryResponse.TokenEndpoint, clientId, clientSecret);
        }

        private TokenResponseResult NormalToken(TokenResponse response)
        {
            return new TokenResponseResult
            {
                AccessToken = response.AccessToken,
                RefreshToken = response.RefreshToken,
                ExpiresIn = response.ExpiresIn
            };
        }
    }
}