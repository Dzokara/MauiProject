using AndroidIspitniProjekat.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidIspitniProjekat.Validators
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email.Value).NotEmpty()
                                       .WithMessage("Email je obavezan.")
                                       .EmailAddress()
                                       .WithMessage("Email nije ispravnog formata.");

            RuleFor(x => x.FirstName.Value).NotEmpty()
                                     .WithMessage("Ime je obavezno.")
                                     .Length(2, 50)
                                     .WithMessage("Ime mora imati između 2 i 50 karaktera.");

            RuleFor(x => x.LastName.Value).NotEmpty()
                                    .WithMessage("Prezime je obavezno.")
                                    .Length(2, 50)
                                    .WithMessage("Prezime mora imati između 2 i 50 karaktera.");

            RuleFor(x => x.Username.Value).NotEmpty()
                                    .WithMessage("Korisnicko ime je obavezno.")
                                    .Length(5, 20)
                                    .WithMessage("Korisnicko ime mora imati između 5 i 20 karaktera.");

            RuleFor(x => x.Password.Value).NotEmpty()
                                          .WithMessage("Lozinka je obavezna.")
                                          .Length(8, 100)
                                          .WithMessage("Lozinka mora imati između 8 i 100 karaktera.")
                                          .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")
                                          .WithMessage("Lozinka mora sadržavati najmanje jedno veliko slovo, jedno malo slovo i jednu cifru.");
        }
    }
}
