# Solutions and Projects

## Projects

A project is a set of files and related resources that ultimately can be packaged into a single binary (i.e. an executable, 
library or DLL). Projects in VS have functionality that VS can call upon including: build, debug, publish and deploy.

The following are some of the many types of projects supported by VS.

- Console applications – Useful for creating utilities and simple UI applications.
- Windows applications – Useful for creating complex UIs and programs for non-experienced users.
- Class libraries – Used to create reusable pieces of code.
- Databases – Used to create databases, reports and other business intelligence solutions.
- Websites – Used to create websites.
- Mobile applications – Used to create mobile applications for Android and iOS

One of the features that makes VS so useful is that the available projects can be extended by third parties to include other types of applications.

Each project is stored in the file system under its own folder. Multiple projects cannot share the same folder. Within the project’s folder are the files that make up the project and any output from building the project.

As projects get bigger it often becomes useful to break them up into a series of separate projects. This simplifies development and helps support reuse. Unfortunately, this adds complexity as each project may be in a different state 
(ex. Building, debugging, etc.). To simplify the UI, all projects must be contained in a solution. 

## Solutions

A solution is a logical collection of projects. A solution, by itself, does nothing and produces nothing. It is simply a grouping of projects. As an example assume you have a project representing your web user interface. Another project represents the Windows user interface. A third project represents the shared business logic. A fourth project represents the data logic. To run this code you would need to compile each project in the correct order. If everything compiles you can then run the code. Rather than having to do this manually, Visual Studio uses a solution to wrap all these projects into a single, logical collection. To compile all the projects you would compile the solution. To run the projects you would run the solution.

Even in a single project environment, a solution is still present. Depending upon the settings in VS ```(Tools\Options -> Projects and Solutions -> General -> Always show solution)``` you may or may not see the solution node in Solution Explorer. On disk the solution is represented as a folder with a single .sln file in it. Projects contained within the solution appear as subfolders of the solution.
 
*Note: Folder structures are critical to VS. Do not every change the folder structure of a solution or any of its projects. Doing so will cause serious problems. When copying projects from one machine to another it is mandatory that you copy the entire solution folder and not just the projects and/or files you’re using.*

Projects within a solution are still independent of each other. Setting up dependencies between projects requires additional steps that depend upon the project type and language being used. 

## Solution Explorer

Solution Explorer is the core window for viewing and managing projects and your solution. When you are in Solution Explorer you should notice a top level node that simply contains a name. This is the solution. Any functionality exposed here impacts all the projects. VS limits you to one open solution at a time.

Under the solution is a node for each project. The project name should match what you enter when you created it. Any functionality performed on the project node only impacts that node.

Solution Explorer is a virtual view of the file system. A solution is the root directory where your solution file resides. You can get to this folder quickly by right clicking the solution node and selecting Open Folder in File Explorer. Each project has its own subfolder under the solution. You can quickly get to that folder by using the same command but on the project node.

### Startup Project

Because a solution may have any number of projects they are all considered equal. In the case of debugging, it is necessary to identify the project that should be started. This is known as the startup project. 

Whenever you start the debugger it needs to know which project(s) to run. The debugger can only run executable projects (i.e. console applications). By default it will run a single project known as the startup project. The startup project is generally the last project added to the solution that is executable.

The startup project is highlighted in Solution Explorer. To change the startup project (you cannot be debugging at the time) then right click the appropriate project and select ```Set as Startup Project```.

*Note: In advanced situations you can debug multiple executables at the same time by using the ```Set Startup Project``` command on the solution node and then selecting multiple projects. Remember that only executable projects can be marked as startup projects.*

### Working with Files

Projects are made up of files but not every file you open in VS may be part of a project. Unfortunately there is no way to tell if an open file is part of the project or not. Changing a file that is not part of a project will have no impact on the project itself.

To help avoid issues with files the following is strongly recommended.

1. Never open a file or project directly, always either double click the .SLN file in the file system or open Visual Studio and use the Start page to open the recent solution.
2. Do not work with the files or projects directly inside the file system. Always use Solution Explorer to open, edit, and rename them.
3. To open a file in a project double click it in Solution Explorer.
4. If you are unsure whether an open file is in the project then double click the file in Solution Explorer. If it is the correct file then you will return to the same editor window. If it is not then a new window will open.