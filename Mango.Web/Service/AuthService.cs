using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto> AssignRolesAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.POST,
                Data = registrationRequestDto,
                Url = APIDetails.AuthBase + "/api/auth/assignRole/"

            });
        }

        public async Task<ResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.POST,
                Data = loginRequestDto,
                Url = APIDetails.AuthBase + "/api/auth/login/"

            }, withBearer: false);
        }

        public async Task<ResponseDto> RegisterAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.POST,
                Data = registrationRequestDto,
                Url = APIDetails.AuthBase + "/api/auth/register/"

            }, withBearer: false);
        }
    }
}
