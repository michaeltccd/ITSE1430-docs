# Lab 5 (ITSE 1430)

For the final lab you will be porting the Movie Library to the web using ASP.NET MVC 5. All the non-UI code should continue to function normally.

## Setting Up the Solution

1. Copy the contents of the entire solution folder to a new folder called ```Lab5```. Ensure it is still in your ```Labs``` folder.
1. Rename the solution file to ```Lab5.sln```.
1. Remove the Windows Forms project from the solution because it will not be needed.

## Create the MVC Project

1. Add a new ASP.NET Web Application (.NET Famework) project to the solution. Ensure the ```Framework``` field is set to `.NET Framework 4.6.1`.
1. In the wizard select the MVC template.
1. Clear any other checkboxes that are checked.
1. Ensure `Authentication` is set to `No Authentication`.

Once the project is created make the following adjustments.

1. Set the project as the startup project.
1. Add the appropriate references so that the project has access to the business library and the SQL database business library.
1. Delete the `App_Data` folder.
1. Go to NuGet Package Manager and remove all the `Microsoft.ApplicationInsights``` packages. They must be removed in a particular order because of dependencies.
    1. Microsoft.ApplicationInsights.Web
    1. Microsoft.ApplicationInsights.WindowsServer
    1. Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel
    1. Microsoft.ApplicationInsights.PerfCounterCollector
    1. Microsoft.ApplicationInsights.DependencyCollector
    1. Microsoft.ApplicationInsights.Agent.Intercept
    1. Microsoft.ApplicationInsights
    1. Microsoft.AspNet.TelemetryCorrelation
    1. System.Diagnostics.DiagnosticSource
1. Delete the `ApplciationInsights.config` file from the project.

Connect to the SQL database.

1. Open the `web.config` file.
1. Copy the `connectionStrings` section from the Windows Form project and paste it into the config file.
1. Build and run the application to ensure is working correctly.

## Setting Up the Home Page

### Index View

1. Replace the contents of the DIV element with the class jumbotron.
    ```html
    <h2>Welcome to MovieLib Web</h2>
    ```
1. Replace the DIV element with the class row.
    ```html
    <div>Your name</div>
    <div>ITSE 1430</div>
    ```

### _Layout View

1. Change the title from `My ASP.NET Application` to `MovieLib` in the header.
1. Remove the `About` and `Contact` links in the navbar.
1. Change the copyright notice in the footer to contain your name.
1. Change the link with text `Application Name` to `MovieLib`.

### Home Controller

1. Remove the actions for everything but `Index`.

## Defining the Models

To isolate the UI from the business layer you need to add a model for each type you want to expose. In the web project do the following.

1. Add a new class called `MovieViewModel` to the `Models` folder.
2. Add properties for each of the properties already defined on the `Movie` business object.

### Implement IValidableObject

Implement the `IValidatableObject` interface. Instead of putting the logic in the `Validate` method, use attributes so the client can enforce the rules. For the `Length` property use a custom error.

To simplify the controller logic, create conversion methods to convert between `Movie` and `MovieViewModel` types. Use an extension methods.

## Displaying the Movies

### Implement the GET Action for Home

Add a new, empty MVC controller class called `MovieController` to manage the movies. Rename the `Index` action to `List`. 

1. Query the movies from the SQL database (consider using a helper method to get the database).
2. For each movie, convert to a view model.
3. Sort the movies by title.
4. Pass the view models to the view.

### Implement the View for Home

1. Right click inside the action to add the corresponding view.
2. The view should be a `List` template using `MovieViewModel` as the model to render the list.
3. Change the `Create New` to `Add` and the action to `Add`.
4. Remove the `Details` link.
5. Change the view header and title to `Movies`.

### Add to Home Page

Add a link to the layout page in the navbar to access the new view. Call the link `Movies`.

### Verify the Behavior for Home

- The link shows up on the home page.
- Clicking the link displays the movies, sorted.

