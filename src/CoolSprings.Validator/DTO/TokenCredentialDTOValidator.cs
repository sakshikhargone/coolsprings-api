namespace CoolSprings.Validator.DTO;

public class TokenCredentialDTOValidator : AbstractValidator<TokenCredentialDTO>
{
    public TokenCredentialDTOValidator()
    {
        RuleFor(TokenCredential => TokenCredential.CustomerPhone)
            .NotEmpty().WithMessage("Mobile No is required")
            .Matches(@"^[6-9]{1}[\d]{9}$").WithMessage("Mobile No is invalid");

        RuleFor(TokenCredential => TokenCredential.CustomerEmail)
            .NotEmpty().WithMessage("  Email is required")
        .Matches(@"^[A-Za-z0-9]+@[A-Za-z]+\.[A-Za-z]{2,}$").WithMessage(" Email is invalid");

        RuleFor(TokenCredential => TokenCredential.CustomerPassword)
            .NotEmpty().WithMessage(" Password is required")
            .MinimumLength(6).WithMessage("Password must contain atleast 6 characters");
    }
}