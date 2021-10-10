using Entities.Models;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonelValidator : AbstractValidator<Personel>
    {
        public PersonelValidator()
        {
            RuleFor(a => a.Sicil).NotEmpty().NotNull().WithMessage("Sicil Boş Olamaz");
            RuleFor(a => a.Sicil).Length(6).WithMessage("Sicil 6 Haneli Olmalı");
            RuleFor(a => a.Tckn).NotEmpty().NotNull().WithMessage("Tckn Boş Olamaz");
            RuleFor(a => a.Tckn).Length(11).WithMessage("Tckn 11 Haneli Olmalı");
            RuleFor(a => a.Ad).NotEmpty().NotNull().WithMessage("Ad Boş Olamaz");
            RuleFor(a => a.Ad).MaximumLength(50).WithMessage("Ad 50 Karakterden Büyük Olamaz.");
            RuleFor(a => a.Soyad).NotEmpty().NotNull().WithMessage("Soyad Boş Olamaz");
            RuleFor(a => a.Soyad).MaximumLength(50).WithMessage("Soyad 50 Karakterden Büyük Olamaz.");
            RuleFor(a => a.CinsiyetKodId).NotEmpty().NotNull().WithMessage("Cinsiyet Boş Olamaz");
            RuleFor(a => a.RutbeKodId).NotEmpty().NotNull().WithMessage("Rütbe Boş Olamaz");
            RuleFor(a => a.SubeKodId).NotEmpty().NotNull().WithMessage("Şube Boş Olamaz");
            RuleFor(a => a.CepNo).NotEmpty().NotNull().WithMessage("CepNo Boş Olamaz");
            RuleFor(a => a.CepNo).Length(10).WithMessage("CepNo 10 Haneli Olmalı");
            RuleFor(a => a.YakinCepNo).NotEmpty().NotNull().WithMessage("Yakın CepNo Boş Olamaz");
            RuleFor(a => a.YakinCepNo).Length(10).WithMessage("Yakın CepNo 10 Haneli Olmalı");
            RuleFor(a => a.Dahili).NotEmpty().NotNull().WithMessage("Dahili Boş Olamaz");
            RuleFor(a => a.Dahili).Length(5).WithMessage("Dahili 5 Haneli Olmalı");
            RuleFor(a => a.BirimBaslamaTarihi).NotEmpty().NotNull().WithMessage("Birim Başlama Tarihi Boş Olamaz.");
        }
    }
}
