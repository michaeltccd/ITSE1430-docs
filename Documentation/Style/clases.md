# Classes and Structures

## Naming

- Classes should use Pascal casing.
- Classes represent entities so they should be noun or noun phrases.  
- Do not add prefixes to a class name such as ```C-```, ```I-```, or ```T-```.  This is common in legacy code.
- Do not add suffixes to a class name such as ```-Class``` or ```-Type```.
- For derived classes use a compound word where the base class is the suffix.  For example an array class might be called ```Array```.  A derived class that holds strings might be called ```StringArray```.

## Members

- Members of a type should be directly related to the type.

### Methods

- Method names should use Pascal casing.
- Methods represent actions and should be verbs or adverbs.
- Publicly accessible methods should be properly document using doctags.
- Methods should be used to perform functions that may have side effects or may be non-deterministic.

### Properties

- Property names should use Pascal casing.
- Properties represent values and should be nouns.
- Publicly accessible properties should be properly document using doctags.
- Consider using mixed accessbility if a property should be public for reading but not for writing.
- Properties should execute quickly, without errors, without side effects and deterministically.

### Fields
- Field names should use camel casing.
- Field names may begin with ```m_``` or ```_``` although some people object to this.
- Fields should always be private. Use Properties if access is needed outside the class.

