# Navigating the IDE

VS has a lot of UI elements. It is important to understand some basic terminology.

- Menu – The menu at the top of the screen providing access to the core functionality.
- Editor Window – The tabbed window in the middle of the main window. All open files are represented here. This is also the
window where editing files will occur.
- Tool Windows – The various windows along the top, sides and bottom of the main window. They provide access to functionality
outside the main editor window.
- Toolbars – The bars across the top of the main window that provide quick access to common commands.
- Dialogs – Windows that appear in response to certain events. These windows generally alert you to some immediate action and
must be closed before you may continue.
- Notifications – The area in the top right of the menu bar where notifications will appear related to updates.

VS is highly customizable. You can adjust VS to fit your particular coding style. Some examples of what you can do.

- Toolbars
	- Rearrange, show and hide each toolbar.
	- Create new toolbars and customize the buttons available on them.
- Tool Windows
	- Show or hide tool windows.
	- Dock to any side of the main window.
	- Detach and float anywhere on the screen.
	- Auto-hide (unpin) so the window appears only when it has focus.
	- Combine tool windows into tabbed windows to allow grouping.
- Editor Window
	- Control order of tabs.
	- Pin tabs so they are separate from non-pinned tabs.
	- Detach and float the tab (or set of tabs) in their own window.

VS supports two different visual layouts: design and debug. In design mode the layout of the windows, available toolbars 
and other features of the UI are optimized for writing code. When debugging your code the layout changes to provide access
to UI elements that are relevant for debugging. In many cases you can adjust the layout to fit your needs for debugging. 
When debugging stops VS will switch back to the design layout.

## General Windows

### Editor Window

The Editor window is where you will be writing code. Some useful information about this window.

1. Each tab represents a different file. 
2. The files may or may not be part of your project so pay careful attention to the files you are editing. 
3. You can quickly go to the directory containing the current document by right clicking the tab and selecting 
Open Containing Folder. 
4. If the contents of a document have been changed but not saved then the tab puts an indicator in the title. Documents 
are automatically saved 
5. All documents in the project are automatically saved when you build.

### Output Window

The Output window is where the IDE puts most messages of importance including build messages, debug messages and general
errors.  The window separates the messages by category so use the dropdown list in the window to select the category of 
messages you want to see. 

Perhaps the most useful aspect of this window is during builds when errors occur. Each error will generate a well-defined
error message. The error message can be double clicked to jump to the appropriate location in your source code. More 
importantly, errors are shown in the order they are generated so focus on resolving the errors appearing earlier in the
window to avoid wasting time on later errors that are caused by earlier ones.

### Solution Explorer

This is the core window for managing your [solution](solutions.md).

## Design Windows

These windows are only useful during design but may be open during [debugging](debugging.md).

### Error LIst Window

The ```Error List``` window appears when you do a build and errors occur. Unlike the Output window errors are shown in an 
undefined order. Double clicking a row in the window will jump to the appropriate location in your source code. 

### Task List Window

The ```Task List`` window contains a list of tasks that you need to completed based upon the currently open documents. This includes certain tasks defined in your source code (using specially formatted comments) but can also include errors from compilation.

## Debug Windows

These windows are only available during [debugging](debugging.md). Most of the windows only show information while paused in the debugger.

### Autos Window

The ```Autos``` window will show you the relevant variables in your code based upon what is currently being executed. This will generally include the variables being used before and after the current instruction. 

Information displayed includes the identifier, type and current value. Values in red indicate the value has been changed since the window was last refreshed. In most cases you can double click the value and change it (within normal semantic rules). This is most useful if you want to alter or test a different value then what the variable currently has.

### This Window

This window is identical to the ```Autos``` window except it shows you all the members of the current object (if any).

### Watch Window

This window is identical to the ```Autos``` window except it shows you only the values you explicitly add to it. You can add variables to watch using the ```Add Watch``` command. Note that not all values may be scope.
