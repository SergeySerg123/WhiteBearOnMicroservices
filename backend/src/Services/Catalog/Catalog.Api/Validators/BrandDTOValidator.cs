using FluentValidation;
using WhiteBear.Services.Catalog.Api.Data.DTO.Brand;

namespace WhiteBear.Services.Catalog.Api.Validators
{
    public sealed class BrandDTOValidator : AbstractValidator<BrandDTO>
    {
        public BrandDTOValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty()
                    .WithMessage("Brand name is mandatory.")
                .MinimumLength(3)
                    .WithMessage("Username should be minimum 3 character.");
        }
    }
}
