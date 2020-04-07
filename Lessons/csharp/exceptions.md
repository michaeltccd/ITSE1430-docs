# Exceptions

Base Type: `System.Exception`

Core information an exception provides.

- Type
- Message
- Callstack

## Properties

| Property | Type | Description |
| - | - | - |
| Message | `string` | Error message |
| InnerException | `Exception` | Nested error, if any |
| StackTrace | `string` | Call stack at point of exception |

## Common Exceptions

`Exception` is the base type for all exceptions.

- `ArgumentException` - Raised when an error occurs with an argument.
  - `ArgumentNullException` - Raised when an argument is `null`.
  - `ArgumentOutOfRangeException` - Raised when an argument is not in an expected range.
- `InvalidOperationException` - Raised when an operation is not currently valid.
- `ValidationException` - Raised when a validation error occurs.

System exceptions derive from `SystemException` and represent errors from the system. These should never be thrown by your code.

- `NullReferenceException` - An instance is `null`.
- `OutOfMemoryException` - Out of memory. Always fatal.
- `StackOverflowException` - Stack overflowed. Always fatal. 

## Handling Errors

Use the `try-catch` block to handle errors.

```csharp
try 
{
   //Statements to attempt to run
} catch
{
   //Statements to run if an error occurs
}
```

It is common to capture the error into a temporary variable so you can use it.

```csharp
try 
{
   //Statements to attempt to run
} catch (Exception e)
{
   //e contains the error
}
```

Can use exception type to handle different exceptions differently using multiple catch blocks. 

```csharp
try 
{
   //Statements to attempt to run
} catch (InvalidOperationException)
{
   //Handler for this type of exception
} catch (ArgumentException)
{
   //Handler for this type of exception
} catch (Exception)  //Optional
{
   //Handler for any other exceptions
}
```

*Note 1: Only one catch block will execute per exception.*
*Note 2: Catch blocks are evaluated top down until a matching type is found.*