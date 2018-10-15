# Contact Manager (ITSE 1430)
## Version 1.0

In this lab you will create a Windows Forms application to manage contacts for someone. In this application we will only track their name and email address. 

*Note: This program will not actually send any emails. We are going to simulate that functionality.*

## Skills Needed

- C#
	- Abstract Classes
    - Extension Methods
    - Generic Types
    - Interfaces
    - Lists
- Windows Forms
    - Child Forms
    - Layouts
    - List Controls
    - Validation

## Story 1 - Set Up Main Window

Set up the main window.

### Description

Create a new Windows Forms project to hold your code. The project should be named such that it is clear it is the UI portion of the solution (e.g. `ContactManager.UI`).

Ensure the main form is reasonably sized, is appropriately named and has the appropriate title.

Add a main menu to the form. The main menu should have the following functionality as in past labs.

- `File \ Exit` that exits the program.
- `Help \ About` that displays an about box with your basic information. The hotkey is `F1`

### Notes

1. ENSURE event handlers have reasonable names.
1. DO use descriptive control names for fields you will be interacting with in code. Other controls can use their default names.
1. ENSURE the form title is descritive.

### Acceptance Criteria

1. The application compiles cleanly without warnings or errors.
1. The application runs.
1. The exit functionality works.
1. The help functionality works.

## Story 2 - Add Support for Managing Contacts

Set up the business layer for the application.

### Description

Create a new `Class Library` project to manage contacts. This project represents the business layer of the application and should be named accordingly. Add a reference to the class library to the main UI project.

Create an interface to represent the messaging service. This interface abstracts away how messages are sent from how contacts determine who to send messages to. The interface will need the following members.

1. A method accepting the message to send. The message will need to include the email address, subject and message.

Create an interface to represent a contact item. The interface will need the following members.

1. A property that represents the name of the contact.
1. A method that can be used to send a message to the contact. The method should accept the subject and message to be sent and the messaging service to use.

### Notes

1. DO NOT reference Windows Forms or `Console` in the business project. It must remain UI agnostic.
1. CONSIDER using a base name for the business project and a more specialized name for the UI project. (e.g. `ContactManager` and `ContactManager.UUI`) This will reduce the number of 
`using` statements you'll need.
1. DO start interface names with `I`.
1. DO drop the `I` on base classes used to implement base interface functionality.

### Acceptance Criteria

1. The application compiles cleanly without warnings or errors.
1. The application runs.
1. The new type(s) are properly documented.

## Story 3 - Add Support for Adding a Contact

Add support for a contact representing a single person. 

### Description

A new type will be needed to store information for a single contact. The type should derive from the contact interface created earlier. In addition to the interface members a person contact will need a property representing the person's email address. The send method will need to send the message along with the person's email address to the messaging service.

In the main form add a new menu to support working with contacts. Add an option to add a new person contact. Add an appropriate hotkey (e.g. `Insert`). When clicked display a form to collect the contact information.

1. The form should be appropriately titled and sized.
1. The form should allow for entering the contact name and email address. Both should be required.
1. Email addresses should be in the valid format but do not have to be valid. Refer to the Notes section for more information.
1. The form should allow for saving or cancelling the request.
1. If the user clicks save the form should ensure the contact is vaild before closing. Display an errors as appriopriate.
1. If the user clicks the cancel option then no validation is done and the form closes.

*Note: Allow the user to navigate away from invalid controls. Just do not allow saving of invalid data.*

### Notes

1. ENSURE contact information is stored in the business project and not the UI. This allows it to be reused in other UI projects.
1. INCLUDE the interface name in implementation classes. It is generally done as a suffix. (e.g. `PersonContact` implements `IContact`)
1. ENSURE each form is appropriately titled.
1. REMOVE the minimize and maximize buttons if a form does not suppor them. Optionally remove the entire control box for child forms.
1. ENSURE the form's layout flows top to bottom and left to right. This includes using the keyboard to navigate.
1. ENSURE form controls resize properly on forms that support resizing. In cases where resizing is not useful then ensure the form does not resize.
1. ENSURE cancellation buttons do not trigger any validation and do not modify existing data.
1. ENSURE affirmative buttons handle validation before performing their action.
1. ENSURE that form buttons set `DialogResult` to an appropriate value before closing the form.

### Acceptance Criteria

1. Adding a contact is available in menu.
1. Menu hotkey works.
1. Clicking menu displays appropriate form. Form layout is clean and usable.
1. Form can be cancelled without validation.
1. Attempting to save with data missing reports the correct errors.
1. Clicking save with valid data works.
1. Types and (appropriate) fields are properly named.

## Story 4 - Display the Contacts in the Main Window

The main form will need to track the contacts that have been added. Each time a contact is added the main window should update to show the new contact. 

### Description

Create a class to manage the list of contacts. The class should allow adding, removing and retrieving contacts. The class should ensure a contact is valid before adding or editing it. A contact's name must be unique in the list.

