# Event Planner (ITSE 1430)

## Version 1.0

In this lab you will create an MVC application to track events. Events can either be public or for the current user.

## Skills Needed

- C# 
  - Attributes
  - Generic Types
  - Interfaces
  - Lists
- ASP.NET
  - Controllers
  - Models
  - Routes
  - Views

## Story 1 - Set Up the Project

Set up the ASP.NET project.

### Description

Set up the ASP.NET project in preparation for later stories.

1. Create a new `ASP.NET Web Application (NET Framework)` project called `EventPlanner.Mvc`. 
1. Add the provided `EventPlanner` project to the solution. 
1. Add a reference to the `EventPlanner` project to the new ASP.NET project.

Clean up the existing web project.

1. Remove the `App_Data` folder.
1. Remove the `Contact.cshtml` view AND the corresponding action from the `HomeController`.
   
Update the About page (`About.cshtml`).

1. Remove existing `h2`, `h3` and `p` elements.
1. Add `h2` containing your name.
1. Add `h3` containing the class name.
1. In `HomeController.About` remove the `ViewBag.Message` code.   

Update the Layout page (`_Layout.cshtml`).

1. Remove the link to the Contact page.
1. Remove the `Application Name` link.
1. Change the `title` element to say `Event Planner - @ViewBag.Title`.
1. Change the `footer` element to say `Event Planner` instead of `My ASP.NET Application`.

### Notes

1. ENSURE the view(s) render properly in the browser.

### Acceptance Criteria

1. The layout page provides the options to go home and to the about page.
1. The layout page does not have an option to go to the contact page.
1. The title and footer on the layout page are correct.
1. The About page shows your information.

## Story 2 - Set Up Data Store

Set up a data store to hold the events for the site.

### Description

To work with the events the `IEventDatabase` is needed. This interface is already defined in the business layer. 

There will be no database component for this lab so the database needs to be a "singleton". 

1. Add a new, static class to the web project to hold the database (e.g. `DatabaseFactory`). The `App_Start` folder is a good place for this.
1. Create a private, static field to hold the `IEventDatabase` instance.
1. Expose a property or method from the class to provide access to the instance. DO NOT expose the field.
1. Ensure the database is initialized with a couple of public and private events.

Define a model to be used in the UI. This helps isolate business logic from view logic.

1. Create a new "model" class for the event under the `Models` folder. 
1. Create auto properties to back each of the public properties on the business object.
1. Add validation to the model that mimics the business object.
   1. Name is required and cannot be empty.
   1. End date must be greater than or equal to start date.
1. Fix the display names for the start and end dates to include spaces.
   1. Add the [DisplayAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayattribute?view=netframework-4.7.2) to the properties.

### Notes

