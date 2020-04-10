# Files
*Updated: 4/8/2020*

[File Class](#file-class) \
[File Exceptions](#file-exceptions) \
[Common File Operations](#common-file-operations) \
[Working with Paths](#working-with-paths) \
[See Also](#see-also)

Many programs need to read and write files. .NET has support for files (and directories) but it's approach is a little different from most other languages. .NET breaks up file operations into file manipulation (such as renaming and moving) and file reading/writing. 

## File Class

To manipulate files you use the [File](https://docs.microsoft.com/en-us/dotnet/api/system.io.file) class. This class is defined in the `System.IO` namespace. It is a static class containing helper functions for working with files. In most cases you will start with the `File` class.

## File Exceptions

For most file operations the call will fail if the file name is `null`, empty or an invalid path. In addition to the standard exceptions, the following exceptions are also commonly raised by file operations.

| Exception | Description |
| - | - |
| [DirectoryNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/system.io.directorynotfoundexception) | The filename contains a directory path that could not be found. |
| [FileNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/system.io.filenotfoundexception) | The file could not be found. |
| [PathTooLongException](https://docs.microsoft.com/en-us/dotnet/api/system.io.pathtoolongexception) | The path exceeds the size allowed by the file system. |
| [UnauthorizedAccessException]() | The user does not have permission to access the file or directory. |
| [IOException](https://docs.microsoft.com/en-us/dotnet/api/system.io.ioexception) | An error occurred trying to perform the operation. This is the base class for most of the other exceptions so list it last when using [try-catch](..\error-handling\handling-exceptions.md) blocks. |

## Common File Operations

### Determine If a File Exists

Use the [File.Exists](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.exists) method to determine if a file exists.

```csharp
var filename = "Somefile.txt";
if (File.Exists(filename))
   //File exists
```

Most file operations will fail if a file does not exist. Use this method to check before attempting a file operation.

*Note: Even when using this method it is possible for a file to be removed before the file operation occurs. Therefore you should always use error handling to recover from a missing file.*

### Copy a File

Use the [File.Copy](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.copy) method to copy a file from one location to another.
```csharp
var sourceFile = "SomeFile.txt";
var targetFile = "NewFile.txt";

File.Copy(sourceFile, targetFile);
```

If the target file already exists then the method fails. To overwrite an existing file use the overload accepting a `boolean` or delete the file first.

### Delete a File

Use the [File.Delete](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.delete) method to delete a file.

```csharp
var filename = "SomeFile.txt";

File.Delete(filename);
```

If the file is read only or locked then the method fails.

### Move a File

Use the [File.Move](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.move) method to move or rename a file.

```csharp
var sourceFile = "SomeFile.txt";
var targetFile = "NewFile.txt";

File.Move(sourceFile, targetFile);
```

If the file already exists it will fail. Delete the file first.

If you move a file across volumes (e.g. `C:\` to `D:\`) then it will normally work. If the source file is locked the file is copied instead.

### Reading and Writing Files

Refer to the sections [Text Files](text-files.md) and [Binary Files](binary-files.md) for information on how to read and write files.

## Working with Paths

The `File` class does not manage paths. It simply passes any file paths onto the file system. To work with file paths refer to the section [Paths](paths.md).

One path that may be important is the current path. By default relative paths (e.g. `.\somefile.txt' or `somefile.txt`) are resolved to the current working directory. 
To get the current working directory use [Environment.CurrentDirectory](https://docs.microsoft.com/en-us/dotnet/api/system.environment.currentdirectory).

```csharp
var filePath = Environment.CurrentDirectory + @"\somefile.txt";
```

When a process starts the working directory is the path to the executable but this can changed as part of the startup parameters to the program.

## See Also

[Binary Files](binary-files.md) \
[Directory Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory) \
[File Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.file) \
[Paths](paths.md) \
[Stream Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream) \
[Text Files](text-files.md)