namespace MonoModularNet.Module.Auth.Domain.Const;

public readonly struct DomainExceptionError
{
    public const string NotSignedIn = "auth/user-not-signed-in";
    public const string SignedInAlready = "auth/user-signed-in-already";
    public const string ChangePasswordFailed = "auth/change-password-failed";
    public const string PasswordMisMatched = "auth/password-mismatched";
}