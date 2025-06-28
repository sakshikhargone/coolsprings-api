namespace CoolSprings.Validator.DTO;

public class CustomerDTOValidator : AbstractValidator<CustomerDTO>
{
    public CustomerDTOValidator()
    {
        RuleFor(Customer => Customer.CustomerId)
        .NotEmpty().WithMessage("CustomerId is required");

        RuleFor(Customer => Customer.CustomerName)
       .NotEmpty().WithMessage("CustomerName is required");

        RuleFor(Customer => Customer.CustomerPhone)
       .NotEmpty().WithMessage("CustomerPhone is required");

        RuleFor(Customer => Customer.CreatedAt)
      .NotEmpty().WithMessage("CreatedAt is required");

        RuleFor(Customer => Customer.CustomerEmail)
      .NotEmpty().WithMessage("CustomerEmail is required");

        RuleFor(Customer => Customer.CustomerPassword)
     .NotEmpty().WithMessage("CustomerPassword is required");
    }
}