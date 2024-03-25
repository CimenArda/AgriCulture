using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ImageValidator:AbstractValidator<Image>
    {
        public ImageValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Kısmı Boş Geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Kısmı Boş Geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Yolu Kısmı Boş Geçilemez");

        }
    }
}
