using Apple.Service.DTOs.CategoryDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Service.Validators.CategoriesValidator
{
    public class CategoryPostValidator:AbstractValidator<CategoryPostDTO>
    {
        public CategoryPostValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bosh ola bilmez").NotNull().WithMessage("Doldurulmalidir!")
                .MinimumLength(2).MaximumLength(25).WithMessage("uzunlug max 25 simvoldan ibaret olmalidir!");
        }
    }
}
