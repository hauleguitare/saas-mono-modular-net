namespace MonoModularNet.Module.System.Domain.CreateEnvironment;

public class CreateEnvironmentVariableCommandValidator: AbstractValidator<CreateEnvironmentCommand>
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