using System.Threading.Tasks;

namespace Anshan.Framework.Security
{
    public interface IOAuthService
    {
        Task<TokenResponseResult> GetTokenByCredential(OAuthCredentialModel credentialModel);

        Task<TokenResponseResult> GetTokenByRefreshToken(OAuthRefreshTokenModel model);
    }
}