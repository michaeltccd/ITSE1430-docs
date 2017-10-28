# Section 4 Data Access

Namespace: ```System.IO```

## Error Handling

[Purpose](https://docs.microsoft.com/en-us/dotnet/standard/exceptions/)

[Guidelines](https://docs.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions)

### Exceptions

[Exception Class](https://docs.microsoft.com/en-us/dotnet/api/system.exception)

[Throwing an Exception](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/throw)

[Throw Expression](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/throw#the-throw-expression)

### Common Exceptions

[ArgumentExceptions](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception)

[ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception)

[ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception)

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)

[InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)

[NotImplementedException](https://docs.microsoft.com/en-us/dotnet/api/system.notimplementedexception)

[NullReferenceException](https://docs.microsoft.com/en-us/dotnet/api/system.nullreferenceexception)

[UnauthorizedAccessException](https://docs.microsoft.com/en-us/dotnet/api/system.unauthorizedaccessexception)

### Handling Exceptions

[Try-Catch Statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch)

[Catching Specific Exceptions](https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-use-specific-exceptions-in-a-catch-block)

[Try-Catch-Finally Statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch-finally)

[Rethrowing Exceptions](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/throw#re-throwing-an-exception)

[Filtering Exceptions](https://msdn.microsoft.com/en-us/magazine/mt620018.aspx)

## Files

### Base File Types

[Directory Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory)

[DirectoryInfo Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.directoryinfo)

[File Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.file)

[FileInfo Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileinfo)

[Path Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.path)

### Basic File Operations

[Combine Paths](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.combine)

[Copy File](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.copy)

[File Exists](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.exists)

[Get Directory Name](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.getdirectoryname)

[Get Extension](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.getextension)

[Get File Name](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.getfilename)

[Remove File](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.delete)

### Basic Directory Operations

[Create Directory](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.createdirectory)

[Directory Exists](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.exists)

[Get All Directories](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.enumeratedirectories)

[Get All Files in a Directory](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.enumeratefiles)

[Move a Directory](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.move)

[Remove Directory](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.delete)

## Reading and Writing Files

### Simple Read/Write

[Read All Text](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readalltext)

[Write All Text](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealltext)

[Read All Lines](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readalllines)

[Read All Lines (Enumerable)](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readlines)

[Write All Lines](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealllines)

[Read All Bytes](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readallbytes)

[Write All Bytes](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writeallbytes)

### Streams

[Stream Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream)

[Open a Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.open)

[Read a Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.read)

[Write a Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.write)

[Close a Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.close)

### Stream Readers/Writers

[Open for Reading Text](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.opentext)

[StreamReader Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader)

[Read a Line of Text](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader.readline)

[Read All Text](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader.readtoend)

[StreamWriter Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter)

[Writing Text](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter.write)

[Writing a Line of Text](https://msdn.microsoft.com/en-us/library/system.io.streamwriter.writeline(v=vs.110).aspx)

[BinaryReader Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.binaryreader)

[Reading Binary Data](https://docs.microsoft.com/en-us/dotnet/api/system.io.binaryreader.read)

[BinaryWriter Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.binarywriter)

[Writing Binary Data](https://docs.microsoft.com/en-us/dotnet/api/system.io.binarywriter.write)

## IDisposable Interface

[IDisposable Interface](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)

[Using Statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement)

[Dispose Pattern](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/dispose-pattern)

## LINQ

Namespace: ```System.Linq```

[Purpose](https://docs.microsoft.com/en-us/dotnet/api/system.linq)

[LINQ Syntax](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries)

[Getting Data (from)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations#obtaining-a-data-source)

[Filtering (where)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations#filtering)

[Ordering (orderby)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations#ordering)

[Projections (select)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations#selecting-projections)

[Grouping (groupby)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations#grouping)

[Joining (join)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations#joining)

[Deferred Execution](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/query-execution)

[Composing Queries](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq#composability-of-queries)

### Getting Values

[If All](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.all)

[If Any](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any)

[Get As a List](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.tolist)

[Get As an Array](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.toarray)

[Getting First Item](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.first)

[Getting First Item (if any)](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.firstordefault)

[Getting Last Item](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.last)

[Getting Last Item (if any)](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.lastordefault)

[Getting Only Item](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.single)

[Getting Only Item (if any)](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.singleordefault)

[Getting Empty List](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.empty)

[Casting](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.oftype)

[Skipping Items](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.skip)

[Taking Some Items](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.take)

### Anonymous Types

[Purpose](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/anonymous-types)

[Selecting from LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/type-relationships-in-linq-query-operations#queries-that-transform-the-source-data)

[Tuples](https://docs.microsoft.com/en-us/dotnet/csharp/tuples)

### Lambdas

[Purpose](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions)

[Syntax](https://docs.microsoft.com/en-us/dotnet/csharp/lambda-expressions)

[Lambda Expressions](https://docs.microsoft.com/en-us/dotnet/csharp/lambda-expressions#expression-lambdas)

[Lambda Statements](https://docs.microsoft.com/en-us/dotnet/csharp/lambda-expressions#statement-lambdas)

[Scoping](https://docs.microsoft.com/en-us/dotnet/csharp/lambda-expressions#variable-scope-in-lambda-expressions)

[Expression Bodied Properties](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#property-get-statements)

[Expression Bodied Methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members)

[Local Functions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions)

## Extending Types

### Static Classes

[Purpose](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members)

[Static Members](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static)

[Guidelines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/static-class)

### Extension Methods

[Purpose](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)

### LINQ Extension Methods

[Enumerable Class](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable)

[Filtering](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/filtering-data)

[Ordering](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/sorting-data)

[Projections](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/projection-operations)

[Grouping](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/grouping-data)

[Joining](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/join-operations)

[Set Operations](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/set-operations)

## ADO.NET

[Overview](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-overview)

[Data Access Layers](https://msdn.microsoft.com/en-us/library/ee658127.aspx)

[Providers](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/data-providers)

### Connections

[Connection Strings](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings)

[Creating a Connection](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connecting-to-a-data-source)

[Opening a Connection](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/establishing-the-connection)

### Commands

[Creating a Command](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/executing-a-command)

[Stored Procedures vs Text](https://msdn.microsoft.com/en-us/library/system.data.commandtype(v=vs.110).aspx)

[Passing Parameters](https://msdn.microsoft.com/en-us/library/system.data.common.dbparametercollection(v=vs.110).aspx)

[Executing Non-queries](https://docs.microsoft.com/en-us/dotnet/api/system.data.common.dbcommand.executenonquery)

[Executing Simple Commands with Results](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/obtaining-a-single-value-from-a-database)

### Datasets

[Creating a DataSet](https://docs.microsoft.com/en-us/dotnet/api/system.data.dataset)

[Filling a DataSet](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/populating-a-dataset-from-a-dataadapter)

[Data Adapters](https://docs.microsoft.com/en-us/dotnet/api/system.data.common.dataadapter)

[Enumerating Tables](https://docs.microsoft.com/en-us/dotnet/api/system.data.dataset.tables)

[Table Schemas](https://docs.microsoft.com/en-us/dotnet/api/system.data.datatable.columns)

[Enumerating Rows](https://docs.microsoft.com/en-us/dotnet/api/system.data.datatable.rows)

[Getting Row Values](https://docs.microsoft.com/en-us/dotnet/api/system.data.datarow)

[Creating Rows](https://docs.microsoft.com/en-us/dotnet/api/system.data.datatable.newrow)

[Adding Rows](https://docs.microsoft.com/en-us/dotnet/api/system.data.datarowcollection.add)

### Data Readers

[Purpose](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/retrieving-data-using-a-datareader)

[Getting a Reader](https://docs.microsoft.com/en-us/dotnet/api/system.data.common.dbcommand.executereader)

[Enumerating Resultsets](https://docs.microsoft.com/en-us/dotnet/api/system.data.common.dbdatareader.nextresult)

[Enumerating Rows](https://docs.microsoft.com/en-us/dotnet/api/system.data.common.dbdatareader.read)

[Getting Row Values](https://docs.microsoft.com/en-us/dotnet/api/system.data.common.dbdatareader.getvalue)