# Clean Monads

![CleanMonads](https://github.com/Ja-rek/CleanMonads/blob/master/Icon.png?raw=true)

 [![nuget](https://img.shields.io/nuget/v/cleanmonads.svg)](https://www.nuget.org/packages/cleanmonads/) [![Build Status](https://travis-ci.org/Ja-rek/CleanMonads.svg?branch=master)](https://travis-ci.org/Ja-rek/CleanMonads)

It's an implementation of "Maybe" and "Either" monads for C# with extra utils, extensions, and integrations.
The purpose of creating the library was providing the cleanest and easy to use interface, integration with standard libraries as well.

The library is not trying to provide "full functional programming style" to C#.
If you looking for something like that check the language-ext.

### Requirements
C# in version 7.3 or higher.

### instalation
Use one of the the commands to install.

| CLI | Command |
| ------ | ------ |
| PM | Install-Package CleanMonads |
| dotnet | add package CleanMonads |
| paket | add CleanMonads |

## V2.0.0

### New Features!

  - Added integration with RegularExpressions.Regex ('Match' methods returns Mabye\<string\>)
  - Added Utils and extensions for parsing values
  - New extension methods to retrive value like ValueOrEmpty, ValueOrZero
  - Method 'Adjust' which is responsible for matching value can return any type
  
#### Changes:

  - Changed methods 'Select', 'SelectMany', 'Where' on 'Map', 'FlatMap', 'Filter'
  - Method 'Match' renamed to 'Adjust'
  - Either monad changed to class from structure
  - Renamed factory methods 'MaybeFrom', 'EitherFrom' to 'MaybeOf', 'EitherOf'
