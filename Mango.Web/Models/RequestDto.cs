using Mango.Web.Utility;
using static Mango.Web.Utility.ApiTypeEnum;

namespace Mango.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string? Url { get; set; }
        public Object? Data {  get; set; }
        public string? AccessToken {  get; set; }
    }
}
