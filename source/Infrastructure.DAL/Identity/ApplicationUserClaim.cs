﻿using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DAL.Identity;

public sealed class ApplicationUserClaim: IdentityUserClaim<string>
{
    public ApplicationUser User { get; set; } = null!;
}
