using AndroidIspitniProjekat.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidIspitniProjekat.Validators
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email.Value).NotEmpty()
                                       .WithMessage("Email je obavezan.")
                                       .EmailAddress()
                                       .WithMessage("Email nije ispravnog formata.");

            RuleFor(x => x.Password.Value).NotEmpty()
                                          .WithMessage("Lozinka je obavezna.");
                                          //.Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")
                                          //.WithMessage("Lozinka nije ispravnog formata. Ocekuje se min 8 karaktera.");
        }
    }
}
