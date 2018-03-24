# Lab 4 (ITSE 1430)

In this lab, you will expand your existing Windows Forms movie collection program to use a database and add error handling. Unless otherwise stated, all previous behavior and functionality remains the same.

You will not be adding any new forms for this lab but you will be changing the behavior of the existing code.

## Setting Up the Solution

1. Copy the contents of the entire solution folder to a new folder called ```Lab4```. Ensure it is still in your ```Labs``` folder.
1. Rename the solution file to ```Lab4.sln```.

## Adding the SQL Database

For this lab you will be connecting to a SQL database. Visual Studio ships with a local copy of SQL Server so all the software is already available to you. 
The database is provided as a separate project that you will load into your solution.

1. Download the [MovieDatabase.zip](MovieDatabase.zip) file to your machine.
1. Extract the contents of the file into your solution folder. The contents should extract to a ```MovieDatabase``` folder where the project file resides.
1. In Solution Explorer, right click the solution and select ```Add\Existing Project```.
1. Navigate to the project file and select it.

## Update the IMovieDatabase to use IEnumerable

If the interface is still using an array or [List<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1) for any members then switch it over to use
[IEnumerable<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) instead. Fix any implementation logic around the changes.

## Create a Base Implementation for IMovieDatabase

Like we did in class, we want to abstract out the common implementation details for the ```IMovieDatabase```. This will allows us to more easily create new
implementations later.

1. Copy the existing ```MemoryMovieDatabase``` class into the core business library under a namespace/folder called ```Data```.
1. Rename the type (and file) to ```MovieDatabase```.
1. Mark the class as abstract.
1. Fix the namespace to match the project and folder it now resides in.

Abstract out the functionality that is specific to an implementation. For each public member create a corresponding protected abstract method that is responsible for handling the 
implementation-specific details, if any. Replace the implementation-specific logic in the public member with a call to the protected member.
You may use any naming convention you want but be consistent. For example you may add a suffix of ```-Core``` or ```-Base``` to each protected member.

*Note: A good rule of thumb for identifying common vs implementation-specific details is to consider at least two different implementations and what they would need (i.e. a file and database)*

Clean up the remaining abstract base class code. 

- There should be no references to the in-memory collection anymore.
- The using statements should be cleaned up to remove unused references.
- The only public members should be those defined by the ```IMovieDatabase``` interface.
- Remove any constructors that are defined on the type.

## Update MemoryMovieDatabase

Change the ```MemoryMovieDatabase``` to derive from ```MovieDatabase``` instead of implementing the ```IMovieDatabase``` interface. Convert each of the public members into the corresponding
protected member equivalent. Remove any logic from the methods that are already handled by the base type. For example the validation is handled in the base type so it can be removed from
the derived type unless it is specific to the implementation.

## Add Error Reporting to the Database

The code will now throw exceptions to report errors instead of string messages. 

1. Remove any references to the message (out) parameter in the methods. This is a change to the interface, abstract class and derived types.
1. Add the appropriate [doctags](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/exception) for the errors.

For each member that needs to report errors throw the appropriate exception instead. The following guidelines should be used.

- Throw an [ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) exception (with appropriate argument name) for any arguments that are ```null```.
- Throw an [ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception) exception (with appropriate argument name) for any argument that should be in a particular range but isn't.
- Throw an [ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception) exception (with appropriate argument name) for any arguments that are not valid for other reasons.
- Throw an [InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) exception when the requested call is invalid given the current state of the system.
- Throw an [ValidationException](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationexception) exception if a parameter implements [IValidatableObject](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.ivalidatableobject) and the argument is invalid.
- Throw an [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception) exception (with appropriate message) when an error occurs that is not covered by another exception.

For [IValidatableObject](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.ivalidatableobject) the [Validator](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validator) type has a helper method [ValidateObject](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validator.validateobject) that throws automatically if validation fails. Consider 
creating a helper method to wrap this call.

*Note: Protected members generally do not need to report errors because the public implementation is handling the details. But any implementation-specific errors should throw exceptions.*

### Add Validation

- The movie cannot be ```null```.
- The movie must be valid.
- A movie with the same name cannot already exist.

### Get Validation

