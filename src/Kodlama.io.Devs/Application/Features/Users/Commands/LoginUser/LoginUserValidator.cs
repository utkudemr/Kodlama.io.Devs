using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand>
    {

        public LoginUserValidator()
        {
            RuleFor(c => c.UserForLoginDto.Email).EmailAddress();
            RuleFor(c => c.UserForLoginDto.Password).NotEmpty();
        }
    }
}
