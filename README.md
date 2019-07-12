# Clean Monads

![CleanMonads](https://github.com/Ja-rek/CleanMonads/blob/master/Icon.png?raw=true)

 [![nuget](https://img.shields.io/nuget/v/cleanmonads.svg)](https://www.nuget.org/packages/cleanmonads/) [![Build Status](https://travis-ci.org/Ja-rek/CleanMonads.svg?branch=master)](https://travis-ci.org/Ja-rek/CleanMonads)

A rich implementation of ”Maybe” and ”Either” monads for C# with extra utils, extensions, and integrations. The purpose of creating the library was to provide  the cleanest declarative interface.

### Requirements
C# in version 7.3 or higher.

### instalation
Use one of the the commands to install.

| CLI | Command |
| ------ | ------ |
| PM | Install-Package CleanMonads |
| dotnet | add package CleanMonads |
| paket | add CleanMonads |


### Last Version

#### V2.1.2

### New Features!

  - Fixed bug in extension method of "Maybe" named "Filter" 


## How to create

You can create the monads in 3 way.

#### By implicitly conversion
```csharp
Maybe<int> val = 5;
```

#### By factory
```csharp
var val = MaybeFactory.Just(number); // Will throw exception when null;
var val = MaybeFactory.MaybeOf(number); // Create "Nothing" when null.
var  val = MaybeFactory.Nothing; // "Nothing" Returns Maybe<INothing>
Maybe<string>  val = MaybeFactory.Nothing; // Cast to "Nothing" as Maybe<string>
var val = MaybeFactory.NothingOf<int>(); // Returns "Nothing" of Maybe<int>
//etc...

// Or shorter way, that I recommend.
using static Monads.MaybeFactory;

var val = Just(number); 
var val = MaybeOf(number);
var val = Nothing;
var val = NothingOf<int>();
var val = Right(5);
var val = Left(5);
//etc...
```

#### By extension methods
```csharp
var val = 5.ToMaybe();
var val = 5.ToEither("other");
var val = 5.Just();
var val = 5.Nothing();
var val = 5.ToJustIf(x => x == 5);
//etc...
```

## Understand the "NotDefined" type

#### Maybe

You can be confused about why in "MabyFactory" "Nothing" is represented as Method and Property.

So let's take a look on it:
```csharp
return Nothing; // returns Maybe<NotDefined>
return NothingOf<int>(); // returns Maybe<int>
```

As you see property ``Nothing`` returns `Maybe<NotDefined>`. This version you should use when there is a possibility to implicitly conversion. 

For example:

```csharp
public Maybe<int> GetId()
{
    // In this case you can treat it just like shortened version of NothingOf<int>.
    return Nothing; 
}
```
For "reference type" like `Maybe<object>`, you can return a simply null.

```csharp
public Maybe<object> GetId()
{
    return null;
}
```

The `NothingOf` you should use when you want to create a "Maybe" of a specific type which has status nothing. Status nothing means empty.

```csharp
var val = NothingOf<int>;
```
#### Either

The "Either" work in a similar way.

```csharp
return Right("text"); // Returns Either<NotDefined, string>. 
return Left("error"); // Returns Either<string, NotDefined>.
return EitherOf("error", beOrNotToBe) // Returns Either<string, string>.
```

So, when "either" represents two the same types, you should point which side you want to return 
Like that:
```csharp
public Either<string, string> GetName()
{
    return Right("Jhon");
}
```
When types are different, you can return just a value.
```csharp
public Either<string, int> GetId()
{
    return 69;
}
```

## Operations on values 

The monads give you an ability to use methods similar to "Select" "Where" like in LINQ, but the use case is different because we not operate on the collection of objects. Purpose of using the methods is to make operations on value or filter the value only when the value is available.

Let's take a look.

```csharp
surname.Map(val => val.ToUpper());
surname.FatMap(Util.Upper); // Utis.Upper returns Maybe<string>
surname.Filter(val => val == "Mardok"); // Accept only surname "Mardok".
```

For "Maybe" type you can also use method "Or".
When the surname is empty method "Or" will return "Maybe" type with "New name" like below.
```csharp
surname.Or("New name");
```
You can also use Query LINQ sytax.
```csharp
using Monads.Extensions.Linq;

 var sresult = 
    from id in GetId()
    from employe in GetEmploye(id)
    from result in Payment.Payoff(employe, 2900)
    where result == true
    select result;
```

#### Convert Monads

From Either to Maybe:
```csharp
val.AsMaybe();
```

From Maybe to Either:
```csharp
val.AsEither("Error");
```

## Retrieving values

#### Safe way

Basic:
```csharp
 if(id.HasValue()) return id.Value; // Maybe
 if(id.IsRight()) return id.Right; // Either
```
To match value use "Adjust" method or "Do" method for void operations.

```csharp
var id = GetNumber()
    .Adjust(val => val + 5, nothing: 69);

GetNumber()
    .Do(
       just: Console.WriteLine, 
       nothing: Console.WriteLine("Error"));

//Or

GetNumber().DoWhenHasValue(Console.WriteLine); // Maybe
GetNumber().DoWhenRight(Console.WriteLine); // Either
```

You can also use a more simple methods like ValueOr.

```csharp
GetNumber().ValueOr(69);
GetNumber().RightOr(69);

GetNumber().ValueOrZero();
GetNumber().RightOrLeft(); //For Either<int,int>.
```

#### Unsafe way

The unsafe way to retrieve value only on your own risk.

```csharp
using Monads.Extensions.Unsafe;

GetNumber().Value(); // throw InvalidOperationException("Value can not be null.")
GetNumber().ValueOrDefault();
GetNumber().ToNullable(); // Returns for examle Nullable<int>.
GetNumber().ValueOrFail("Error message");// throw InvalidOperationException("Error message")
```

## Extensions

#### Linq

```csharp
using Monads.Extensions.Linq;

items.ElementAtOrNoghing(5);
items.FirstOrLeft("Error");
// etc...

// Special methods
items.Values(); // returns existing values.
items.AggregateLefts(); // returns all lefts as string.
items.Rights();
items.Lefts();

// Query syntax
 var sresult = 
    from id in GetId()
    from employe in GetEmploye(id)
    from result in Payment.Payoff(employe, 2900)
    where result == true
    select result;

```

#### Parsers

```csharp
using Monads.Extensions.Parsers;

var val = "25";

val.ParseToInt(); // returns Maybe<int>
val.ParseToInt(left: "Error"); // returns Either<string, int>
// etc...
```

#### Unsafe

```csharp
using Monads.Extensions.Unsafe;

GetNumber().Value(); // throw InvalidOperationException
GetNumber().ValueOrDefault();
GetNumber().NullableValue();
GetNumber().ValueOrFail("Error message");
```

## Utils

#### Parsers
Optionaly you can use utils to parse string.

For example:
```csharp
BoolParser.Parse("True"); // returns Maybe<bool>
BoolParser.Parse("True", AppStatus.Erro); // returns Either<AppStatus, bool>
//etc...
```

## Integrations

#### Regex

Now you can use regex in a more declarative way.
```csharp
using Monads.Integrations.Regex;

var val = Regex.Match(input, pattern)
    .Map(x => x.Value.ToUpper())
    .ValueOr("Alternative string");

```
Instead off:
```csharp
var match = Regex.Match(input, pattern);

string val;

if (match.Success)
{
    val = match.Value.ToUpper();
}
else
{
   val = "Alternative string"
}
```


For more check tests.
