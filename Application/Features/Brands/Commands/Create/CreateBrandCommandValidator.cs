using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

//kullanıcıdan gelen istek CreateBrandCommand oldu. için onu validasyona sokacağım
public class CreateBrandCommandValidator:AbstractValidator<CreateBrandCommand>
{
    //FluentValidation 'da validasyonlar parametresiz ctor içerisinde yazılır.
    public CreateBrandCommandValidator()
    {
        RuleFor(c=>c.Name).NotEmpty().MinimumLength(2);
    }
}
