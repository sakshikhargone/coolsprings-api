namespace CoolSprings.Validator.DTO;

public class CustomerHistoryDTOValidator : AbstractValidator<CustomerHistoryDTO>
{
    public CustomerHistoryDTOValidator()
    {
        RuleFor(x => x.CustomerName)
            .NotEmpty().WithMessage("Customer name is required.");
          

        RuleFor(x => x.CustomerPhone)
            .NotEmpty().WithMessage("Customer phone is required.")
            .Matches(@"^\d{10}$").WithMessage("Customer phone must be a 10-digit number.");

        RuleForEach(x => x.Booking)
            .SetValidator(new BookingDetailValidator());
    }
}

public class BookingDetailValidator : AbstractValidator<CoolSprings.DTO.BookingDetail>
{
    public BookingDetailValidator()
    {
        RuleFor(x => x.NumOfTickets)
            .GreaterThan(0).WithMessage("Number of tickets must be greater than 0.");

        RuleFor(x => x.PaymentMode)
            .NotEmpty().WithMessage("Payment mode is required.");

        RuleFor(x => x.ActualAmount)
            .GreaterThanOrEqualTo(0).WithMessage("Actual amount must be greater than 0.");

        RuleFor(x => x.PaidAmount)
            .GreaterThanOrEqualTo(0).WithMessage("Paid amount must be greater than 0.");

        RuleFor(x => x)
            .Must(x => x.ValidFrom <= x.ExpiryDate)
            .WithMessage("ValidFrom must be before or equal to ExpiryDate.");
    }
}
