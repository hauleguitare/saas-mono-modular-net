using Core.Exception;
using FluentValidation;
using MonoModularNet.Infrastructure.Shared.Common.Controller;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MonoModularNet.WebAppBootstrapper.Middleware;

public class HostExceptionMiddleware: IMiddleware
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;

    public HostExceptionMiddleware(IConfiguration configuration, IWebHostEnvironment environment)
    {
        _configuration = configuration;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }


        catch (DomainException e)
        {
            var response = context.Response;
            
            if (!response.HasStarted)
            {
                response.ContentType = "application/json";
                response.StatusCode = e.StatusCode;

                await response.WriteAsync(Response(new {e.Errors, e.Messages}));
            }
        }

        catch (ValidationException e)
        {
            var result = HandleOnValidationException(e);
            var response = context.Response;
            
            if (!response.HasStarted)
            {
                response.ContentType = "application/json";
                response.StatusCode = result.StatusCode;

                await response.WriteAsync(Response(result));
            }
        }
        
        // catch (Event e)
        // {
        //     var result = HandleOnException(e);
        //     var response = context.Response;
        //
        //     if (!response.HasStarted)
        //     {
        //         response.ContentType = "application/json";
        //         response.StatusCode = result.StatusCode;
        //
        //         await response.WriteAsync(Response(result));
        //     }
        // }
    }
    
    private string Response(object err)
    {
        var contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy(),
        };

        return JsonConvert.SerializeObject(err, new JsonSerializerSettings()
        {
            ContractResolver = contractResolver,
            Formatting = Formatting.Indented
        });
    }

    private ApiError HandleOnValidationException(ValidationException exception)
    {
        var messages = exception.Errors.Select(e => e.ErrorMessage).ToArray();
        var errorCodes = exception.Errors.Select(e => e.ErrorCode).ToArray();

        var errorResult = new ApiError()
        {
            StatusCode = StatusCodes.Status400BadRequest,
            Messages = messages,
            Errors = errorCodes
        };

        return errorResult;
    }


    private ApiError HandleOnException(Exception exception)
    {
        var errorResult = new ApiError();
        
        // if (exception is not AppException && exception.InnerException != null)
        // {
        //     while (exception.InnerException != null)
        //     {
        //         exception = exception.InnerException;
        //     }
        // }
        //
        // if (exception is AppException appException)
        // {
        //     errorResult.Code = appException.Code;
        //
        //     if (appException.ErrorMessages is not null)
        //     {
        //         errorResult.ErrorMessages = appException.ErrorMessages;
        //     }
        // }
        

        // if (exception is IdentityValidationException identityValidationException)
        // {
        //     errorResult.Error = "One or More Validations Identity failed.";
        //     errorResult.Code = "validation/invalid-request";
        //     errorResult.Timestamp = DateTime.UtcNow;
        //     foreach (var error in identityValidationException.Errors)
        //     {
        //         errorResult.ErrorMessages.Add(error.Description);
        //     }
        // }
        
        // errorResult.StatusCode = exception switch
        // {
        //     AppException e => (int)e.StatusCode,
        //     ValidationException => (int)HttpStatusCode.BadRequest,
        //     _ => (int)HttpStatusCode.InternalServerError
        // };

        return errorResult;
    }

}