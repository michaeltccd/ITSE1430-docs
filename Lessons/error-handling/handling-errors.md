# Handling Errors
*Updated: 4/8/2020*

[Simple Handling](#simple-handling) \
[Handling Multiple Types](#handling-multiple-types) \
[Rethrowing an Exception](#rethrowing-an-exception) \
[Cleaning Up](#cleaning-up) \
[See Also](#see-also)

It is important for applications to handle errors that they can recover from. This provides a better user experience and allows for applications to be more resilient to unexpected errors. C# provides the [try-catch](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch) block to support error handling.

Refer to [How Exception Handling Works](#how-exception-handling-works.md) for more information on how the runtime works with exception handlers.

## Simple Handling

The simple syntax for a `try-catch` in C# looks like this.

```csharp
try 
{
   //Statements to attempt to run
} catch
{
   //Statements to run if an error occurs
}
```

The `try` block contains the code to try and execute. The `catch` block contains the code used to handle any errors that occur. In this example the caller is trying to update some data in the database. If any errors occur the program will display an error to the user.

```csharp
try
{
   UpdateDatabase();
} catch
{
   DisplayError("Update failed");
};
```

Only the code inside the `try` block is protected. If any errors occur then the remainder of the code in the `try` block is skipped and the code in the `catch` block is executed. After the `catch` block executes then the code after the `try-catch` runs. The code in the `try` block will not resume execution. Therefore it is important to limit how much code is inside the `try` block.

*Note: The `catch` block should be as error resilient as possible. If an error occurs inside the `catch` block then the original error is lost and error handling starts over again.*

One problem with the above code is that it does not report anything useful to the user. The [exception](exceptions.md) object that the runtime created is not accessible. To get access to it we need to store the exception into a temporary variable.

```csharp
try 
{
   UpdateDatabase();
} catch (Exception e)
{
   DisplayError(e.Message);
}
```

The variable `e` contains the `Exception` instance for the life of the `catch` block. Code can use this to retrieve information from the exception, such as the message.

*Note: `Message` is a programmer-friendly message and should generally not be displayed to the end user. Most applications convert the exception to a user-friendly equivalent.*

## Handling Multiple Types

In the simple syntax the `catch` block was handling all errors that could occur. In a more realistic example an application may handle one set of errors different from another, or not at all. Fortunately you can have multiple `catch` blocks with a single `try` block.

```csharp
try 
{
   UpdateDatabase();
} catch (InvalidOperationException e)
{
   //Handler for this type of exception
} catch (ArgumentException e)
{
   //Handler for this type of exception
} catch (Exception e)  //Optional
{
   //Handler for any other exceptions
}
```

Using multiple `catch` blocks allows an application to handle different types of errors differently which is exactly what the exception type is for. When the runtime is looking for a handler it walks the `catch` blocks from top to bottom until it finds a type that the current error is compatible with. Only a single `catch` block will execute for each error so any shared error handling needs to be contained in a helper method.

If the runtime does not find any `catch` block that matches the error then it is the same as if no `catch` blocks existed and the runtime continues looking for a handler further up the call stack. To ensure all exceptions are caught make the last block catch any exception. 

*Note 1: Only handle errors that it can recover from. It is considered bad practice to silently handle exceptions.* 
*Note 2: Only one catch block will execute per exception.*
*Note 3: Catch blocks are evaluated top down until a matching type is found.*

## Rethrowing an Exception

Sometimes while handling an exception an application determines that it cannot handle the exception. As far as the runtime is concerned, once a `catch` block starts executing the exception is handled. To notify the runtime that the exception is not handled you may do one of the following inside the `catch` block.

```csharp
catch (Exception e)
{
    throw;   // 1

    throw e;  // 2
}
```

The first usage is preferred and is known as "rethrowing the exception". In this case the original exception is marked as unhandled and the runtime continues looking for a handler. The stack trace of the exception remains intact and later handlers cannot tell that the exception was initially handled. This is the preferred approach when a `catch` block just needs to record that an exception occurred, via logging.

The second usage is actually no different than using `throw` anywhere in code. A brand new exception is thrown. In the example the original exception is thrown again. The stack trace is updated to point to the `catch` block as the source and the runtime then starts looking for handlers again. This usage is most appropriate when code needs to "rewrite" an exception. The most common case is to wrap an existing exception in another exception. In this example the calling code is wrapping all exceptions in a generic `InvalidOperationException` to hide the implementation details.

```csharp
try
{
   UpdateDatabase();
} catch (Exception e)
{
   throw new InvalidOperationException(e);
};
```

In this example the original exception becomes the inner exception of the new exception that is raised at this point. Lower level code that handles this exception will only see this exception but can look at the [InnerException](https://docs.microsoft.com/en-us/dotnet/api/system.exception.innerexception) property of the exception to see what the original exception was.

## Cleaning Up

## See Also

[Exceptions](exceptions.md) \
[Exception Filters](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch) \
[How Exception Handling Works](#how-exception-handling-works.md) \
[Reporting Errors](reporting-errors.md)