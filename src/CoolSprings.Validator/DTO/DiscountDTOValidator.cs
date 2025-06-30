namespace CoolSprings.Validator.DTO;

    public class DiscountDTOValidator : AbstractValidator<DiscountDTO>
    {
        public DiscountDTOValidator()
        {
            RuleFor(x => x.DiscountId)
                .NotEmpty().WithMessage("Discount ID is required.");

            RuleFor(x => x.DiscountCode)
                .NotEmpty().WithMessage("Discount code is required.")
                .MaximumLength(25).WithMessage("Discount code cannot exceed 25 characters.");

        RuleFor(x => x.DiscountValue)
            .NotEmpty().WithMessage("Discount value is required.");
              

        RuleFor(x => x.ActivationDate)
                .LessThanOrEqualTo(x => x.ExpiryDate)
                .WithMessage("Activation date must be before or equal to the expiry date.");

            RuleFor(x => x.ExpiryDate)
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("Expiry date should not be less than today's date");
        }
    }


