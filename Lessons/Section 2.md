# Section 2 Lesson Notes (ITSE 1430)

## General Guidelines
- Casing https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/capitalization-conventions
- Naming https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/general-naming-conventions

##	Namespaces
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/namespaces/#namespaces-overview
- Using a Namespace https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive
- Declaring a Namespace https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/namespace
- Fully Qualified Type Names https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/namespaces/using-namespaces#fully-qualified-names
- Guidelines
	- Assemblies https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-assemblies-and-dlls
	- Namespaces https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-namespaces

## Classes
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/classes
- Defining a Class https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class
- Creating an Instance https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/new-operator
- Using Members of a Class https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operator
- Accessibility
	- Public https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers 
	- Internal https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
- Commenting
	- Summary Doctag https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/summary
	- Remarks Doctag https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/remarks
	- Para Doctag https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/para
- Guidelines
	- Naming https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces


## Fields
- Declaring a Field https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/fields
- Accessibility
	- Private https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
- Readonly Keyword https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly
- Const Keyword https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constants
- Guidelines
	- Naming https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-type-members#names-of-fields
	- Design https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/field

## Properties
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties
- Defining a Property https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
- Get Properties https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/get
- Set Properties https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/set
- Auto Properties https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
- Changing Accessibility https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/restricting-accessor-accessibility
- Commenting
	- Value Doctag https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/value
- Guidelines
	- Naming https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-type-members#names-of-properties
	- Design https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/property	

## Methods
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods
- Defining a Method https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods#method-signatures
- Parameters https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/passing-parameters
	- Input https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/method-parameters
	- Output https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-parameter-modifier		
	- Input/Output https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/passing-value-type-parameters#passing-value-types-by-reference
	- Inline Variable Declarations https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-parameter-modifier#calling-a-method-with-an-out-argument
	- Variable Arguments https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/params
	- Implicit This https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/this	
	- Commenting
		- Param Doctag https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/param
		- Paramref Doctag https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/paramref
	- Guidelines
		- Naming https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-parameters
		- Design https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/parameter-design
- Return Type https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/return
- Calling Methods https://docs.microsoft.com/en-us/dotnet/csharp/methods#method-invocation
- Local Functions https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions
- Commenting
	- Returns Doctag https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/returns
- Guidelines
	- Naming https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-type-members#names-of-methods
	- Overloading https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/member-overloading
	
## Constructors
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors
- Defining a Constructor https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/instance-constructors
- Constructor Chaining https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/classes#constructor-initializers

## Inheritance
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/inheritance#background-what-is-inheritance
- Defining a Base Class https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/inheritance#designing-the-base-class-and-derived-classes
- Accessibility 
	- Protected https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
- Virtual Members
	- Virtual Keyword https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual
	- Override Keyword https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/override
	- Abstract Keyword https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract
	- Base Keyword https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/base

## Classes vs Structs
- Inheritance https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/value-types
- Instances https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/objects
- Using Structs https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-structs
- Equality https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/objects#object-identity-vs-value-equality

## Windows Forms
- Getting Started https://docs.microsoft.com/en-us/dotnet/framework/winforms/getting-started-with-windows-forms
- Creating a Form https://docs.microsoft.com/en-us/dotnet/framework/winforms/creating-a-new-windows-form
- Form Class https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form?view=netframework-4.7
	- Text Property https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.text?view=netframework-4.7#System_Windows_Forms_Form_Text
	- Close Method https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.close?view=netframework-4.7

## Windows Forms Controls
- Definition https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/
- Controls Class https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control?view=netframework-4.7
	- Name https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.name?view=netframework-4.7
	- Text https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.text?view=netframework-4.7
	- Enabled https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.enabled?view=netframework-4.7
- Common Controls https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/windows-forms-controls-by-function
- Label https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.label?view=netframework-4.7
- Button https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.button?view=netframework-4.7
- TextBox https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.textbox?view=netframework-4.7
	- ReadOnly https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.textboxbase.readonly?view=netframework-4.7
	- Multiline https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.textbox.multiline?view=netframework-4.7
	- MaxLength https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.textboxbase.maxlength?view=netframework-4.7

