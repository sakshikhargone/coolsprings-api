namespace CoolSprings.Validator;

public class BookingDTOValidator : AbstractValidator<BookingDTO>
{
    public BookingDTOValidator()
    {
        RuleFor(b => b.CustomerName)
            .NotEmpty().WithMessage("Customer name is required.");

        RuleFor(b => b.CustomerPhone)
            .NotEmpty().WithMessage("Customer phone is required.")
            .Matches(@"^\d{10}$").WithMessage("Customer phone must be a 10-digit number.");

        RuleFor(b => b.NumOfTickets)
            .GreaterThan(0).WithMessage("At least one ticket must be booked.");

        RuleFor(b => b.DiscountCode)
            .MaximumLength(25).WithMessage("Discount code cannot exceed 25 characters.")
            .When(b => !string.IsNullOrWhiteSpace(b.DiscountCode));

        RuleFor(b => b.PaymentMode)
            .NotEmpty().WithMessage("Payment mode is required.")
            .WithMessage("Payment mode must be either Cash, UPI");

        RuleFor(b => b.ActualAmount)
            .GreaterThan(0).WithMessage("Actual amount must be greater than 0.");

        RuleFor(b => b.PaidAmount)
            .GreaterThan(0).WithMessage("Paid amount amount must be greater than 0.");

        RuleFor(b => b.UPITxnRefNumber)
           .NotEmpty().WithMessage("UPI transaction reference number is required for UPI payments.")
           .Length(4).WithMessage("UPI transaction reference number must be exactly 4 characters.")
           .When(b => b.PaymentMode == "UPI");
    }
}