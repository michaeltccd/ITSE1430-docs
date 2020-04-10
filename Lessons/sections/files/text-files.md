# Text Files
*Updated: 4/8/2020*

[Buffered IO](#buffered-io) \
[Streamed IO](#streamed-io) \
[Streams](#streams) \
[Opening a File](#opening-a-file) \
[Using a Stream](#using-a-stream) \
[Using a Stream Reader](#using-a-stream-reader) \
[Using a Stream Writer](#using-a-stream-writer) \
[See Also](#see-also)

## Buffered IO

Working with a file requires that you access a shared resource in the file system. When working with shared resources applications must ensure they release the resource when they no longer need it. In most languages this requires using the language-provided syntax to ensure clean up of the file handle (the operating system reference to the file).

.NET provides a simple, buffered approach to reading and writing files for the common case of just needing to quickly read/write a file without the hassle of opening and closing a file.

*Note: Refer the section on streamed IO for cases where buffered IO is not appropriate.*

### Reading Files

To read a file use either the [File.ReadAllLines](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readalllines) or [File.ReadAllText](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readalltext) methods. Both methods read the entire contents of the file into memory but return different values. `ReadAllLines` returns a string array where each line of the file is an element in the array. `ReadAllText` returns the file contents as a single string.

```csharp
//File contents:
// Line 1
// Line 2
// Line 3
var filename = "somefile.txt";

//Contains 3 elements: Line 1, Line 2, Line 3
var lines = File.ReadAllLines(filename);

//Contains the entire contents of the file as a single string
var text = File.ReadAllText(filename);
```

Which method to use depends on what you want to do with the file contents. If you want to treat each line separately (like rows in a CSV file) then `ReadAllLines` is most appropriate. This method will strip off the newline character(s) from the file. If you want the newline characters in the file because you need to pass the string to another component then use `ReadAllText`. This method leaves the newlines in the string. 

*Note: Different platforms use different end of line characters. If you are only working with a single operating system then this generally isn't an issue. If you need to support files generated in other file systems then either use `ReadAllLines` to handle the conversion for you or you will need to write your own code to properly detect end of line.*

### Writing Files

Writing files using the buffered approach has a similar format to reading. [File.WriteAllLines](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealllines) method writes a string array to a file. The [File.WriteAllText](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealltext) method writes a string to a file. 

```csharp
var filename = "newfile.txt";

File.WriteAllLines(filename, new [] { "Line 1", "Line 2", "Line 3" });

File.WriteAllText(filename, "Line 1\nLine 2\nLine 3\n");
```

In both cases the existing file is overwritten. To append to an existing file use the corresponding [File.AppendAllLines](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.appendalllines) and [File.AppendAllText](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.appendalltext) methods instead.

## Streamed IO

In the buffered approach it requires a single line to read or write files. The methods are responsible for opening the file, reading/writing the data and closing the file so your code does not have to. However this is inefficient in some cases.

- You do not need to read/write the entire file such as when searching for a particular line.
- The file is large (e.g. more than a couple of megabytes in size).
- You need to ensure the file is not modified while you are reading/writing the file.
- You need to be able to abort the request while reading or writing.
- You need the code to be as fast as possible.

In these cases streaming is the better option. Unfortunately streaming requires more code and mandates that your code ensure the file is properly closed.

### Streams

A stream is a sequence of data. It can be anything from streams of characters to streams of bytes. In .NET a stream is represented by the abstract class [Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream). Streams have differing characteristics and the `Stream` class tries to wrap them in a usable class. Here are some common members on the class and their purpose.

| Member | Description |
| - | - |
| [CanRead](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.canread) | Determines if the stream can be read. |
| [CanSeek](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.canseek) | Determines if the stream supports random access. |
| [CanWrite](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.canwrite) | Determines if the stream can be written. 
| [Close](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.close) | Cleans up the stream.
| [Length](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.length) | Determines the length of the stream, if possible. |
| [Read](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.read) | Reads the stream, if supported. |
| [Seek](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.seek) | Seeks somewhere in the stream, if supported. |
| [Write](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.write) | Writes the stream, if supported. |

Because streams can vary so wildly code must be careful when accessing a stream to ensure they do not misuse the stream. Misusing a stream generally results in an exception.

```csharp
public int ReadInt32 ( Stream stream )
{
   if (!stream.CanRead)
      throw new InvalidOperationException("Stream does not support reading.");

   var buffer = new byte[4];
   var read = stream.Read(buffer, 0, buffer.Length);
   if (read < buffer.Length)
      throw new InvalidOperationException("Insufficient space.");

   return BitConverter.ToInt32(buffer, 0);
}
```

.NET ships with quite a few different stream implementations. Each implementation provides a different set of functionality. 

| Type | Usage |
| - | - |
| [FileStream](https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream) | The underlying type used when reading and writing files. |
| [MemoryStream](https://docs.microsoft.com/en-us/dotnet/api/system.io.memorystream) | An in-memory stream. This is the only stream you might create directly in code. |
| [NetworkStream](https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.networkstream) | The underlying type used when reading or writing data across the network. |

It is rare that you will work directly with a derived stream type. Instead your code will generally use a `Stream` created by a method without regard for the type. Unless you need a specific type of stream AND typecasting is not an option then stick with `Stream`.

```csharp
Stream stream = OpenFile("testfile.txt");
```

### Opening a File

Closing the file

### Using a Stream

Closing the stream

### Using a Stream Reader 

### Using a Stream Writer

## See Also

[Binary Files](binary-files.md)\ 
[StreamReader Class]() \
[StreamWriter Class]() \
[Stream Class]()
