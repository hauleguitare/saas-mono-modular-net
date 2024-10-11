namespace MonoModularNet.Module.Auth.Domain.Model;

public record ChangePasswordReq
{
    public string CurrentPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}