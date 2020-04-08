# Throwing Exceptions
*Updated: 4/8/2020*

[Rethrowing an Exception](#rethrowing-an-exception) \
[Throw Expression](#throw-expression) \
[How Exception Handling Works](#how-exception-handling-works)

To report an error in code you must raise (or throw) an [exception](exceptions.md). Raising an exception notifies any callers higher in the call stack that an error has occurred and allows the caller to handle the error, if possible.

To throw an exception you use the [throw](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/throw) expression.

```csharp
throw new Exception("Failed");
```

`throw` requires an expression of type [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception). In most cases the expression is a new instance but the exception could come from elsewhere, such as the return value of a method.

When the statement executes the exception is raised. The current method stops executing and the runtime begins error handling as discussed later. The remainder of the method will not execute.

## Rethrowing an Exception

When inside a [catch](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch) block the `throw` statement allows a shorter syntax.

```csharp
try
{
   //Code
} catch
{
   throw;
};
```

This is known as a "rethrow". The statement does not accept an expression but instead rethrows the current exception. This is the preferred approach to rethrowing an exception as it allows the original exception, including stack trace, to be retained.

## How Exception Handling Works

When an exception is thrown the following steps are taken.

1. The current method stops executing.
1. The [StackTrace](https://docs.microsoft.com/en-us/dotnet/api/system.exception.stacktrace) of the exception is updated to match the location where the `throw` statement was executed.
1. An appropriate exception handler is located, if any.
1. The call stack is unwound until the method containing the exception handler is reached, if any.
1. Execute continues inside the exception handler, if any.

This is known as a first-chance exception. The application is given a chance to handle the exception. To locate an exception handler the runtime does the following.

1. Starting with the current stack frame see if the code is wrapped in a [try-catch](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch) block. If it is then determine if the `catch` block can handle the exception. If the `catch` block can handle the exception is becomes the exception handler for the exception.
1. If the current stack frame cannot handle the exception (either because it does not have a `try-catch` or the `catch` blocks do not handle the exception) then move back to the previous stack frame and repeat the process.
1. If the runtime gets to the root of the call stack then it is done.

If no exception handler is found then the exception becomes an unhandled exception (second-chance exception). When an unhandled exception occurs and a debugger is attached then the debugger gets notified. In a debugger like Visual Studio the debugger will break into the code and let you see the status of the application. Outside a debugger the program will terminate. In Windows the Windows Error Reporting (WER) tool runs and records the process information and error and then displays an error to the user before terminating the application.

## See Also

[Exceptions](exceptions.md) \
[Handling Exceptions](handling-exceptions.md) \
[(C#) Throw](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/throw)
