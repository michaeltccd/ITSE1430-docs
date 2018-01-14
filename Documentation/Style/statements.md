# Statements

## Expressions

- Break up complex expressions onto multiple lines or into separate statements to make them easier to read.
- Use parenthesis to make the operator precedence explicit for less frequently used operators.
- Use pre/post-increment/decrement in lieu of adding or subtracting one from a value.
- Use short-circuit evaluation to avoid executing expensive or potentially illegal expressions, such as dereferencing a pointer.
- Consider using spaces around the expression and any operators it uses to make it easier to read.  For example.

```
if (((value1 + value2) == value3) || 
    ((value4 + value5) == value6))
{
};
```

## If Statements

- Use an if statement when code needs to be execute if a condition is true.
- Use an if-else statement when one of several possible code paths needs to be executed based upon a condition.
- Use a block statement when more than one statement needs to be executed inside the if or else body.
- Write the condition such that it is true in the common case.
- Do not replicate code inside the if and else blocks.  Move the code outside the if statement instead.
- Indent the if-else child statements or blocks.  Here is an example.

```
if (someCondition)
{
} else if (someOtherCondition)
{
} else
{
};
```

- If the conditional requires more than one line then line up the expression on each line.

## While Statements
- Use a while loop when code must execute zero or more times until a condition is true.
- Use a do-while loop when code must execute one or more times until a condition is true.
- Use a block statement for the contents of a while loop.
- Use the break statement to execute out of a loop early.
- Use the continue statement to return to the top of the loop.  Some programmers prefer to use an if statement inside the loop to skip over the loop body.  This makes the loop harder to read and less efficient.

## For Statements
- USE a for loop when code must iterate a finite number of times. Exception: Prefer foreach for any ```IEnumerable``` types.
- Define the loop variant variable inside the loop statement to avoid potential runtime errors.
- DO NOT use the loop variant outside the loop.
- AVOID changing the loop variant within the loop body.
- USE the break statement to execute out of a loop early.
- USE the continue statement to return to the top of the loop.  Some programmers prefer to use an if statement inside the loop to skip over the loop body.  This makes the loop harder to read and less efficient.

## Switch Statements
- USE a switch statement when one of several possible code blocks must be executed and the expression evaluates to a value that is a compile-time constant.
- Switch statement conditions are evaluated from top to bottom so place the default block as the last block.
- Switch statements use a lookup table to find the correct code.  The order in which the conditions appear does not matter other than as mentioned above.
- DO put an explicit break after each code block.  If a block needs to fall through to the next block then place a comment indicating that it should.  The exception to this rule is if the block uses a return statement.  In that case the break is unneeded.
- CONSIDER always putting a default case at the end of the statement to catch unexpected cases.
- DO indent each case label equally and the case bodies as well.  Two common approaches is to line up the case labels below the switch statement or, alternatively, indent the case labels and then indent the case bodies.  Here are examples of each.

```
switch(expr)
{
case 1 : 
{
	break;
};
case 2:
{
	break;
};
};

switch(expr)
{
	case 1 : 
	{
		break;
	};

	case 2:
	{
		break;
	};
};
```
- CONSIDER putting a blank line between each case label.
