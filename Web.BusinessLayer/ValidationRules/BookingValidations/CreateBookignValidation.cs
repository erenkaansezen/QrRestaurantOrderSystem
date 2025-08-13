using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Web.DtoLayer.BookingDto;

namespace Web.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookignValidation:AbstractValidator<CreateBookingDto>
    {
        public CreateBookignValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad alanı boş geçilemez")
                .MinimumLength(2).WithMessage("Ad en az 2 karakter olmalıdır")
                .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olmalıdır");
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon alanı boş geçilemez")
                .Matches(@"^\d{10}$").WithMessage("Telefon numarası 10 haneli olmalıdır");
            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("Email alanı boş geçilemez")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı boş geçilemez")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olmalıdır");
            RuleFor(x => x.PersonCount)
                .NotEmpty().WithMessage("Kişi sayısı alanı boş geçilemez");
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Tarih alanı boş geçilemez")
                .GreaterThan(DateTime.Now).WithMessage("Tarih bugünden sonraki bir tarih olmalıdır");

        }
    }
}
