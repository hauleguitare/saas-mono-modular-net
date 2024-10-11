namespace MonoModularNet.Module.Auth.Domain.Model;

public record SignUpRes
{
    public string Email { get; set; }
    public string UserName { get; set; }
}