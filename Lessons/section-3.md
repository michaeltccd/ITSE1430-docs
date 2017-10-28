# Section 3 Lesson Notes (ITSE 1430)

## Abstract Base Classes
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members
- Abstract Members https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract 
- Override https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/override

## Arrays
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/#array-overview
- Declaring an Array https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
- Implicit Typing https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/implicitly-typed-arrays
- Initializing an Array https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays#array-initialization
- Getting the Length https://docs.microsoft.com/en-us/dotnet/api/system.array.length
- Accessing Elements https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/index-operator
- Returning from Members https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1819-properties-should-not-return-arrays
- Arrays as Arguments https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/passing-arrays-as-arguments
- String.Split https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/how-to-parse-strings-using-string-split

## BindingSource
- Purpose https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/bindingsource-component-overview
- Binding to Data Controls https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-bind-a-windows-forms-control-to-a-type-using-the-designer
- Benefits over Direct Binding https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/bindingsource-component-architecture

## DataGridView
- Control https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/datagridview-control-windows-forms
- Columns https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/column-types-in-the-windows-forms-datagridview-control
    - Adding https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-manipulate-columns-in-the-windows-forms-datagridview-control
    - Freezing https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-freeze-columns-in-the-windows-forms-datagridview-control
    - Adjusting Size https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/resizing-columns-and-rows-in-the-windows-forms-datagridview-control   
- Rows
    - Row Headers https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/customize-the-appearance-of-rows-in-the-datagrid
    - Row Selection https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/selection-modes-in-the-windows-forms-datagridview-control
- Binding Data https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-bind-data-to-the-windows-forms-datagridview-control
- Getting Selected Row https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/selected-cells-rows-and-columns-datagridview
- Manipulating Data https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/using-the-row-for-new-records-in-the-windows-forms-datagridview-control
- Disabling Inline Editing https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/prevent-row-addition-and-deletion-datagridview
- Events https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/default-keyboard-and-mouse-handling-in-the-windows-forms-datagridview-control
    - Handling Mouse Events https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview.celldoubleclick
    - Handling Keyboard Events https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.keydown

## Dictionaries
- Purpose https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2
- Adding Items https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.add
- Determining if an Item Exists https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.trygetvalue
- Updating Items https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.item
- Initializers https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer

## Foreach Statement
- Syntax https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/foreach-in
- Using with Arrays https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/using-foreach-with-arrays

## Generic Types
- Definition https://docs.microsoft.com/en-us/dotnet/standard/generics
- Declaring an instance of a Generic Type https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/index
- Benefits of Generic Types https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/benefits-of-generics
- Generic Parameters https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-type-parameters
- Generic Constraints https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters

## Initializers
- Object Initializers https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-objects-by-using-an-object-initializer
- Collection Initializers https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers

## Interfaces
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/index
- Declaring an Interface https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface
- Implementing an Interface https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/explicit-interface-implementation
- Contract Based Programming https://en.wikipedia.org/wiki/Design_by_contract
- Variance in Generic Interfaces https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance
- Example Interfaces    
    - IEnumerable<T> https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1
    - IEnumerator<T> https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerator-1
    - IEqualityComparer<T> https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1
    - INotifyPropertyChanged https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged
    - IValidatableObject https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.ivalidatableobject

## Iterators
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/iterators

## ListBox
- Purpose https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/listbox-control-windows-forms
- Adding Items https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/add-and-remove-items-from-a-wf-combobox
- Accessing Items https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/access-specific-items-in-a-wf-combobox-listbox-or-checkedlistbox
- Getting Selected Item
    - Index https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listbox.selectedindex
    - Item https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listbox.selecteditem
- Detecting Selection Changed https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listbox.selectedindexchanged
- Binding Data https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-bind-a-windows-forms-combobox-or-listbox-control-to-data

## Lists and Collections
- Namespace https://docs.microsoft.com/en-us/dotnet/standard/collections/selecting-a-collection-class
- List<T> Class https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1
- Collection<T> Class https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.collection-1
- Adding Items https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.add
- Accessing Items https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.item
- Removing Items https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.remove
- Counting Items https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.count
- List vs Collection https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/guidelines-for-collections
- Collections vs Arrays https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/arrays

## Nameof Operator
- nameof https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/nameof

