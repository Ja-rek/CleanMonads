## Why I wrote it or what I dislike in other implementations. ?. 

* I much more like the convention of ``Maybe<int>`` instead ``Option<int>``. ``Option<int>`` sounds for me a little bit strange. Yes I know that I'm a foreigner, but ``Option<int>`` still sounds strange. :P The same with 'Just' and 'Some' let's take a look on ``Add(Some(salt));`` and ``Add(Just(salt));`` in my opinion method named "Just" express more clearly logic of monad.

* Long and ugly factory methods.

```csharp

//Any other.

var maybeEmpty = Optional.None<GenericClas<GenericType>>();
var left = Either.Left<string, int>("Error");

//Clean Monad

var maybeEmpty = Nothing;
var left = Left(Error);

```

* Success and Error instead Right and Left. No, just no. 'Right' an 'Left' in  'Either' doesn't have to mean success or fail it can mean anything. For example an alternative object, a status of the application or something else.

* Compare and Equal.

```csharp
//Any other.

var test = optionalString.SomeOrDefault == "Context";
var test = eitherString.RightOrDefault == "Context";

//Clean Monad

var test = maybeString == "Context";
var test = eitherString == "Context";
```

* Class instead of Struct. I don't see any important reason to use a class to implement "Maybe" or "Either" that can cause a performance issue when you'll want to create a very long collection of  ``Maybe<int>``. Of course, I understand that a lot of people will don't care about it because the issue is very small and of course, when you will need to optimize code in a very specific case, probably you will be not using 'Maybe' or even Linq. However, I just feel better witch struct. :D

* Match method, in my opinion, should return something, any "effect of matching". For example bool or matched text. Therefore I used the "Do" method to run 'void methods' with parameters.

```csharp
maybeValue.Do(
    just => VoidMethod(just), 
    nothing:() => VoidMethod("value"));
```
Instead of:
```csharp
maybeValue.Match(
    just => VoidMethod(just), 
    nothing:() => VoidMethod("value"));
```

* Force to use "Stream syntax" instead of C# Linq syntax. Which leads to a mismatch of syntax and general naming convention of the C# language.

So, instead of:
```csharp
var maybeValue = maybe10.Map(x => x + 10);
var maybeValue = maybe10.Filter(x => x == 10);
```

You can use:
```csharp
var maybeValue = maybe10.Select(x => x + 10);
var maybeValue = maybe10.Where(x => x == 10);
```

# Usage

### Namespaces
```csharp
using Monad.Maybe; // Maybe and standartd extension mehtods.
using Monad.Either; // Either and standartd extension mehtods.

using Monad.Maybe.Enumerable; // Extension mehtods of enumerable.
using Monad.Either.Enumerable; // Extension mehtods of enumerable.

using Monad.Maybe.Linq; // Extension mehtods of linq.
using Monad.Either.Linq; // Extension mehtods of linq.

using Monad.Maybe.Unsafe; // Unsafe extension mehtods.
using Monad.Either.Unsafe; // Unsafe extension mehtods.

using static Monads.Either.EitherFactory; // Factory mehtods
using static Monads.Maybe.MaybeFactory; // Factory mehtods
```

## Maybe

### Creating maybe values.

```csharp
using static Monads.Maybe.MaybeFactory;

var maybe = MaybeFrom(uknownType); // Create just value or nothing.
var maybe = uknownType.ToMaybe(); // Create just value or nothing.
var maybe = MaybeFrom(() => uknownType()); // Lazy version

// The same with nullable type

var maybe = MaybeFrom(nullabeType); // Create just value or nothing.
var maybe = nullabeType.ToMaybe(); // Create just value or nothing.
var maybe = MaybeFrom(() => nullabeType()); // Lazy version
```
### Creating just values.

In case that parametr is null method will throw exception.
```csharp
using static Monads.Maybe.MaybeFactory;

var just = Just("context"); // Only for type knowing in compile time.
var just = "context".ToJust(); // Only for type knowing in compile time.
var just = AnyNumber.ToJustIf(num => num == 5); // Create just if condition is met.
```

### Creating nothing.

```csharp
using static Monads.Maybe.MaybeFactory;

var nothing = Nothing;
var nothing = AnyNumber.ToNothingIf(num => num == 5); // Create nothing if condition is met.
```

### Retrieving values

```csharp
if(maybeValue.HasValue) return maybeValue.Value();

// Return just or nothing.
var value = maybeValue.Match(
    just => just + 2, 
    nothing: 5);

// Return just or nothing.
var value = maybeValue.Match(
    just => just + 2, 
    nothing:() => LazyFactory);


// Return just or alternative value.
var value = maybeValue.ValueOr("Alternative context.");

```

Example of typical case
```csharp
var maybeValue1 = Just("value");
var maybeValue2 = Just("value");

var maybeValue = 
    from v1 in maybeValue1
    from v2 in maybeValue2
    from v3 in Method(v1, v2)
    select v3;

var value = maybeValue.Match(
    just => just + 2, 
    nothing: 5);
```

HasValue can use condition.
```csharp
return maybe10.HasValue(x => x < 5) ? 3 : 8;
```

### Run void methods

```csharp
maybeValue.Do(
    just => VoidMethod(just), 
    nothing:() => VoidMethod("value"));

maybeValue.Do(
    just => VoidMethod(just), 
    nothing:() => VoidMethod("value"));

maybeValue.DoWhenHasValue(just => VoidMethod(just));

maybeValue
    .DoWhenHasNoValue(() => VoidMethod("value"));
```

### Retrieving values without safety

