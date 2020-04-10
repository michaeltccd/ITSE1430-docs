# Object Oriented Programming
* Updated: 04/10/2020*

WIP

## General Guidelines
- Casing https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/capitalization-conventions
- Naming https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/general-naming-conventions

##	Namespaces
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/namespaces/#namespaces-overview
- Using a Namespace https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive
- Declaring a Namespace https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/namespace
- Fully Qualified Type Names https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/namespaces/using-namespaces#fully-qualified-names
- Guidelines
	- Assemblies https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-assemblies-and-dlls
	- Namespaces https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-namespaces

## Classes
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/classes
- Defining a Class https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class
- Creating an Instance https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/new-operator
- Using Members of a Class https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operator
- Accessibility
	- Public https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers 
	- Internal https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
- Commenting
	- Summary Doctag https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/summary
	- Remarks Doctag https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/remarks
	- Para Doctag https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/para
- Guidelines
	- Naming https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces


## Fields
- Declaring a Field https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/fields
- Accessibility
	- Private https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
- Readonly Keyword https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly
- Const Keyword https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constants
- Guidelines
	- Naming https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-type-members#names-of-fields
	- Design https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/field

## Properties
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties
- Defining a Property https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
- Get Properties https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/get
- Set Properties https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/set
- Auto Properties https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
- Changing Accessibility https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/restricting-accessor-accessibility
- Commenting
	- Value Doctag https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/value
- Guidelines
	- Naming https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-type-members#names-of-properties
	- Design https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/property	

## Methods
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods
- Defining a Method https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods#method-signatures
- Parameters https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/passing-parameters
	- Input https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/method-parameters
	- Output https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-parameter-modifier		
	- Input/Output https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/passing-value-type-parameters#passing-value-types-by-reference
	- Inline Variable Declarations https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-parameter-modifier#calling-a-method-with-an-out-argument
	- Variable Arguments https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/params
	- Implicit This https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/this	
	- Commenting
		- Param Doctag https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/param
		- Paramref Doctag https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/paramref
	- Guidelines
		- Naming https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-parameters
		- Design https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/parameter-design
- Return Type https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/return
- Calling Methods https://docs.microsoft.com/en-us/dotnet/csharp/methods#method-invocation
- Local Functions https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions
- Commenting
	- Returns Doctag https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/returns
- Guidelines
	- Naming https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-type-members#names-of-methods
	- Overloading https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/member-overloading
	
## Constructors
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors
- Defining a Constructor https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/instance-constructors
- Constructor Chaining https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/classes#constructor-initializers

## Inheritance
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/inheritance#background-what-is-inheritance
- Defining a Base Class https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/inheritance#designing-the-base-class-and-derived-classes
- Accessibility 
	- Protected https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
- Virtual Members
	- Virtual Keyword https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual
	- Override Keyword https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/override
	- Abstract Keyword https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract
	- Base Keyword https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/base

## Classes vs Structs
- Inheritance https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/value-types
- Instances https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/objects
- Using Structs https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-structs
- Equality https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/objects#object-identity-vs-value-equality
