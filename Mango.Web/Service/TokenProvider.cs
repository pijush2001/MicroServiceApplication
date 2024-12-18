using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Mango.Web.Service
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public void ClearToken()
        {
            _contextAccessor.HttpContext.Response.Cookies.Delete(Cookies.TokenCookie);
        }

        public string? GetToken()
        {
            string? token = null;
            bool hasToken = _contextAccessor.HttpContext.Request.Cookies.TryGetValue(Cookies.TokenCookie, out token);
            return hasToken is true ? token : null;
            
        }

        public void SetToken(string token)
        {
            _contextAccessor.HttpContext.Response.Cookies.Append(Cookies.TokenCookie, token);
        }
    }
}
