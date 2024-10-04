namespace MonoModularNet.Module.Auth.Domain.SignUp.Command;

public class SignUpCommand: CqrsCommand
{
    public SignUpCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}