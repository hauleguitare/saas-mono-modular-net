using MonoModularNet.Module.Auth.Domain.SignUp.Command;

namespace MonoModularNet.Module.Auth.Domain.SignUp.Handler;


public class SignUpCommandHandler: CqrsCommandHandler<SignUpCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public SignUpCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public override async Task<CqrsResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
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
                IsSuccess = false,
                Messages = result.Errors.Select(e => e.Description).ToArray(),
                Errors = result.Errors.Select(e => e.Code).ToArray()
            };
        }
        
        return new CqrsResult()
        {
            IsSuccess = true
        };
    }
}