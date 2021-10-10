using Check.DTO;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Models;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Users> Register(KullaniciKayitDTO userForRegisterDto, string password);
        IDataResult<Users> Login(KullaniciGirisDTO userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Users user);
    }
}