1. The simplest approach to creating a singleton is to define a [static constructor](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors) that creates an instance of the class and then initializes it before assigning it to the field.
1. An alternative approach is to create a method that returns the initialized instance. When it is first called it sees the field set to null and initializes it. Subsequent calls use the initial version.
1. Yet another approach is to use [Lazy](https://docs.microsoft.com/en-us/dotnet/api/system.lazy-1?view=netframework-4.7.2).
1. The database MUST persist across web requests otherwise data will be lost as you navigate pages. 
1. The database will be reset each time the web application is run.

### Acceptance Criteria

1. Code compiles.
1. Events are persisted for the life of the application.

## Story 3 - Show My Events

The user will be able to view their events.

### Description

The user can view their events by using a link on the main page. The events should be ordered by most recent start date. Events that have passed should not be shown.

1. Add a new `EventController` controller to the web project. This controller will be responsible for managing events.
1. Add a new action called `My`.
   1. Get the private events from the database.
   1. Filter out the unneeded items.
   1. Convert to the model type.
   1. Pass the models to the view.

Define the UI for my events.

1. Right click the action and select `Add View`.
   1. Use the `List` template.
   1. Use the model type.
   1. Do not use a partial view or reference the scripts.
   1. Do use the layout page.
1. Clean up the view.
   1. Remove the `Description` and `IsPublic` columns from the table. *Note: Tables have a header row that must be modified in addition to the actual data row.* 
   1. Change the title to `My Events`. 
   1. Change the header (`h2`) to match the title.

Add a link on the main page.

1. In the layout page add a new link called `My Events` between `Home` and `About`. 
1. Ensure the controller name and action are correct.

### Notes

1. Ensure past or public events are not displayed.
1. Ensure the ordering of the events.
1. Ensure the business object is not being passed to the view.
1. Be careful about running the debugger while in an HTML page. The debugger will automatically try to go to that page which can cause an error if the page expects a parameter.

### Acceptance Criteria

1. Able to navigate to my events from main page.
1. Events are shown with option to edit or delete.
1. Past events are not shown.
1. Events are shown ordered by start date.
1. Page title and header are correct.
1. Only expected columns are shown.

## Story 4 - Show Public Events

The user will be able to view public events.

### Description

The user can view public events by using a link on the main page. The behavior of public events is identical to My events accept it only applies to events marked as public.

### Acceptance Criteria

1. Able to navigate to public events from main page.
1. Events are shown with option to edit or delete.
1. Past events are not shown.
1. Events are shown ordered by start date.
1. Page title and header are correct.
1. Only expected columns are shown.

## Story 5 - View Event

The user will be able to view an existing event.

### Description

The user can view an existing event.

1. Add a new action called `Details` to the `EventController` class. The method is a GET method. It will require an integral parameter called `id`.
   1. Get the event from the database.
   1. If the event is not found then return a 404 (`HttpNotFound`).
   1. Convert the event to a model and pass it to the view.

Define the UI for my events.

1. Right click the action and select `Add View`.
   1. Use the `Details` template.
   1. Use the model type.
   1. Do not use a partial view or reference the scripts.
   1. Do use the layout page.
1. Clean up the view.
   1. Change the title to `View Event`. 
   1. Change the header (`h2`) to match the title.
   1. Remove the `h4` header with the model name.
   1. Modify the `Back to List` link to return to the appropriate my/public page based upon the event's type.

### Notes

1. It is important that the parameter name be `id` for edit otherwise the routing and existing views will not work.

### Acceptance Criteria

1. Can view the details of an event from the My page.
1. Can view the details of an event from the Public page.
1. Can edit an event using the edit link.
1. Clicking `Back to List` returns to the appropriate page.

## Story 6 - Add Event

The user will be able to add new events.

### Description

The user can add new events.

1. Add a new action called `Create` to the `EventController` class. The method is a GET method.
   1. Create an instance of the model.
   1. Default the start and end dates to today.
1. Add a new action called `Create` to the `EventController` class that accepts the event being added. The method is a POST method. 
   1. Verify the event is valid and then add to the database.
   1. If the event is invalid or the add fails then show the view again with the appropriate information.
   1. If the add succeeds then redirect to the `My` action if the event was private or `Public` if the event was public.

Define the UI for my events.

1. Right click the action and select `Add View`.
   1. Use the `Create` template.
   1. Use the model type.
   1. Do not use a partial view or reference the scripts.
   1. Do use the layout page.
1. Clean up the view.
   1. Change the title to `Add Event`. 
   1. Change the header (`h2`) to match the title.
   1. Remove the `h4` header with the model name.
   1. Modify the `Back to List` link to return to the `My Events` page.

### Notes

1. Remember that attributes (e.g. `HttpGet`, `HttpPost`) are used to indicate which verb an action is for.
1. Remember that action names determine the route that is used.
1. Remember that MVC can distinguish actions by their name and verb but the C# compiler cannot. Ensure no methods have the same signature.
1. Remember that `AddModelError` does not work correctly with exceptions so use the overload that accepts the key (empty) and the exception message.
1. The runtime will handle converting the date/time text to a valid value. Do not worry about adding validation around the formatting here.12

### Acceptance Criteria

1. Able to create an event from the My events page.
1. Event is validated and user is returned to page if invalid.
1. Attempting to add an event that already exists shows an error and returns user to page.
1. User is redirected to appropriate page after add.

## Story 7 - Edit Event

The user will be able to edit existing events.

### Description

The user can edit existing events.

1. Add a new action called `Edit` to the `EventController` class. The method is a GET method. It will require an integral parameter called `id`.
   1. Get the event from the database.
   1. If the event is not found then return a 404 (`HttpNotFound`).
   1. Convert the event to a model and pass it to the view.
1. Add a new action called `Edit` to the `EventController` class that accepts the event being edited. The method is a POST method. 
   1. Verify the event is valid and then update in the database.
   1. If the event is invalid or the update fails then show the view again with the appropriate information.
   1. If the update succeeds then redirect to the `My` action if the event was private or `Public` if the event was public.

Define the UI for my events.

1. Right click the action and select `Add View`.
   1. Use the `Edit` template.
   1. Use the model type.
   1. Do not use a partial view or reference the scripts.
   1. Do use the layout page.
1. Clean up the view.
   1. Change the title to `Edit Event`. 
   1. Change the header (`h2`) to match the title.
   1. Remove the `h4` header with the model name.
   1. Modify the `Back to List` link to return to the `My Events` page.

### Notes

1. It is important that the parameter name be `id` for edit otherwise the routing and existing views will not work.

### Acceptance Criteria

1. Able to edit an exiting event from the My events or Public events pages.
1. Event is validated and user is returned to edit page if invalid.
1. Attempting to edit an event that already exists shows an error and returns user to page.
1. User is redirected to appropriate page after edit.
1. After making changes the updates appear in the UI properly.

## Story 8 - Delete Event

The user will be able to delete an existing event.

### Description

The user can delete an existing event.

1. Add a new action called `Delete` to the `EventController` class. The method is a GET method. It will require an integral parameter called `id`.
   1. Get the event from the database.
   1. If the event is not found then return a 404 (`HttpNotFound`).
   1. Convert the event to a model and pass it to the view.
1. Add a new action called `Delete` to the `EventController` class that accepts the event being edited. The method is a POST method. 
   1. Delete the event from the database. In this case deletion should not fail but go ahead and capture any errors and redirect anyway.
   1. If the delete succeeds then redirect to the `My` action if the event was private or `Public` if the event was public.

Define the UI for my events.

1. Right click the action and select `Add View`.
   1. Use the `Delete` template.
   1. Use the model type.
   1. Do not use a partial view or reference the scripts.
   1. Do use the layout page.
1. Clean up the view.
   1. Change the title to `Delete Event`. 
   1. Change the header (`h2`) to match the title.
   1. Remove the `h4` header with the model name.
   1. Modify the `Back to List` link to return to the appropriate my/public page based upon the event's type.

### Notes

1. It is important that the parameter name be `id` for edit otherwise the routing and existing views will not work.

### Acceptance Criteria

1. Can view the details of an event from the My page.
1. Can view the details of an event from the Public page.
1. Can edit an event using the edit link.
1. Clicking `Back to List` returns to the appropriate page.

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the Github repository.
