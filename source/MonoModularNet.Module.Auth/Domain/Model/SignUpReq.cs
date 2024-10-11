namespace MonoModularNet.Module.Auth.Domain.Model;

public record SignUpReq
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}