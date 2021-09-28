using Business.Abstract;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto dto)
        {
            var user = _authService.Login(dto);

            if (!user.Success)
                return BadRequest(user.Message);

            var tokenresult = _authService.CreateAccessToken(user.Data);
            if (tokenresult.Success)
                return Ok(tokenresult.Data);

            return BadRequest(tokenresult.Message);

        }

        [HttpPost("register")]
        public IActionResult Register(Entities.DTO.UserForRegisterDto dto)
        {
            // Kullanıcı var mı kontrol et
            var exists = _authService.UserExists(dto.Email);

            // eğer varsa olumsuz işlem yanıtı gödner
            if (!exists.Success)
                return BadRequest(exists.Message);

            // Yoksa kaydet
            var registerResult = _authService.Register(dto, dto.Password);

            // yeni kaydedilen kullanıcı için token oluştur.
            var tokenResult = _authService.CreateAccessToken(registerResult.Data);
            // İşlem başarılı ise token bilgisi döndür
            if (tokenResult.Success)
                return Ok(tokenResult.Data);

            // Hata var ise hata mesajını ver
            return BadRequest(tokenResult.Message);


        }



    }
}
