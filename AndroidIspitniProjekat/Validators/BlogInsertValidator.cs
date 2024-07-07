using AndroidIspitniProjekat.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidIspitniProjekat.Validators
{
    public class BlogInsertValidator  : AbstractValidator<AdminBlogViewModel>
    {
        public BlogInsertValidator()
        {
            RuleFor(blog => blog.Title.Value)
               .NotEmpty().WithMessage("Title is required.");
            RuleFor(blog => blog.Description.Value)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(blog => blog.Image.Value)
                .NotEmpty().WithMessage("Image is required.");
        }
    }
}