- The ID must be greater than 0.

*Note: Trying to retrieve a movie that does not exist is fine. Return ```null``` instead of throwing an exception.*

### Remove Validation

- The ID must be greater than 0.

*Note: Removing a non-existent movie is fine and should not report an error.*

### Update Validation

- The movie cannot be ```null```.
- The movie must be valid.
- The movie must already exist in the database.
- A movie with the same name cannot already exist (except the movie itself).

## Add Error Handling to the UI

In the UI, wrap each call to the database with a [try-catch](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/). Report any errors to the user and continue
as you would have previously.

## Implement the SQL Movie Database

With the existing SQL database project added to the solution it is now possible to store the movies in the SQL database.

1. Create a new Class Library project in the solution called *name*```/MovieLib.Data.Sql```. 
1. The project will need a reference to the ```MovieLib``` project.
1. Create a new class ```SqlMovieDatabase``` that derives from ```MovieDatabase```.
1. Ensure the class is properly documented using [doctags](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/summary).
1. Implement each of the abstract members as described below.
1. The type will need a constructor that accepts the connection string. *Note: Do not hard code a connection string in the code.*

Some guidelines about the implementation.

- The movies will be stored in the database so the issues with copying and cloning the movie no longer exist. The SQL implementation does not need any of this functionality.
- The database will auto-generate a movie ID so any logic around tracking this information manually is not needed.
- When working with databases errors outside your control can occur. Do not handle these errors in your implementation unless you intend to try to recover (i.e. trying the call again). Simply let the errors bubble up.
- Ensure the database connection is properly cleaned up each time with the [using](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement) statement.
	
The following stored procedures are available.

| Stored Procedure  | Parameter Name    | Parameter Type    | Returns   | Comments
|-------------------|-------------------|-------------------|-----------|---------
| AddMovie          |                   |                   | ID        | ID is an integral value
|                   | @title            | string            |           |
|                   | @length           | int               |           | Length, in minutes
|                   | @isOwned          | bool              |           |
|                   | @description      | string            |           |
| GetMovie          |                   |                   | ID, Title, Description, Length, IsOwned |
|                   | @id               | int               |           | ID of the movie to retrieve
| GetAllMovies      |                   |                   | See ```GetMovie``` | Same as ```GetMovie``` except it returns a list of movies
| RemoveMovie       |                   |                   |           |
|                   | @id               | int               |           | ID of the movie to remove
| UpdateMovie       |                   |                   |           | 
|                   | @id               | int               |           | ID of the movie to update
|                   | @title            | string            |           |
|                   | @length           | int               |           | Length, in minutes
|                   | @isOwned          | bool              |           |
|                   | @description      | string            |           |

## Using the SQL Database

### Add the Connection String

To connect to the database you need to store the connection string in the configuration file. DO NOT store the connection string anywhere other than in the configuration file.
Open the configuration file and add the following as the last element inside the ```configuration``` element.

```
<connectionStrings>
    <add name="MovieDatabase" connectionString="Server=(localdb)\ProjectsV13;Database=MovieDatabase;Integrated Security=True" providerName="System.Data.SqlClient" />>
</connectionStrings>
```

*Note: It is possible that your machine may have a sliently different server name. If you cannot connect to the database using the given string then open the database in SQL Server Object Explorer. Find
the database. The server name is shown in the view.*

### Using the SQL Database

The main form will be updated to use the ```SqlMovieDatabase``` to manage the movies. Replace the existing ```new``` statement to create an instance of this type instead. The constructor
requires a connection string. Specify the connection string name that was added to the configuration file earlier (i.e ```MovieDatabase```).

*Note: The SQL database already has some movies added. Remove any logic for seeding the database if you added any to your code.*

## Test Scenarios

- Grid loads the movies correctly.
- Adding a movie works correctly.
- Deleting a movie works correctly.
- Updating a movie works correctly.
- Attempting to add/edit a movie with no name or a length of < 0 displays an error.
- Attempting to add/edit a movie with the same name as an existing movie displays an error.

## Requirements

- Code compiles cleanly without warnings and errors.
- Each file has a file header.
- Public types and members have doctags.
- All code uploaded to Github.
- Lab submitted using MyTCC.
