using Check.Concrete;

namespace Check.DTO
{
    public class KullaniciKayitDTO : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
