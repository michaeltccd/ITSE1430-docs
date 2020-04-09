# Interfaces

*Version: 1.0 (22 March 2020)*

[Common Interfaces](#common-interfaces)\
[Consuming Interfaces](#consuming-interfaces)\
[Creating Interfaces](#creating-interfaces)\
[Implementing Interfaces](#implementing-interfaces) \
[See Also](#see-also) \

An [interface](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/) is a type that declares members that other types will provide. It is a [contract](https://en.wikipedia.org/wiki/Design_by_contract) between two different components that allow them to interact with each other. The interface provides the members that are available and one of the components provides the implementation of each of those members. This decouples the implementation from the usage of that implementation. It is a core technique used to solve the problem of dependencies between components.

Here is an example of a simple interface in C# that allows an object to be selectable (such as in a drawing program).

```csharp
public interface ISelectable
{
   void Select ();

   bool IsSelected { get; }
}
```

The [syntax](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface) is very similar to a class with a few notable exceptions.

- The keyword `interface` replaces the keyword `class`.
- There is no accessibility modifier on the members.
- There is no implementation for properties and methods.
- Only certain types of members are allowed (properties, methods, events).

An interface defines the set of functionality available for calling code to use. In the above example calling code can use the interface to determine if an item is selected and select if it desired. Notice that how this works (the implementation) is not part of the interface. This is the primary benefit of interfaces. It should not matter how the implementation works from the callers point of view. In fact the implementation should be able to change based upon other needs and calling code should not be impacted. As an example, if this is being implemented in a Windows Forms application we are probably relying mostly on the operating system to provide this functionality. But in a web application we are going to be relying on Javascript instead. The calling code does not care how it works, just that it is available.

## Common Interfaces

.NET ships with a lot of interfaces. Some interfaces you may already have used without realizing it.

| Interface | Purpose |
| - | - |
| [ICloneable](https://docs.microsoft.com/en-us/dotnet/api/system.icloneable) | Supports cloning an object. |
| [IComparable<T>](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1) | Supports comparing two objects for ordering. |
| [IEnumerable<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) | Supports enumerating over a set of data. |
| [IList<T>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1) | Supports managing a list of objects. |
| [IValidatableObject](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.ivalidatableobject) | Supports validation of an object. |

In many cases you may not even realize you are using an interface. But in all cases you probably did not care how the functionality was provided, just that it worked. That is the benefit of interfaces.

## Consumng Interfaces

Interfaces are treated as types in .NET. They are first class citizens. Therefore an interface can be treated like any other type unless otherwise specified. That means you can declare variables and parameters of an interface type and return interfaces from methods. 

It is important to remember that an interface is just the declaration of functionality, without the implementation. Interfaces are what other languages call pure abstract classes. That is a type that has no implementation details. An interface is just a set of member declarations. Since an interface has no implementation an instance of an interface cannot be created directly using `new`. Attempting to do so results in a compiler error. 

```csharp
ISelectable selectedItem = new ISelectable(); // ERROR
```

To get an interface instnace you must be passed an existing instance of a type that implements the interface. This can happen in a number of ways:

- Create an instance of a type that implements the interface
- Receive the instance as the result of an expression such as a function call
- Receive the instance as the argument of a function
- Typecast an existing object

```csharp
// Create an instance of a type that implements the interface
ISelectable selectedItem = new SelectableObject();

// Get from a method
ISelectable selectedItem2 = GetSelectedObject();

//Receive as a parameter
void HandleSelection ( ISelectable value ) { }

//Type cast an existing object
ISelectable existing = someValue as ISelectable;
```

Once you have an interface instance you can call its members like you would for any other type.

```csharp
//Select the object
ISelectable selectedValue = GetSelectedObject();

if (!selectedValue.IsSelected)
   selectedValue.Select();
```

Interfaces are reference types in .NET and therefore can be `null`. Code that works with interfaces should follow the same null-checking rules that apply to all reference types.

Like traditional typecasting, an interface does not change the underlying instance. Using an interface simply tells the compiler to limit the members that are available to the calling code. The underlying instance is still typed as whatever type was used when it was created. Calling code can "upcast" back to the original type if it is confident this is true but that defeats the purpose of interfaces.

```csharp
var originalInstance = new SelectableObject();  //Implements ISelectable

//Treat instance as interface instead which restricts access to only the members defined by ISelectable
//This assignment does not change the instance in any way at runtime
ISelectable selectedItem = originalInstance;

//If the code "knows" the underlying instance type then an upcast will work, but not recommended
var newInstance = selectedItem as SelectableObject;  //Will work because the instance is of the requested type
```

## Creating Interfaces

Sometimes it may be necessary to create a new interface. Creating an interface syntactically is straightforward but creating a good interface is difficult as discussed later.

Creating a new interface is similar to creating a new class except no implementation details are needed.

```grammar
interface ::= [access] 'interface' <id> '{' member* '}'

member ::= <method | property | event

event ::= 'event' <id> ';'

property ::= <type> <id> '{' ['get;'] ['set;'] '}'

method ::= <type> <id> '(' parameters* ');'

parameters ::= standard parameter syntax
```

It is the standard to start interfaces with "I". This helps indicate to calling code that the type is an interface. This is one of the rare cases where Hungarian notation is still used. Unlike regular types interfaces are generally named using verbs. Classes represent objects and therefore are nouns, interfaces represent functionality. Interfaces are used to identify functionality that types can provide such as comparability, enumerability and validatability. 

As mentioned earlier interfaces are contracts so the members are always public. There is no implementation of any members so each declaration ends with a semicolon. For properties the interface may require a getter, setter or both.

While there is no restriction on how many members can be in an interface each interface should provide only the members needed to provide a single set of functionality. If additional functionality is needed then create a new interface. It is preferable to have many small interfaces rather than several large interfaces. Remember that an interface is simply exposing a set of functionality. Any implementing type must provide all those members The more members there are the harder it is to implement. Furthermore if a type does not want to expose functionality then it simply refrains from implementing the interface. The larger the interface the more likely it is that a type will not support all the functionality. 

For example if we want to support selection and resizing of objects we would use the `ISelectable` interface for selection and the `IResizable` interface for resizing. It might be defined like this.

```csharp
public interface IResizable
{
   Rectangle BoundingBox { get; set; }

   void Resize ( int width, int height );
}
```

It might seem wasteful to create two interfaces for four members but what this provides the most flexibility to implementors. It is possible to have a selectable object but not a resizable one (e.g. a point). It might also be possible to be able to resize an object but not select it. Having separate interfaces allows eaach implementation to pick and choose what functionality it will support.

Interfaces are immutable once they are released. Therefore it is critical that when creating a new interface you carefully design the interface to contain all the members that may be needed to consume the interface. Furthermore you must be careful to not include any implementation details in the interface but still allow enough flexibility for a variety of implementations to be created. This requires a good understanding of how the interface should behave and how it might be used. 

*Note: It is common to create an interface as code is being written but this is almost never the correct approach. In the case of a single implementation there is no need for an interface. The recommendation is to rely on standard classes and inheritance until at least two different implementations exist and then normalize the shared behavior into an interface.*

## Implementing Interfaces

???

Interfaces are generally used to indicate that some type "supports" some functionality (e.g. selection). Therefore it is quite common for a type to implement one or more interfaces indicating it supports one or more features. 


Continuing with the `ISelectable` interface, how you implement selection for a circle is different than how you might implement it for a rectangle. For non-rectangular objects you generally calculate a "bounding box" around the entire shape. In the case of a circle that would be a box that exactly encloses the circle. For a rectangle however it is the bounding box. Again, code wanting to select the object does not care whether it is a circle or rectangle, it simply "selects" the object. 


A type indicates the interface(s) it implements by including them using the same syntax that is used for base types. This is a syntactical convenience and should not be used to imply an interface is a base type. 

```csharp
public class Circle : ISelectable, IResizable
{ ... }
```

A single type can implement any number of interfaces. When a type indicates it implements an interface it is agreeing to provide an implementation for all the members defined in the interface. Therefore the compiler will require that all the interface members have an implementation. Failure to do so results in a compiler error. To implement a member provide a public member that matches the signature of each interface member.

```csharp
public class Circle : ISelectable, IResizable
{
  // ISelectable Members
  public void Select () { ... }
  public bool IsSelected { get; set; }

  //IResizable Members
  public void Resize ( int newWidth, int newHeight ) { ... }
}
```

If multiple interfaces declare the same member then only a single implementation is needed. For properties it is allowed to add a getter/setter even if the interface does not explicitly allow it. This is for convenience.

*Note: The interface members must be public.*

The above syntax is referred to as "implicit interface" syntax. In this mode all the interface members are also public members of the corresponding type. This is the most common situation. But there are times when you do not want this behavior. There is also an "explicit interface" syntax that can be used. (*Note: you can use both syntax in the same type, implementing some members explicitly and others implicitly*)

??


## Consuming an Interface

? Compared to base types - is-a, changing POV
  ? value types
  ? multiple

? Multiple interfaces, discoverability

? Defining an interface
  ? Breaking changes
  ? Explicit vs implicit
  ? naming
  no ctors, fields, private

? Generic interfaces

? IEnumerable/IEnumerator
  with foreach
  iterator syntax

? IValidatableObject and Validator

## See Also

[Abstract Classes]() \
