using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ServiceValidator:AbstractValidator<Service>
    {
        public ServiceValidator() 
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık Kısmı Boş Geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Kısmı Boş Geçilemez");


            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Başlık Adı En Az 3 karakter olmalıdır.");


        }
    }
}
