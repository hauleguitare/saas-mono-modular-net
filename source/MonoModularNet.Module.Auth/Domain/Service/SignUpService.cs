using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MonoModularNet.Infrastructure.Shared.Common.Attribute;
using MonoModularNet.Module.Auth.Domain.Model;
using MonoModularNet.Module.Auth.Shared;
using MonoModularNet.Module.Auth.Shared.Interface;

namespace MonoModularNet.Module.Auth.Domain.Service;

[Injectable(InterfaceType = typeof(ISignUpService), Lifetime = ServiceLifetime.Scoped)]
public class SignUpService : ISignUpService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IMapper _mapper;
    private readonly ILogger<SignUpService> _logger;

    public SignUpService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        IMapper mapper, ILogger<SignUpService> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task SignUpAsync(SignUpReq req, CancellationToken cancellationToken = default)
    {
        var user = new ApplicationUser()
        {
            Email = req.Email,
            UserName = req.Email
        };

        var result = await _userManager.CreateAsync(user, req.Password);

        if (!result.Succeeded)
        {
           
        }
        
        _logger.LogInformation(LoggerEventIds.UserCreated, "User created a new account with password.");

        var userId = await _userManager.GetUserIdAsync(user);
        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        // await _emailSender.SendConfirmationLinkAsync(user, Input.Email, HtmlEncoder.Default.Encode(callbackUrl));
    }
}