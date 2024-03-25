using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class TeamValidator:AbstractValidator<Team>
    {
        public TeamValidator() 
        {
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Ad-Soyad Kısmı Boş Geçilemez");
            RuleFor(x => x.PersonName).MinimumLength(5).WithMessage("Ad-Soyad En Az 5 karakter olmalıdır.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Görev Adı En Az 5 karakter olmalıdır.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görev Kısmı Boş Geçilemez");
            

        }
    }
}
