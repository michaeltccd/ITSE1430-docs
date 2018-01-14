# Projects and Files

## File Headers

Every source file should contain a file header at the top.  Many companies have policies about what must appear in the header.  The header is used to identify the owner of the code and perhaps its purpose and history.

Here is a common file header that might be used in a company or by anyone who publishes the code online.

```
/*
 * Copyright © 2007 My Company
 * All Rights Reserved
 * 
 * This file provides some common utilities needed by the program.
 */
```

For class assignments the following header would be more appropriate.

```/*
 * Student: Bill Murphy
 * Class: ITSE 1430
 * Lab: 1
 * Date: 17 Nov 2008
 * 
 * This file provides some common utilities needed by the program.
 */
```
## Guidelines

- Every type goes in its own file. Visual Studio will help to keep this consistent. The file name follows the type name.
- The folder structure in the project determines the namespace convention. In general keep related files together in the same folder and use consistent naming. The more nested a folder structure, the more specialized it should be.
- The project name is the root namespace for the code. Use a descriptive name. For assignments Lab1, Lab2, etc is sufficient.
