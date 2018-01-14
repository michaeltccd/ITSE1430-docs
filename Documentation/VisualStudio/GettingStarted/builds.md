# Building Projects

Building your code is the process of converting it from source code to runnable code. This requires the compiler to run. Any
changes to any files will be saved prior to the build running. If you are currently debugging then the debugger must be 
stopped as well.

You can build a single file or project but you’ll almost always choose Build Solution from the menu or toolbar. This command
will rebuild any changes that have occurred across the entire solution. Errors will appear in the Error List and Output windows. If any errors occur 
then the build will fail and no binary will be created.

*Note: When building a project it is possible for the build to fail because of a locked file. This most often happens when a solution is stored on a network or removable drive. If a file is locked then a compiler error occurs. In this case the only solution is to restart VS.*

## Build vs Rebuild

There are two similar commands: Build and Rebuild. Build only builds files and projects that have changed. As such it is the quickest option with the least amount of IO. This is the default choice you should make. 

Rebuild will recompile everything whether it has changed or not. This is useful in cases where it appears something has gotten corrupted or you made significant changes to the project structure or contents. This is basically a test build to
ensure everything compiles. It should be used rarely.

## Build vs Debug

Building is the process of converting your source code to binary code. Debugging is the process of running your code in the debugger. Build must occur before debug. If the build fails for any reason then debugging does not make sense. Since you 
must build before you debug the IDE will automatically build your code if it is out of date when you select to debug. This is a time saver but can introduce unexpected issues if you are not careful.

If the build fails then VS will display a message asking if you want to continue anyway. The correct answer is ALWAYS no. However there is an option to continue anyway in which case it will run the previously built version, if any. Even more 
frustrating though is the option to remember your selection. If you select this box then you will no longer get the dialog if the build fails and it will always debug the previous version. This can lead to confusion as the code does not match what
you’re debugging.

*Note: It is strongly recommended that you always build explicitly first and then debug your code until you understand the process completely. There is no difference in speed for this and avoids you selecting the wrong option.*
