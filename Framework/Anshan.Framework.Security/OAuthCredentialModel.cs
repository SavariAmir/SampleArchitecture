namespace Anshan.Framework.Security
{
    public class OAuthCredentialModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Authority { get; set; }

        public string Scope { get; set; }

        public OAuthCredentialModel(string userName, string password, string clientId, string clientSecret, string authority, string scope)
        {
            UserName = userName;
            Password = password;
            ClientId = clientId;
            ClientSecret = clientSecret;
            Authority = authority;
            Scope = scope;
        }
    }
}