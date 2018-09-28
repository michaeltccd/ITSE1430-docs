# Character Creator (ITSE 1430)
## Version 1.1

In this lab you will create a program to create a character for a [Role Playing Game](https://en.wikipedia.org/wiki/Role-playing_game) (RPG). This will be a Windows Form application in which a user may create a character for their favorite game.

## Skills Needed

- C#
   - Classes
   - Class Members: property, method, field, constructor
   - Inheritance
   - Events
- Windows Forms
   - Creating Forms
   - Controls: Button, ComboBox, Label, ListBox, Menu, TextBox
   - Control Layout
   - MessageBox
   - Validation

## Story 1 - Set Up Main Window

Create a new Windows Form project to hold your code.

- Open Visual Studio.
- Create a new project in a new solution.
    - Select the `Windows Form Application (.NET Framework)` project template.
    - Ensure the `.NET Framework 4.6.1` option is set.
    - Set the project name to `CharacterCreator.Winforms`.
    - Ensure the location is under your `Labs` folder in your local Git repository.
    - Create the project.

For the main window do the following.

- Rename the main window to MainForm.
- Set the following attributes.
    - Title should be `Character Creator`.
    - Default size should be 300 x 450.
    - Minimum size should be 260 x 420.
    - Should open centered on the screen.
- Add a menu for navigating the application.    

### Acceptance Criteria

1. Solution opens properly in Visual Studio and loads all projects.
1. Project is properly named in repository.
1. Main window displays properly.
1. Main window cannot be resized smaller than the given value.

## Story 2 - Support Exiting the Program

Implement a command to exit the program.

Create a new menu item for `File\Exit` with appropriate accelerator keys. The command should be assigned the shortcut key of `Alt+F4`.

When the command is executed close the main window and terminate the application.

### Acceptance Criteria

1. Menu option is available to exit program.
1. Selecting option closes program.

## Story 3 - Support Help

Implement the command to show help information.

Create a new menu item for `Help\About` with appropriate accelerator keys. The command should be assigned the shortcut key of `F`.    

When the command is executed show an About form centered in the parent. The form should contain your name, course and name of lab (e.g. Character Creator). The form should provide a button to close it.

### Acceptance Criteria

1. Menu option is available to show help.
1. Selecting option shows About form.
1. Form shows correct data.
1. Form can be closed using button.

## Story 4 - Add Support for a Character

Add support for collecting character information.

Create the new project.
- In `Solution Explorer` select `New Project`.
- Select the `Class Library (.NET Framework)` project template.
- Ensure the `.NET Framework 4.6.1` option is set.
- Set the project name to `CharacterCreator`.
- Create the project.

This project will be the business layer for the application. It will house any logic that is not tied to a UI. The UI project will rely on this.

- In the UI project right click and select `Add Reference` to bring up the `References` dialog.
- Go to the `Projects` category.
- Check the box next to the business layer project.
- Click `OK`.

*Note: Do not add any UI elements to this project.*

Rename the auto-generated class to `Character` or delete it and create a new class file. The type will contain the data needed to "define" a character. 

The following attributes define what a character is.

- Name: (Required) The name of the character.
- Profession: (Required) The profession of the character. The available professions are: `Fighter`, `Hunter`, `Priest`, `Rogue` and `Wizard`. 
- Race: (Required) The race of the character. The available races are: `Dwarf`, `Elf`, `Gnome`, `Half Elf` and `Human`.
- Attributes: (Required) A set of numeric attributes that define a character. The attributes are: `Strength`, `Intelligence`, `Agility`, `Constitution` and `Charisma`. The values can be between 1 and 100.
- Description: The optional, biographic details of the character.

Ensure that the class is properly documented and follows the general guidelines outlined in class.

*Note: If you already have a favorite RPG then you may optionally choose to use the appropriate profession/race/attributes/range from the RPG. However you must provide multiple options for profession and race, you must have 5 attributes and they must define a lower and upper bound. Any variant in ranges should be documented in the UI.*

## Story 4 - Support Adding a New Character 

Allow the user to create a new character. 

Create a new menu item for `Character\New` with appropriate accelerator keys. The command should be assigned the shortcut key of `Ctrl+N`.

When the command is executed show a form to collect the character information. The form will have the following attributes.
    - The title will be `Create New Character`.
    - The form will be centered on the parent.
    - The form will not be resizable and will appropriately fit the contents.
    - The form will not have an icon, minimize or maximize buttons.
    - When validating the user should be able to navigate to other controls but an error should be shown next to the invalid fields. 
    - Ensure all controls and labels are lined up properly.  

The form will display the fields from the `Character` class defined earlier. For each field.
- Include an appropriate label.
- Use the appropriate control. For profession/race use a `ComboBox`. 
- The field should be validated.
- The fields should tab in a logical order.
- If a field has an invalid value then display an error next to it.

Heroes are not average people so set each attribute to an initial value of `50`. *Note: If you are using your own RPG then you may use substitute profession/race values.*

The combo boxes should not allow freeform text. Only the pre-defined options should be available.

The form will have a `Save` button that will save the character. If there is any validation issues then prevent the form from closing. 

The form will return the newly created character. Create an instance of the `Character` class to store the character information and provide it back to the main form.

The form will have a `Cancel` button that will cancel the creation. No validation is done and no changes should be made.

### Acceptance Criteria

1. When selected the form is shown.
1. As validation errors occur they are shown to the user.
1. User cannot save if there are validation errors.
1. Saving saves the character.
1. Cancel closes the form without validation and without making any changes.

## Story 5 - Display Roster

Display the roster of characters that have been defined in the main window.

Allow the creation of a roster of characters by using an array to store the characters in the main form. Each time a new character is created it should be added to the array. Set the array size to a value of `100` so it is unlikely the array will fill. 

*Note: You do not have to code for the scenario where the array is full.*

Display the roster in the main form. Use a `ListBox` that displays the character's name. Ensure that the items in the list box are associated with the character data so it can be used in a later story.

The control should resize as the form is resized to allow for a user to see the entire roster, if necessary.

### Acceptance Criteria

1. List of characters are shown in the main form.
1. If a character is added then it appears in the main form.
1. The list resizes as the main form is resized.

## Story 6 - Support Editing a Character

Allow the user to edit an existing character.

Create a new menu item for `Character\Edit` with appropriate accelerator keys. The command should be assigned the shortcut key of `Ctrl+O`.

When the command is selected get the currently selected character from the roster. If no character is selected then do nothing. 

If a character is selected then show show the character form again with the selected character information already populated. The form will behave the same as when creating a new character with the following exceptions.

- Change the form title to `Edit Character`.
- When the form is loaded the data should be pre-populated based upon the currently selected character's values.
- When saving the character the existing character instance should be updated instead.

The roster should be refreshed after saving to reflect any changes in the name.

### Acceptance Criteria

1. Selecting a character in the roster and then excuting the command properly displays the character in the form.
1. Saving the character updates the existing character.
1. Roster is refreshed after save.
1. Cancelling the edit does not change data.

## Story 7 - Support Deleting a Character

Allow the user to delete an existing character.

Create a new menu item for `Character\Delete` with appropriate accelerator keys. The command should be assigned the shortcut key of `Del`.

When the command is selected get the currently selected character from the roster. If no character is selected then do nothing. 

If a character is selected then display a confirmation message that asks if the user wants to delete the given character. Include the character name in the message.

The roster should be refreshed after saving to reflect any changes in the name.

### Acceptance Criteria

1. Selecting a character in the roster and then excuting the command prompts for confirmation with the character's name.
1. Confirming the message deletes the character and refreshes the list.
1. Cancelling the confirmation does not change anything.

## Hints

### Naming Conventions

- DO NOT worry about the field names for controls you do not programmatically use (e.g. menu items). The defaults are fine.
- USE descriptive field names for controls you will work with in code (e.g. text boxes).
- USE descriptive method names for event handlers (e.g. `OnFileExit` instead of `menuItem1_Clicked`).
- USE nouns for variable and parameter names.
- USE verbs for method names.
- DO ensure your spelling for identifiers.
- DO use camel casing for variables, parameters and fields.
- DO use Pascal casing for types and public members.

### Working with ComboBox

The Windows Forms [ComboBox](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.combobox?view=netframework-4.7.2) can be used to give the user a drop-down list of items to choose from. By default the user can either select an item from the list or enter a value. To only allow the user to select from a list use the [DropDownStyle](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.combobox.dropdownstyle?view=netframework-4.7.2) property and set it to `DropDownStyle.DropDownList`.

All the things you see in the `ComboBox` are stored in the [Items](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.combobox.items?view=netframework-4.7.2#System_Windows_Forms_ComboBox_Items) property. This is a collection of `Object` instances. Thus it can store anything you want. For each item it will call the `ToString` method on the object to get the text to display. You may "bind" data to it a couple of different ways.

The first approach is to use strong types (e.g. your business objects). Store your data in a array as you might normally do. Assign the array to the control so it will render the elements using the `Items` property. The [AddRange](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.combobox.objectcollection.addrange?view=netframework-4.7.2) method accepts an array and assigns each of the elements to the control. Alternatively you could use a foreach to iterate through the array and add each item to the list. With the data assigned it will then render by calling the `ToString` method. Use the [DisplayMember](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listcontrol.displaymember?view=netframework-4.7.2#System_Windows_Forms_ListControl_DisplayMember) property to specify the name of the property that contains the value you want to use as the text instead. 

```csharp
class MyItem
{
   public int Id { get; set; }
   public string Name { get; set; }
}

//Later in the UI
private void LoadItems ( MyItem[] items )
{
    combobox1.DisplayMember = "Name";
    combobox1.Items.AddRange(items);
}
```

The other approach is to use the designer. In the designer you can use the smart tag on the control (or use the `Properties` window and go to the `Items` property). In either case you get a textbox that allows you to enter text. Each line becomes a value in the control. This approach is good when you just want to display text but it cannot be used for more complex scenarios.

To get or set the selected value in the control you have a series of properties that you can use.

- [SelectedItem](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.combobox.selecteditem?view=netframework-4.7.2#System_Windows_Forms_ComboBox_SelectedItem) This is the element in the `Items` collection that was selected.
- [SelectedText](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.combobox.selectedtext?view=netframework-4.7.2#System_Windows_Forms_ComboBox_SelectedText) This is the text of the selected item but it can be `null` even when something is selected.
- [SelectedValue](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listcontrol.selectedvalue?view=netframework-4.7.2#System_Windows_Forms_ListControl_SelectedValue) This is the selected value but won't be set unless you also set [ValueMember](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listcontrol.valuemember?view=netframework-4.7.2#System_Windows_Forms_ListControl_ValueMember).

If you are using the strongly typed approach then use `SelectedItem` and cast to the appropriate type.

```csharp
var item = combobox1.SelectedItem as MyItem;
if (item != null)
   ...
```

If you are using the string approach then use the `Text` property that is already available on all controls.

### Working with ListBox

A [ListBox](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listbox?view=netframework-4.7.2) is useful for working with lists of items. While you can use simple strings it is really designed for objects. Like the `ComboBox` it sees everything as `Object`. Use the `DisplayMember` property to determine which property on your class to display. The `SelectedItem` property can be used to get the selected item. Remember to typecast it as needed.

The `ListBox` can support multiple selection as well. This is controlled by the [SelectionMode](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listbox.selectionmode?view=netframework-4.7.2) property. If using multi-select then use the [SelectedItems](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listbox.selecteditems?view=netframework-4.7.2#System_Windows_Forms_ListBox_SelectedItems) property instead of `SelectedItem` to get the list of items.


## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the Github repository.