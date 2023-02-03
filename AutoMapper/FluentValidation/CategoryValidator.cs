using AutoMapper_FluentValidation.Dto;
using FluentValidation;

namespace AutoMapper_FluentValidation.Validation
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category Name is not empty");
        }
    }
}
