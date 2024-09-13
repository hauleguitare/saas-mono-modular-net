using Microsoft.AspNetCore.Mvc;

namespace WebApp.Common.Models;

/// <summary>
/// Defines an abstract class ApiResult and all class will inherit.
/// </summary>
/// <param name="value"></param>
public abstract class ApiResult(object? value) : ObjectResult(value);


/// <summary>
/// Defines a class represents Ok Result.
/// </summary>
public sealed class ApiOkResult: ApiResult
{
    private const int DefaultStatusCode = StatusCodes.Status200OK;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiOkResult"/> class.
    /// </summary>
    /// <param name="value">The content to format into the entity body.</param>
    public ApiOkResult(object? value = null) : base(new ApiValue(DefaultStatusCode, Data: value))
    {
        StatusCode = DefaultStatusCode;
    }
}


/// <summary>
/// Defines a class represents Bad Request Result.
/// </summary>
public sealed class ApiBadRequestResult: ApiResult
{
    private const int DefaultStatusCode = StatusCodes.Status400BadRequest;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiBadRequestResult"/> class.
    /// </summary>
    /// <param name="message">The content to describe message error from server to client.</param>
    /// <param name="error">The content to describe error detail from server to client.</param>
    public ApiBadRequestResult(string? message = null, string? error = null) : base(new
    {
        Errors = new List<ApiError>()
        {
            new (DefaultStatusCode, message, error)
        }
    })
    {
        StatusCode = DefaultStatusCode;
    }
}

/// <summary>
/// Defines a class represents Forbidden Result.
/// </summary>
public sealed class ApiForbiddenResult: ApiResult
{
    private const int DefaultStatusCode = StatusCodes.Status403Forbidden;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiBadRequestResult"/> class.
    /// </summary>
    /// <param name="message">The content to describe message error from server to client.</param>
    /// <param name="error">The content to describe error detail from server to client.</param>
    public ApiForbiddenResult(string? message = null, string? error = null) : base(new
    {
        Errors = new List<ApiError>()
        {
            new (DefaultStatusCode, message, error)
        }
    })
    {
        StatusCode = DefaultStatusCode;
    }
}

/// <summary>
/// Defines a class represents Unauthorized Result.
/// </summary>
public sealed class ApiUnauthorizedResult: ApiResult
{
    private const int DefaultStatusCode = StatusCodes.Status401Unauthorized;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiBadRequestResult"/> class.
    /// </summary>
    /// <param name="message">The content to describe message error from server to client.</param>
    /// <param name="error">The content to describe error detail from server to client.</param>
    public ApiUnauthorizedResult(string? message = null, string? error = null) : base(new
    {
        Errors = new List<ApiError>()
        {
            new (DefaultStatusCode, message, error)
        }
    })
    {
        StatusCode = DefaultStatusCode;
    }
}

/// <summary>
/// Defines a class represents Internal Server Result.
/// </summary>
public sealed class ApiInternalServerResult: ApiResult
{
    private const int DefaultStatusCode = StatusCodes.Status500InternalServerError;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiBadRequestResult"/> class.
    /// </summary>
    /// <param name="message">The content to describe message error from server to client.</param>
    /// <param name="error">The content to describe error detail from server to client.</param>
    public ApiInternalServerResult(string? message = null, string? error = null) : base(new
    {
        Errors = new List<ApiError>()
        {
            new (DefaultStatusCode, message, error)
        }
    })
    {
        StatusCode = DefaultStatusCode;
    }
}

/// <summary>
/// Defines a class represents Not Found Result.
/// </summary>
public sealed class ApiNotFoundResult: ApiResult
{
    private const int DefaultStatusCode = StatusCodes.Status404NotFound;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiBadRequestResult"/> class.
    /// </summary>
    /// <param name="message">The content to describe message error from server to client.</param>
    /// <param name="error">The content to describe error detail from server to client.</param>
    public ApiNotFoundResult(string? message = null, string? error = null) : base(new
    {
        Errors = new List<ApiError>()
        {
            new (DefaultStatusCode, message, error)
        }
    })
    {
        StatusCode = DefaultStatusCode;
    }
}


/// <summary>
/// Defines a class represents Conflict Result.
/// </summary>
public sealed class ApiConflictResult: ApiResult
{
    private const int DefaultStatusCode = StatusCodes.Status409Conflict;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiBadRequestResult"/> class.
    /// </summary>
    /// <param name="message">The content to describe message error from server to client.</param>
    /// <param name="error">The content to describe error detail from server to client.</param>
    public ApiConflictResult(string? message = null, string? error = null) : base(new
    {
        Errors = new List<ApiError>()
        {
            new (DefaultStatusCode, message, error)
        }
    })
    {
        StatusCode = DefaultStatusCode;
    }
}


public readonly record struct ApiValue(int StatusCode,object? Data = null){}

public readonly record struct ApiError(int StatusCode, string? Message, string? Error) {}