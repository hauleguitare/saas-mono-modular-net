namespace Core.Exception.System;

public class SystemEnvironmentNotFound(string[]? errors, string[]? messages) : DomainException(errors, messages);