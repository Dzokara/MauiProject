using AndroidIspitniProjekat.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidIspitniProjekat.Validators
{
    public class JobInsertValidator : AbstractValidator<AdminJobsViewModel>
    {
        public JobInsertValidator()
        {
            RuleFor(x => x.SelectedCompany.Value)
            .NotNull().WithMessage("Company is required.");

        RuleFor(x => x.SelectedPosition.Value)
            .NotNull().WithMessage("Position is required.");

        RuleFor(x => x.SelectedRegion.Value)
            .NotNull().WithMessage("Region is required.");

        RuleFor(x => x.SelectedType.Value)
            .NotNull().WithMessage("Type is required.");

        RuleFor(x => x.SelectedRemote.Value)
            .NotNull().WithMessage("Remote option is required.");

        RuleFor(x => x.Description.Value)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(x => x.Salary.Value)
            .GreaterThan(0).WithMessage("Salary must be greater than zero.");

        RuleFor(x => x.Deadline.Value)
            .GreaterThan(DateTime.Now).WithMessage("Deadline must be a future date.");
    }
}
}
