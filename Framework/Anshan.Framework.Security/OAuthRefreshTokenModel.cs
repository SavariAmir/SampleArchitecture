namespace Anshan.Framework.Security
{
    public class OAuthRefreshTokenModel
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Authority { get; set; }
        public string RefreshToken { get; set; }
        public string Scope { get; set; }

        public OAuthRefreshTokenModel(string clientId, string clientSecret, string authority, string refreshToken, string scope)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Authority = authority;
            RefreshToken = refreshToken;
            Scope = scope;
        }
    }
}