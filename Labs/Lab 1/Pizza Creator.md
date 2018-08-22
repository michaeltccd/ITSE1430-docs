# Pizza Creator (ITSE 1430)
## Version 1.1

In this lab you will create a console application to order a pizza. The application will provide the user options to order a pizza and display the running total for the order.

## Skills Needed

- C#
	- Control flow statements
	- Functions and parameters
	- Types
	- Variables
- Console read/write

## Story 1 - Create the Project

Create a new console project to hold your code.

1. Open Visual Studio.
2. Create a new project.
    1. Select the `Console App (.NET Framework)` project template.
    2. Ensure the `.NET Framework 4.6.1` option is set.
    3. Set the project name to `PizzaCreator`.
    5. Ensure the location is under your `Labs` folder in your local Git repository.
    5. Create the project.
3. Compile and run the application to ensure everything is working.
4. Commit the project to GitHub to make sure the commit process is working.

### Acceptance Criteria

1. The application compiles cleanly without warnings or errors.
1. The application runs.

## Story 2 - Display the Main Menu

Console applications typically have a menu to allow the user to interact with the system. The application will allow the following options. The options will be discussed later.

- New Order
- Modify Order
- Display Order
- Quit

The cart price should be shown (with a label) each time the menu is. The cart should show the current price based upon the order.

### Acceptance Criteria

1. Display the main menu to the user.
1. Allow the user to select one of the valid options and then perform the requested action.
1. Continue to display the main menu until the user elects to quit.
1. If the user selects an option that is not available then display an error and continue.
1. The cart price is correctly shown (with currency symbol and 2 digits of precision) each time.

*Note: You may use either letters or digits to provide access to your menu. If you use letters then ensure they are case insensitive.*

## Story 3 - Quit

Allows the user to exit the program.

### Acceptance Criteria

1. The application terminates when selected.

## Story 4 - New Order

Allows the user to create a new order. If an order is already created then the user is first prompted to overwrite the existing order.

The order process walks the user through the process of creating a pizza. The following choices are available

- Size (one is required).
    - Small ($5)
    - Medium ($6.25)
    - Large ($8.75)
- Meats (zero or more). Each option is $0.75 extra. The user can select or unselect the options until done.
    - Bacon
    - Ham
    - Pepperoni
    - Sausage
- Vegetables (zero or more). Each option is $0.50 extra. The user can select or unselect the options until done.
    - Black olives
    - Mushrooms
    - Onions
    - Peppers
- Sauce (one is required). 
    - Traditional ($0)
    - Garlic ($1)
    - Oregano ($1)
- Cheese (one is required).
    - Regular ($0)
    - Extra ($1.25)
- Delivery (one is required).
    - Take Out ($0)
    - Delivery ($2.50)

After the user has entered their order information then the application will display the order information and return to the main menu.

### Acceptance Criteria

1. If no order already exists then the user starts creating a new order.
1. If an order exists then the user is prompted to start over. If the user chooses yes then a new order is created. If the user chooses no then nothing happens.
1. User is required to select a size.
1. User may select zero or more meats. 
1. User can unselect a selected meat option.
1. User may select zero or more vegetables.
1. User can unselect a selected vegetable option.
1. User can select a type of sauce.
1. User can select a type of cheese.
1. User can select a delivery type.
1. After order entry user is shown the order information.
1. If the user enters any invalid options then they receive an error message.
1. Prices are shwon in the correct currency format.

## Story 5 - Display Order

Shows the order information to the user. The order information includes the order options, price for each one and the total price. Prices are shown in correct currency format.

For example.

```
Medium Pizza     $6.25
Take Out   
Meats
   Bacon         $0.75
   Ham           $0.75
Vegetables
   Onions        $0.50
Sauce
   Traditional   
-----------------------
Total            $8.25
```

### Acceptance Criteria

1. All order information is shown and correct.
1. Order total is correct.
1. Prices are shwon in the correct currency format.

## Story 6 - Modify Order

Allows the user to modify an existing order. If there is no existing order then an error is displayed.

The user is sent through the order process again. Any existing selections are left intact. Currently selected options are marked as selected to indicate to the user their previous choice. After the order is modified the order is displayed again.

### Acceptance Criteria

1. If there is no existing order then display an error and return to main menu.
1. If there is an order then send the user back through the order process again. Each existing selection is shown and user can change the selection.
1. After order is finished the order is displayed as before.

## Hints

### Variables

- USE nouns for variable names. 
- USE singular or plural when representing singular or multiple values, respectively.
- USE the most appropriate type for each variable.
	- `bool` stores true or false values. Do not use integrals for this.
	- `decimal` stores monetary values.
	- `double` stores floating point values.
	- `int` stores integral values.
	- `string` stores textual values.

For now make any variables that are needed across function calls "global" variables.
	1. Define the variable inside the `Program` class but outside all functions.
	2. Prefix the variable declaration with `private static`.
	```csharp
	private static decimal price;
	```

To detect an "existing" order either use a variable that starts out initialized to an invalid state (e.g. size of 0) or use a boolean flag. Be sure that the "existing" indicator is updated properly as the application executes.

### Console

[Console.WriteLine](https://docs.microsoft.com/en-us/dotnet/api/system.console.writeline) can be used to write a line of text with a newline.

[Console.ReadLine](https://docs.microsoft.com/en-us/dotnet/api/system.console.readline) can be used to read an entire line input.

[Console.ReadKey](https://docs.microsoft.com/en-us/dotnet/api/system.console.readkey) can be used to read a single key and, optional, not display it to the user. When using this method note that you have to use the [Key](https://docs.microsoft.com/en-us/dotnet/api/system.consolekeyinfo.key) property of the return value to get the actual key pressed.

Output can be colored for emphasis using the [Console.ForegroundColor](https://docs.microsoft.com/en-us/dotnet/api/system.console.foregroundcolor) and [Console.BackgroundColor](https://docs.microsoft.com/en-us/dotnet/api/system.console.backgroundcolor) values. If changing the color then be sure to reset the colors using [Console.ResetColor](https://docs.microsoft.com/en-us/dotnet/api/system.console.resetcolor).

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the Github repository.