## Adding Movies

### Implement the GET Action for Adding

1. Add a new `Add` action to the controller.
2. Create an empty view model.
3. Pass the view model to the view.

### Implement the POST Action for Adding

1. Add a new `Add` action to the controller that accepts a `MovieViewModel`.
2. Mark the action as a `POST` action.
3. Verify the model is valid using `ModelState`.
4. If valid then add the movie to the database.
5. Catch any exceptions. If any exception occurs add it to `ModelState`. *(Note: Errors will not be shown if you use the overload accepting an `Exception` object.)*
6. If validation or any errors occur then return the user to the view with the existing model.
7. If the operation is successful redirect the user back to the list view.

### Implement the View for Adding

1. Right click inside the action to add the corresponding view.
2. The view should be an `Create` template using `MovieViewModel` as the model.
3. Change the view header and title to `Add Movie`.
4. Remove the `MovieViewModel` header element.
5. The description can be long so replace the `EditorFor` method with `TextAreaFor`.
6. Fix the back link to use the correct action name.

### Verify the Behavior for Adding

1. Can navigate to the view from the list view.
2. Entering an empty title or invalid length causes an error to appear.
3. Any server-side errors (i.e. adding a duplicate movie) returns the user to the view with the existing data intact and the error displayed.
4. Successfully adding a movie returns to the list view and the movie appears.

## Editing Movies

### Implement the GET Action for Editing

1. Add a new `Edit` action to the controller. The action should accept an id parameter representing the movie ID.
2. Query the movie from the database.
3. If the movie does not exist return a 404.
4. If the movie does exist then pass the view model to the view.

### Implement the POST Action for Editing

1. Add a new `Edit` action to the controller that accepts a `MovieViewModel`.
2. Mark the action as a `POST` action.
3. Verify the model is valid using `ModelState`.
4. If valid then update the movie in the database.
5. Catch any exceptions. If any exception occurs add it to `ModelState`.
6. If validation or any errors occur then return the user to the view with the existing model.
7. If the operation is successful redirect the user back to the list view.

### Implement the View for Editing

1. Right click inside the action to add the corresponding view.
2. The view should be an `Edit` template using `MovieViewModel` as the model.
3. Change the view header and title to the name of the movie being edited.
4. Remove the `MovieViewModel` header element.
5. The description can be long so replace the `EditorFor` method with `TextAreaFor`.
6. Fix the back link to use the correct action name.

### Verify the Behavior for Editing

1. Can navigate to the view from the list view.
2. The selected movie populates the controls.
3. Entering an empty title or invalid length causes an error to appear.
4. Any server-side errors (i.e. adding a duplicate movie) returns the user to the view with the existing data intact and the error displayed.
5. Successfully updating a movie returns to the list view and the movie appears.

## Deleting Movies

### Implement the GET Action for Deleting

1. Add a new `Delete` action to the controller. The action should accept an id parameter representing the movie ID.
2. Query the movie from the database.
3. If the movie does not exist return a 404.
4. If the movie does exist then pass the view model to the view.

### Implement the POST Action for Deleting

1. Add a new `Delete` action to the controller that accepts a `MovieViewModel`.
2. Mark the action as a `POST` action.
3. Delete the movie from the database.
4. Redirect back to the list view.

### Implement the View for Deleting

1. Right click inside the action to add the corresponding view.
2. The view should be a `Delete` template using `MovieViewModel` as the model.
3. Change the view header and title to the name of the movie being edited.
4. Remove the `MovieViewModel` header element.
5. Fix the back link to use the correct action name.

### Verify the Behavior for Deleting

1. Can navigate to the view from the list view.
2. The selected movie populates the controls.
3. The movie is deleted from the list.

## Requirements

- Code compiles cleanly without warnings and errors.
- Each file has a file header.
- Public types and members have doctags.
- All code uploaded to Github.
- Lab submitted using MyTCC.