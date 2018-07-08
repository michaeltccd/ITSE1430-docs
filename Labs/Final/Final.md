# Final Project (ITSE 1430)

For the final project you will be taking an existing project and fixing some bugs and adding some new features.

Important notes for implementation:

> You will not be creating any new projects or solutions. Use the existing ones only.
>
> You will not be renaming files or file headers.
>
> To identify your changes, precede each change with a comment including your name and the change request number.
> ```csharp
> //CR1 Me - fixed bad conditional
> if (x = 10)
> ```
>
> The following areas of the code can be assumed to be working properly and do not need to be modified - SQL database stored procedures, logic in views, HTML.

## New Features

The following new features have been added to the program since lab 5.

- Movies have an optional MPAA rating. The movie details shows the rating. When adding or editing a movie the rating is selectable from a dropdown list.
- Movies have an optional release year. The release year is between 1900 and 2100.

## Change Requests

### CR1 - Code does not compile

Description: The code does not currently compile.
Acceptance Criteria: Code compiles cleanly.

This should not require more than a couple of changes to get working.

### CR2 - Movie rating is not being persisted

**Description**: The movie rating is not being saved when added/edited.

**Acceptance Criteria**: Saving the rating during add/edit and then viewing the movie again should show the correct rating.

### CR3 - Release year not properly limited

**Description**: The release year is allowing arbitrary years. It should only allow values between 1900 and 2100.
**Acceptance Criteria**:

   1. Attempting to enter a year outside the valid range reports an error to the user correctly identifying the issue.
   2. Entering a valid year should save properly to the database.

### CR4 - Deleting a movie does nothing

**Description**: When deleting a movie no error occurs but the movie is not deleted.

**Acceptance Criteria**: Deleting a movie removes the movie from the database.

### CR5 - Movies should be sorted

**Description**: Movies are displayed in the order they appear in the database. They should be sorted by name.

**Acceptance Criteria**: Movies are sorted by their name.
