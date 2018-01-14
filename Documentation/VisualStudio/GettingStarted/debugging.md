# Debugging

Debugging is the process of running your code in the debugger sandbox to identify issues. The debugger is a very special
process that has complete access to your code and can do things that normally are not allowed. As such the debugger can 
identify issues in your code that may not be visible outside the debugger. You should ALWAYS run your code with the 
debugger. Do not use the ```Start without Debugging``` option.

Running under the debugger will cause any runtime errors to pause your program and jump you to the line of code that is
causing the issue. This is incredibly useful for finding issues. However the debugger does modify your code’s behavior so
do not assume that the behavior you see in the debugger is the same behavior an end user would see.

## Controlling the Debugger

The debugger is a complicated program but you do have some control over its behavior. To start debugging you’ll use the 
Start or Debug command. This begins executing your startup project within the debugger. Until a debug command is reached
then your program will execute normally. If no debugger commands are executed then your program will run to completion just like it does during normal execution.

Where the debugger is useful is for stopping your program when events of interest occur such as a value changing, a certain line of code executing or an error being raised.

## Current Statement

When debugging there is always the concept of the current statement to execute. This is the statement that will execute when you run the debugger the next time. The IDE will indicate the current statement with a yellow arrow in the left margin. Remember, this indicates the next instruction to execute. It has not been executed yet.

The current statement indicator is only shown while paused in the debugger.

## Stepping Through Code

Stepping through code is the core debugging command you will use to execute your code. To understand stepping you need to understand how your source code is converted into executable code. While it depends upon the language and platform, ultimately each of your lines of code is converted to a corresponding set of instructions (note that we are not necessarily referring to assembly language instructions here). For example this code

```
string name = GetName();
```

would result in 2 instructions: the call to ```GetName``` and then the assignment to ```name```. This code results in 2 instructions when it is initially executed: assignment of a value to ```index``` and evaluation of the expression ```index < 10```.

```
for (int index = 0; index < 10; ++index)
```

A step is the execution of one of these instructions. Stepping is therefore the process of executing the instructions one by one. Depending upon the statement involved there may be more than one instruction to execute and therefore a step may not move from a (code) line since there are more instructions to execute. 

In a typical debug scenario you will step through your code line by line. After each step you will evaluate the execution to verify the code behaved properly, variables have their correct values and that what you expected to occur did happen. Assuming everything works correctly then you will step again to execute the next line and then repeat the process.

There are several different step commands available.

### Step Into

This command executes the next instruction and stops. If the next instruction is one the same (code) line then the current statement will not appear to change. 

If the next instruction is a function call then the function's entry code is executed and then the debugger will stop at the first line inside the function. This is most useful when you need to verify the behavior of a function you have written.

*Note: The debugger does not distinguish (in general) between your code and code provided to you. If you step into code that you do not own the source code for then the debugger will display a generic window and/or prompt to locate the source code.*

### Step Over

This command behaves similar to ```Step Into``` except it will execute all the instructions a single (code) line. This is the command that you will use most often. 
If there are any function calls or expressions on the line then it executes them automatically. Function calls will not be stepped into but will still execute.

```Step over``` allows you to quickly step to the line(s) you care about without having to step through every instruction. Remember however that it will execute any function calls automatically and not step into them. If you need to step into a function call to check its behavior then do not use this command. 

### Step Out

This command is similar to ```Step Over``` except it steps over the remainder of the current function. All the instructions up to and including the function epilogue code is executed and then the function returns. At this point the debugger will stop again.

This command is most useful for quickly getting out of a function you didn't mean to step into. 

## Breakpoints

While executing code it is often useful to stop your program so you can view the state of variables and other information. While you can step through code, as programs get larger it becomes inefficient to step through the entire program. This is where breakpoints are used. A breakpoint is like a stop sign for the debugger. When placed on a line of code (or sometimes a subset of a line) it indicates to the debugger to pause execution. A breakpoint effectively adds a break instruction (not to be confused with the break statement in most languages) in the middle of your code. If you imagine the debugger as simply reading each instruction and executing it then a break instruction tells the debugger to pause execution and give you control back. When the break instruction is executed it is said that the breakpoint "has been hit".

To set a breakpoint in VS by either clicking in the left margin or putting the caret on a line and pressing F9. A red stop sign should be displayed. Once placed a breakpoint remains in place until you remove it (by repeating the process above). A breakpoint can only be placed on line that contain instructions. Attempting to place a breakpoint on a non-executable line will cause the breakpoint to be moved to the next executable line when debugging starts.

By placing a breakpoint on a line where you want to start debugging you can allow the program to run normally until that line is executed. When the breakpoint is hit the debugger will pause your program. At this point you can view the state of your code.

You may have any number of breakpoints in your code at any one time. Each time a breakpoint is hit the debugger will stop. You can remove breakpoints when you no longer need them. In a typical debugging session you may have breakpoints in several different areas of your code to allow you to monitor several different sections of code. Breakpoints only impact the code while running in the debugger. Your code is not modified and breakpoints are not part of the project settings. 

*Note: A popular debugging technique outside of Visual Studio is using logging statements (known as "printf debugg"). DO NOT do this. Use breakpoints in combination with stepping to debug code. It is more efficient and does not litter code with debugging information.*

### Breakpoints and Stepping

Breakpoints and stepping are related and will almost always be used together. You will generally set a breakpoint in the area of the code you want to step through. When the breakpoint is hit you will then use stepping to execute the code. Depending upon how the debugging goes you may continue execution, fix the code and debug again or remove the breakpoint and continue debugging elsewhere.

Under the hood stepping involves setting temporary breakpoints by the debugger. The debugger sees stepping just like it sees breakpoints. The difference is that the debugger will automatically clean up the breakpoints as you step.

## Advanced Debugging

Visual Studio has many advanced debugging features. A full discussion is beyond the scope of this document but several features are useful for daily debugging and warrant some discussion.

### Changing the Next Statement

As mentioned earlier, the current statement represents the next statement to execute. In some situations you may want to skip over code or repeat code. Without changing the code this cannot be done directly but while paused in the debugger you can change the current statement indicator.

To change which statement will execute next when the debugger resumes, click the current statement indicator in the left margin and drag it up or down to the statement you want to be the new current statement. There are many restrictions on the statements you can apply it to including:

- Must be in the same function
- Cannot move into or out of some scopes

Attempting to move the indicator to an invalid line results in either an error or it simply being ignored.

To skip a section of code, move the current statement indicator to the line after the section to skip. To repeat a section of code, move the current statement indicator to the line where you want to start the repeated execution.

### Edit and Continue

Normally, while debugging your code, you cannot edit it. To edit code you would need to stop the debugger. In many cases this is fine but if it takes a while to set up a debugging scenario then this can be inefficient because you have to repeat the process.

VS supports the concept of edit and continue (EnC) for some project types. EnC allows you to make changes to your code while paused in the debugger. When the debugger
continues the changes are compiled and applied to the debugging code. The debugger will prompt you whether you want to use this feature or stop, recompile and then run your program again. 

There are many cases where EnC cannot be used including major changes to the code, altering of function signatures and other scenarios. If EnC is not allowed the debugger will report the error.
