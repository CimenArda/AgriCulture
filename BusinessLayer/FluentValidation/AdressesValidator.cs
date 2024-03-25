using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class AdressesValidator:AbstractValidator<Adress>
    {
        public AdressesValidator() 
        {
            RuleFor(x => x.Description1).NotEmpty().WithMessage("Açıklama Kısmı Boş Geçilemez");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama Kısmı Boş Geçilemez");
            RuleFor(x => x.Description3).NotEmpty().WithMessage("Açıklama Kısmı Boş Geçilemez");
            RuleFor(x => x.Description4).NotEmpty().WithMessage("Açıklama Kısmı Boş Geçilemez");


        }
    }
}
