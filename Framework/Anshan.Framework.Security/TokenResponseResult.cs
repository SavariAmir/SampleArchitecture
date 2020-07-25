namespace Anshan.Framework.Security
{
    public class TokenResponseResult
    {
        public string AccessToken { set; get; }

        public string RefreshToken { set; get; }

        public int ExpiresIn { set; get; }
    }
}