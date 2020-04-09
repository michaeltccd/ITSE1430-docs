# Raising Exceptions
*Updated: 4/8/2020*

[Simple Handling](#simple-handling) \
[Handling Multiple Types](#handling-multiple-types) \
[Rethrowing an Exception](#rethrowing-an-exception) \
[Errors While Handling Errors](#errors-while-handling-errors) \
[Cleaning Up](#cleaning-up) \
[See Also](#see-also)

It is important for applications to handle errors that they can recover from. This provides a better user experience and allows for applications to be more resilient to unexpected errors. C# provides the [try-catch](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch) block to support error handling.

Refer to [Throwing Exceptions](#throwing-exceptions.md) for more information on how exception handlers are located.

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

*Note: Prefer using `throw` to `throw expression` except in the cases where you need to hide the original exception.*

## Errors While Handling Errors

Care must be taken to ensure the code in a `catch` block does not raise errors itself. If a `catch` block raises an error (either directly or indirectly) then the original exception will be lost. The runtime considers an exception "handled" as soon as it finds a `catch` block to handle the error. Therefore errors that occur inside the `catch` block are treated as brand new errors and the process starts all over again.

The `catch` block should be as error resilient as possible. This generally means limiting the behavior of the code inside the block to the minimal amount of code and adding extra error checking to ensure it does not fail.

## Cleaning Up

In some cases resources must be cleaned up after code executes. In a normal flow we can just add the code as part of the sequential execution of the method.

```csharp
try
{
   var resource = GetSharedResource();
   //Do work

   FreeResource(resource);
} catch 
{   
};
```

This code is not "exception-safe" (safe to run even when an exception occurs). If an error occurs after the resource is allocated but before it is freed then the line containing the cleanup method will never run and we have a resource leak. To fix this we need to ensure the resource is cleaned up in both cases.

```csharp
IResource resource = null;
try
{
   resource = GetSharedResource();
   //Do work

   FreeResource(resource);
} catch 
{   
   //Handle error
   if (resource != null)
      FreeResource(resource);
};
```

For a single method call this is OK but if the cleanup requires more code then we are repeating ourselves which is bad. Even worse is that this is still not exception safe. If the code in the `finally` block throws an exception then the resource is not going to cleaned up.

A better approach is to use the [finally](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch-finally) block. A `finally` block can be added after the `catch` blocks to allow cleanup of resources. A `finally` block is always guaranteed to execute irrelevant of whether the code completed successfully or an error was thrown. This guarantee makes clean up exception safe.

```csharp
IResource resource = null;
try
{
   resource = GetSharedResource();
   //Do work   
} catch 
{   
   //Handle error  
} finally
{
   if (resource != null)  
      FreeResource(resource);
};
```

Notice in this code we needed to hoist the `resource` variable outside the `try` block so it could be accessed in the `finally` block. We also need to ensure that the variable is valid before we use it. Code in the `finally` block should make no assumption that any code has executed before it runs. Lastly, just like the `catch` block, ensure the code in the `finally` block is resilient. Any error in this code is just like an error in a `catch` block. 

`finally` blocks are executed after either the `try` or `catch` block executes to completion. If no `catch` block executes (or fails) then the `finally` block is still executed.

The `catch` block is optional when using a `finally` block. `finally` blocks can be used to clean up any resources, irrelevant of whether exception handling is used or not.

```csharp
IResource resource = null;
try
{
   resource = GetSharedResource();
   //Do work   
} finally
{
   if (resource != null)  
      FreeResource(resource);
};
```

## See Also

[Exceptions](exceptions.md) \
[Exception Filters](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch) \
[Raising Exceptions](raising-exceptions.md) \
[(C#) Try-Catch](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch) \
[(C#) Try-Catch-Finally](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch-finally)