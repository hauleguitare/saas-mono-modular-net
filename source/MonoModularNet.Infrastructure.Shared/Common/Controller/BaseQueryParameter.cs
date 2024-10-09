using Microsoft.AspNetCore.Mvc;

namespace MonoModularNet.Infrastructure.Shared.Common.Controller;

public abstract class BaseQueryParameter
{
    
}

public class OrderByQueryParameter : BaseQueryParameter
{
    // just only DESC OR ESC
    [FromQuery(Name = "orderBy")]
    public string? OrderBy { get; set; } = "esc";
    
    [FromQuery(Name = "orderByColumn")]
    public string? OrderByColumn { get; set; }
}