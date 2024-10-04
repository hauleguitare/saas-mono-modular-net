using FluentValidation;

namespace MonoModularNet.Module.Auth.Domain.SignUp.Command;

public class SignUpCommandValidator: AbstractValidator<SignUpCommand>
{
    public SignUpCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}