## Form Layouts
- Using the Designer https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/putting-controls-on-windows-forms
- Resizing https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-resize-controls-on-windows-forms
- Align https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-align-multiple-controls-on-windows-forms
- Tab Order https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-set-the-tab-order-on-windows-forms
- Anchor https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-anchor-controls-on-windows-forms
- Docking https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-dock-controls-on-windows-forms

## Containers
- Controls Property https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.controls?view=netframework-4.7
- FlowLayoutPanel https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.flowlayoutpanel?view=netframework-4.7
- Panel https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.panel?view=netframework-4.7
- SplitContainer https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.splitcontainer?view=netframework-4.7
- TableLayoutPanel https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.tablelayoutpanel?view=netframework-4.7
- TabControl https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.tabcontrol?view=netframework-4.7

## Delegates
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
- Syntax https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/delegate
- Action`T https://docs.microsoft.com/en-us/dotnet/api/system.action-1
- Func`T https://docs.microsoft.com/en-us/dotnet/api/system.func-1

## Events
- Purpose https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/
- Handling Events https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events
- Event Handlers https://docs.microsoft.com/en-us/dotnet/api/system.eventhandler-1?view=netframework-4.7
- Event Arguments
	- EventArgs https://docs.microsoft.com/en-us/dotnet/api/system.eventargs?view=netframework-4.7
	- CancelEventArgs https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.canceleventargs?view=netframework-4.7
- Control Events
	- Button Click https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.click?view=netframework-4.7
	- TextBox TextChanged https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.textchanged?view=netframework-4.7
- Guidelines https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/event

## More Controls
- MenuStrip https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.menustrip?view=netframework-4.7
	- Items Property https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.toolstrip.items?view=netframework-4.7
- ToolStripMenuItem https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.toolstripmenuitem?view=netframework-4.7
	- Click Event https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.toolstripitem.click?view=netframework-4.7
- CheckBox https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.checkbox?view=netframework-4.7
	- Checked Property https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.checkbox.checked?view=netframework-4.7

## MessageBox
- Purpose https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox?view=netframework-4.7
- DialogResult https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.dialogresult?view=netframework-4.7

## Child Forms
- Showing
	- Modal https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.showdialog?view=netframework-4.7
	- Modeless https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.show?view=netframework-4.7
- Related Properties
	- Owner https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.owner?view=netframework-4.7
	- StartPosition https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.startposition?view=netframework-4.7

## Form Lifetime
- Events https://docs.microsoft.com/en-us/dotnet/framework/winforms/order-of-events-in-windows-forms
- Loading
	- Load Event https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.load?view=netframework-4.7
	- OnLoad Method https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.onload?view=netframework-4.7
- Closing
	- FormClosing Event https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.formclosing?view=netframework-4.7
	- OnFormClosing Method https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.onformclosing?view=netframework-4.7
- Closed
	- FormClosed Event https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.formclosed?view=netframework-4.7
	- OnFormClosed Method https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.onformclosed?view=netframework-4.7

## Validation
- Controls
	- Validating 
		- Validating Event https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.validating?view=netframework-4.7
		- OnValidating Method https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.onvalidating?view=netframework-4.7
	- Validated
		- Validated Event https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.validated?view=netframework-4.7
		- OnValidated Method https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.onvalidated?view=netframework-4.7
	- Lost Focus
		- Leave Event https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.leave?view=netframework-4.7
		- OnLeave Method https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.onleave?view=netframework-4.7
		- LostFocus Event https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.lostfocus?view=netframework-4.7
		- OnLostFocus Method https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.onlostfocus?view=netframework-4.7
	- Getting Focus
		- Enter Event https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.enter?view=netframework-4.7
		- OnEnter Method https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.onenter?view=netframework-4.7
		- GotFocus Event https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.gotfocus?view=netframework-4.7
		- OnGotFocus Method https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.ongotfocus?view=netframework-4.7
- Forms
	- ValidateChildren Method https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.validatechildren?view=netframework-4.7

## Error Provider
- ErrorProvider https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.errorprovider?view=netframework-4.7
- Setting Errors https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.errorprovider.seterror?view=netframework-4.7
- Getting Errors https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.errorprovider.geterror?view=netframework-4.7
- Using with Control Validation https://docs.microsoft.com/en-us/dotnet/framework/winforms/user-input-validation-in-windows-forms