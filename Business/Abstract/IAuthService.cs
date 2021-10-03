using Check.DTO;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(KullaniciKayitDTO userForRegisterDto, string password);
        IDataResult<User> Login(KullaniciGirisDTO userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
