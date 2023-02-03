using AutoMapper_FluentValidation.Dto;
using AutoMapper_FluentValidation.Entities;
using FluentValidation;

namespace AutoMapper_FluentValidation.Validation
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product name is not empty");
        }
    }
}
