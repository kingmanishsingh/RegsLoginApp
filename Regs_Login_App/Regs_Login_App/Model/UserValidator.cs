using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Regs_Login_App.Model
{
   public class UserValidator :  AbstractValidator<RegisterationTable>
    {
        public UserValidator()
    {
        RuleFor(x => x.UserName).NotNull().Length(8, 20);
        RuleFor(x => x.PhoneNumber).NotNull().MinimumLength(10);
        RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Invalid Email.");
        RuleFor(x => x.Password).NotNull().Length(8);
        RuleFor(x => x.ConfirmPassword).NotNull().Equal(x => x.Password);
    }
    
    }
}