The main form should have a field for the contact list. Whenever the main form manipulates a contact it should update the list of contacts as needed. 

The main form should display a list of contacts in the main window. The list should show the contact name. The contact list will be one of two views in the main window so use a split container to separate them.

### Notes

1. CONSIDER using `IValidatableObject` on the contact to validate it. Remember that each contact will validate differently so use virtual members appropriately.

### Acceptance Criteria

1. Adding a new contact adds them to the list being displayed.
1. Attempting to add an invalid contact fails. The user receives a message and the form appears again with the previous data.

## Story 5 - Add Support for Sending Emails

Add support for collecting information and sending the emails.

### Description

Add a menu item to the contacts menu to send a message. When clicked get the currently selected contact (if any). If there is a contact then display a form to collect the subject and message to send to the contact. 

1. The form should be appropriately titled and sized.
1. The form should show the contact name but it should not be editable.
1. The form should allow for entering the subject and message. Subject is required but message is not.
1. The form should allow for sending or cancelling the request.
1. If the user clicks send the form should ensure the fields are vaild before closing. Display an errors as appriopriate.
1. If the user clicks the cancel option then no validation is done and the form closes.

*Note: Allow the user to navigate away from invalid controls. Just do not allow saving of invalid data.*

### Acceptance Criteria

1. Clicking the menu item shows the send message form if there is a selected contact.
1. Clicking the menu item does nothing if there is no selected contact.
1. The form shows the contact's name and email. They are not editable.
1. The form allows for entering subject and message. Appropriate validation is done.
1. The user can move between fields even with validation errors.

## Story 6 - Implement the Messaging Service

Create an implementation of the messaging service defined earlier. The messaging service will update the main window with the message that was sent.

### Description

Update the main form to show a view in the main window where messages will be shown. Any control can be used (e.g. TextBox, ListBox, ListView) provided the user cannot edit the contents and that it shows the email address, subject and message. The UI should be scrollable and resize with the form so the information can be more easily seen.

Implement the messaging service defined earlier to send messages to the UI. Since the implementation is specific to the UI it makes sense to put the implementation in the UI project. When a message is sent it should appear in the UI automatically. Ensure that previous messages remain as well.

Update the send functionality in the main window to send the information that was collected in the send message form to the service.

### Acceptance Criteria

1. Main window shows a list of messages that have been sent including email address, subject and message.
1. Clicking send in the send message form causes the correct information to appear in the UI.

## Story 7 - Add Support for Editing Contacts

Add support for editing an existing contact.

### Description

Update the add contact form to support editing a contact as well. When the form is loaded and a contact is provided then show the initial contact information. If the user clicks save then update the existing contact otherwise ignore the changes.

Add a new menu item to the contacts menu to allow editing. Get the currently selected contact, if any, and display the form for editing. If there is no selected contact then do nothing.

Update the contact list to allow double clicking a contact. If a contact is double clicked then treat it like the menu and display the edit form.

### Acceptance Criteria

1. Using the menu to edit a selected contact shows the form appropriate populated.
1. Clicking save in the form updates the contact information.
1. Clicking cancel in the form does not update the contact information.
1. Double clicking a contact in the contact list edits the contact.
1. Trying to edit a contact when none is selected does nothing.
1. Editing a contact updates the contact list appropriately.

## Story 8 - Add Support for Removing Contacts

Add support for deleting a contact.

### Description

Add a menu item to allow deleting a contact. When clicked display a confirmation message with the contact's name. If the user confirms then remove the contact. Otherwise do nothing.

Allow the user to press the `DEL` key to delete a contact as well.

### Acceptance Criteria

1. Clicking delete menu item on selected contact displays a confirmation.
1. Confirming the delete prompt removes the contact from the list and UI.
1. Declining the delete prmopt leaves the user.
1. Using `DEL` key triggers deletion prompt.

## Hints

### Naming

- Types represent entities and are nouns. (e.g. `Contact`)
- Types are singular unless they represent a set of items (e.g. `Contact` not `Contacts`)
- Properties are data and use nouns.
- Methods are actions and use verbs.
- Fields are data and use nouns. Fields traditionally start with an underscore to separate them from variables. (e.g. `_name` instead of `name`)

### Members

- Members are implicitly associated with the type and therefore do not need to include it (e.g. `Rectangle` class with an `AreaOfRectangle` method is not descriptive, use `Area` instead)
- Public members and types are Pascal cased.
- Private members are generally Pascal cased except for fields which use camel casing.
- Parameters are camel cased.
- Properties should have no side effects and be deterministic.
- If a method starts with `Get` or `Set` then it likely needs to be a property, unless it is non-deterministic.

### Validating an Email Address

To help with validating email addresses use the following code. It is wrapped in a function but you can use it however you need.

```csharp
bool IsValidEmail ( string source )
{
   try
   {                
      new System.Net.Mail.MailAddress(source);
      return true;
   } catch
   { };

   return false;
}
```

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the Github repository.
