# Naming Guidelines

Managed code follows a strict naming convention as discussed later. Following this standard will allow your code to more easily integrate with other libraries. Intellisense is also context aware and follows these rules.

In managed code there are two different casing conventions used.

## Camel Casing

Camel casing capitalizes the first letter of each word except the first word. 

```
numberOfStudents
payRate
isEnabled
```

## Pascal Casing

Pascal casing capitalizes the first letter of each word.

```
DetermineEmployeeType
GetEmployees
CalculatePayRate
```

## General Guidelines

- Avoid using all upper or lowercase letters in names or snake (underscore) casing.  It makes it harder to read.  Proper casing is easier on the eyes and, therefore, makes it easier to read and understand code.
- Underscores are allowed in names but their use is discouraged.  Underscores are often used in lieu of spaces in compound words.  Proper capitalization eliminates this need.  Do not use underscores at the beginning or end of names.
- Abbreviations can be used when a word is lengthy and the abbreviation is common.  For example abbreviating input/output as IO is reasonable.  Do not use abbreviations that are uncommon or may be confused with other words.   For two-letter abbreviations capitalize both letters.  For three or more letters use Pascal casing.
- C# is a case sensitive language but many languages are not.  Avoid using case to distinguish between names.  It can be hard to understand the difference between two names based strictly on casing.  
- Some languages allow reserved words to be used in certain contexts (including C#).  Do not do so.  Using a reserved word as a name can cause confusion.  
