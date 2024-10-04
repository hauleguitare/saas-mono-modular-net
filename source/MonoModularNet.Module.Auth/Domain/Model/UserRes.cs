namespace MonoModularNet.Module.Auth.Domain.Model;

public class UserRes
{
    public string Id { get; set; } = null!;
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public bool? EmailConfirmed { get; set; }
    public string? PhoneNumber { get; set; }
    public bool? PhoneNumberConfirmed { get; set; }
}