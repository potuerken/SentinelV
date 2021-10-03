using Check.Concrete;

namespace Check.DTO
{
    public class KullaniciGirisDTO : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
