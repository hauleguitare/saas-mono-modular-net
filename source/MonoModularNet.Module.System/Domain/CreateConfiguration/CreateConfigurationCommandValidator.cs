using FluentValidation;

namespace MonoModularNet.Module.System.Domain.CreateConfiguration;

public class CreateConfigurationCommandValidator: AbstractValidator<CreateConfigurationCommand>
{
    private readonly string[] _type = new[]
    {
        "System.Int32",
        "System.String",
        "System.Decimal"
    };
    
    public CreateConfigurationCommandValidator()
    {
        RuleFor(e => e.Type).Must(e => _type.Contains(e)).WithMessage("{PropertyName} invalid type.");
    }
}