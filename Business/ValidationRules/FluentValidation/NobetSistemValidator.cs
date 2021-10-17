using Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class NobetSistemValidator : AbstractValidator<NobetSistem>
    {
        public NobetSistemValidator()
        {
            RuleFor(a => a.HaftaIciGunduzSaat).Length(11).WithMessage("Tckn 11 Haneli Olmalı");

        }
    }
}
