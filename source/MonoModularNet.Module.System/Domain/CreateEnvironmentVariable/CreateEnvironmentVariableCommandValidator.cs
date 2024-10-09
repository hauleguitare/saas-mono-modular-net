using FluentValidation;

namespace MonoModularNet.Module.System.Domain.CreateEnvironmentVariable;

public class CreateEnvironmentVariableCommandValidator: AbstractValidator<CreateEnvironmentVariableCommand>
{
    private readonly string[] _type = new[]
    {
        "System.Int32",
        "System.String",
        "System.Decimal"
    };
    
    public CreateEnvironmentVariableCommandValidator()
    {
        RuleFor(e => e.Metadata.Type)
            .NotNull().NotEmpty().Must(e => _type.Contains(e)).WithMessage("{PropertyName} invalid type.");
    }
}