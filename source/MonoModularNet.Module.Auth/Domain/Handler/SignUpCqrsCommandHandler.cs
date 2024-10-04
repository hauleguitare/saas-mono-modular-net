namespace MonoModularNet.Module.Auth.Domain.Handler;

public class SignUpCqrsCommand: CqrsCommand
{
    public SignUpCqrsCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}


public class SignUpCqrsCommandHandler: CqrsCommandHandler<SignUpCqrsCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public SignUpCqrsCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async override Task<CqrsResult> Handle(SignUpCqrsCommand request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser()
        {
            Email = request.Email,
            UserName = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return new CqrsResult()
            {
                Errors = result.Errors.Select(e => e.Description).ToArray()
            };
        }
        
        return new CqrsResult()
        {
            IsSuccess = true
        };
    }
}