```csharp
using Monads.Maybe.Unsafe;

var value = maybeValue.ValueOrDefault();
var value = maybeValue.ToNullable();

var value = maybeValue.Value(); // Throw exception whe null.
var value = maybeValue.ValueOrFail("Erro message."); // Throw exception whe null with message.
```

### Transforming and filtering values

Specifying an alternative value.
```csharp
var maybeValue = maybeValue.Or("10"); 
var maybeValue = maybeValue.Or(Just(number)); // Will throw an exception when number is null;
var maybeValue = maybeValue.Or(number);
var maybeValue = maybeValue.Or(maybeNumber);
var maybeValue = maybeValue.Or(() => lazyNumber());
```

Map
```csharp

//Will return mabye 20 if maybe10 contain value;
var maybeValue = maybe10.Select(x => x + 10);

//Will return maybe 20 if maybe10 contain value;
var maybeValue = from just in maybe10
	         select just + 10;
```

FlatMap
```csharp

//Will return maybe10. 
var maybeValue = Just(Just(10)).SelectMany(x => x);

//Will return maybe10.
var maybeValue = from twoJusts in Just(Just(10))
		 from just in twoJusts
		 select just;
```

Filter
```csharp

//Will return maybe10. 
var maybeValue = maybe10.Where(x => x == 10);

//Will return maybe10.
var maybeValue = from just in maybe10
	  	 where just == 10
	         select just + 10;
```

Work with query linq
```csharp
var maybeValue1 = Just("value");
var maybeValue2 = Just("value");
var maybeValue3 = Just("value");

var value = from v1 in maybeValue1
	    from v2 in maybeValue2
	    from v3 in maybeValue3
            select v1 + v2 + v3;
```

### Enumerable

instead of:
```csharp
var value = list.FirstOrDefault();
var value = list.LastOrDefault();
var value = list.SingleOrDefault();
var value = list.ElementAtOrDefault(1);
```

Use the safe version:
```csharp
var value = list.FirstOrNothing();
var value = list.LastOrNothing();
var value = list.SingleOrNothing();
var value = list.ElementAtOrNothing(1);
```

### Extra Enumerable method
```csharp
var values = listOfMaybes.Values();
```

## Either

### Creating Either values.

```csharp
using static Monads.Maybe.MaybeFactory;

var maybe = EitherFrom(leftValue, rightValue); // Create right or left.
var maybe = uknownType.ToEither(leftValue); // Create right value or left.
var maybe = EitherFrom(() => uknownType()); // Lazy version.

// The same with nullable type

var maybe = EitherFrom(nullabeType);
var maybe = nullabeType.ToEither();
var maybe = EitherFrom(() => nullabeType());
```
### Creating Right values.

In case that parametr is null method will throw exception.
```csharp
using static Monads.Maybe.MaybeFactory;

var right = Right("context"); // Only for type knowing in compile time.
var right = "context".ToRight(); // Only for type knowing in compile time.
var right = AnyNumber.ToRighIf(num => num == 5); // Create right if condition is met.
```

### Creating Left values.

In case that parametr is null method will throw exception.
```csharp
using static Monads.Maybe.MaybeFactory;

var left = Left("context"); // Only for type knowing in compile time.
var left = "context".ToLeft(); // Only for type knowing in compile time.
var left = AnyNumber.ToLeftIf(num => num == 5); // Create left if condition is met.
```

### Retrieving values

```csharp
if(either.IsRight()) return either.Right();
if(either.IsLeft()) return either.Left();

// Return right or left.
var value = either.Match(
    left => left + 2, 
    right => right + 3);

// Return right or alternative left.
var value = either.RightOr("Alternative context.");

// Only for the same types.
var value = either.RightOrLeft();
```

IsLeft and IsRight allow you to use condition.
```csharp
return either.IsRight(x => x < 5) ? 3 : 8;
return either.IsLeft(x => x < 5) ? 3 : 8;
```

### Retrieving values without safety

```csharp
using Monads.Maybe.Unsafe;

var value = either.ValueOrDefault();
var value = either.ToNullable();

var value = either.Value(); // Throw exception whe null.
var value = either.ValueOrFail("Erro message."); // Throw exception whe null with message.
```

### Transforming and filtering values

Map
```csharp

//Will returns Right(20) if tenOrLeft contain value.
var either = tenOrLeft.Select(x => x + 10);

//Will return Right(20) if tenOrLeft contain right.
var either = from ten in tenOrLeft
	     select ten + 10;
```

FlatMap
```csharp
//Will return Right(10)if tenOrLeft contain value. 
var either = Right(Right(10)).SelectMany(x => x);

//Will return Right(10) if tenOrLeft contain right.
var either = from twoJusts in Right(Right(10))
	     from just in twoJusts
	     select just;
```

Filter
```csharp
//Will return Right(10) if tenOrLeft contain right.
var either = tenOrLeft.Where(x => x == 10);

//Will return Right(10) if tenOrLeft contain right.
var either = from just in tenOrLeft
	     where just == 10
	     select just;
```

### Enumerable
instead of:

```csharp
var value = list.FirstOrDefault();
var value = list.LastOrDefault();
var value = list.SingleOrDefault();
var value = list.ElementAtOrDefault(1);
```

Use the safe version:
```csharp
var value = list.FirstOrLeft("Error");
var value = list.LastOrLeft("Error");
var value = list.SingleOrLeft("Error");
var value = list.ElementAtOrLeft(1, "Error");
```

### Extra Enumerable methods
```csharp
var rights = listOfEithers.Rights();
var lefts = listOfEithers.Lefts();

string errors = listOfEithers.AggregateLefts();
```
