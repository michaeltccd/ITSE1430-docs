# Nile (ITSE 1430)
## Version 1.0

In this lab you will modify an existing product inventory application to support a SQL Server database and make some other enhancements.

*Note: As with most maintenance work you must follow the existing styling and naming conventions. DO NOT change the existing styling/naming rules. ENSURE your code matches the rules being used.*

[Skills Needed](#skills-needed)

[Story 1](#story-1)

[Story 2](#story-2)

[Story 3](#story-3)

[Story 4](#story-4)

[Story 5](#story-5)

[Story 6](#story-6)

[Story 7](#story-7)

[Requirements](#requirements)

## Skills Needed

- C#
   - Abstract Classes
   - Exceptions and try-catch
   - Interfaces
   - ADO.NET SQL types including SqlConnection and SqlCommand   

## Story 1

Add an About box.

The existing program does not have an About box. Add one that contains the class, semester and your name.

- Update the menu to contain a `Help\About` menu.
- Set the menu item shortcut key to `F1`.
- Add the About form.
- Hook up the menu to show the form.

### Acceptance Criteria

- Menu item is available.
- Clicking menu item shows About form.

## Story 2

Add support for validating a `Product` instance.

Currently the UI does the validation at the control level. Update the `Product` class to support validation using `IValidatableObject`.

- `Id` must be greater than or equal to 0.
- `Name` is required and cannot be empty.
- `Price` must be greater than or equal to 0.

Update the various locations in the code that expects validation. You can use the `TODO` comments to find these locations (`Validate product`).

- In the UI when trying to save a product.
- In the product database when trying to add a product.
- In the product database when trying to update a product.

### Acceptance Criteria

- The product is validated before saving in the UI.
- The product is validated before adding to the database.
- The product is validated before updating in the database.

## Story 3

Report errors for invalid arguments.

Update the code to throw the appropriate exception when invalid arguments are provided. You can use the 'TODO' comments to find these locations (`Check arguments`).

- Reference types should not be `null`.
- Integral types should be within the execpted range.
- `IValidatableObject` implementations should validate.
- For product updates the product being updated must exist.

### Acceptance Criteria

- Cannot add a product to database that is `null` or invalid.
- Cannot update a product in database to `null` or invalid.
- Cannot update a product in database for non-existent product.
- Cannot retrieve a product using an invalid ID.

## Story 4

Handle errors from database.

The UI should not crash if errors occur while interacting with the database. You can use the `TODO` comments to find these locations (`Handle errors`).

- Report an error if the products cannot be retrieved from the database.
- Report an error if a product cannot be added, updated or deleted.

## Story 5

Do not allow duplicate products.

Update the database class to prevent adding a product with the same name as one that already exists. If the product already exists then throw an exception.

Update the database class to prevent updating a product to a new name that already exists. If an existing product already exists then throw an exception. Note that it is valid to update a product to the same name it already has.

### Acceptance Criteria

- Attempting to add a product with the same name as one that already exists fails.
- Attempting to update a product to a new name that already exists fails.
- Attempting to update a product using its same name works.

## Story 6

Add support for storing products in a SQL database.

The solution is currently using an in-memory data store for products. Modify the application to use a SQL database instead.

- Create a new class library called `Nile.Stores.Sql` to store the SQL Server implementation.
- Create a new class to implement the `IProductDatabase` interface using SQL Server. *Note: Use can use the existing `ProductDatabase` abstract class to speed this up.* 
- The class will need the connection string to the database. Create a constructor that accepts this.
- Update the main form to use an instance of this class instead of the existing memory database.

### Notes

- The solution already contains the SQL database. When you build and run the application the first time it should deploy the database. You can confirm this by using `SQL Server Object Explorer`.  The database should show up under `(localdb)\ProjectsV13` (or whatever version of LocalDB you have installed). If it does not appear then set the database project as the startup project and run the debugger (`F5`). This will trigger the deployment.
- To connect to the database you will need a connection string. The connection string is stored in the `App.config` file. It should already be properly set up for LocalDB. If your installation of Visual Studio is using a different database name then you will need to adjust the connection string in the config file.
- The SQL database class will not have access to the config file so ensure it accepts the connection string in the constructor.
- Refer to [ConfigurationManager](https://docs.microsoft.com/en-us/dotnet/api/system.configuration.configurationmanager.connectionstrings?view=netframework-4.7.2) if you do not remember how to get a connection string from a config file. DO NOT hard code the connection string.

### Acceptance Criteria

- When the application runs products are retrieved from the SQL database.
- User can add, edit and remove products and the database is updated correctly.
- The connection string IS NOT hard coded in the application code anywhere.

## Story 7

Sort products by name.

The UI displays the products in the order they are returned by the database. Sort the returned products so they appear alphabetical.

### Acceptance Criteria

- Products appear in the UI alphabetically, irrelevant of the order they are returned by the database.

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the Github repository.
