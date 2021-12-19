# WaifuShork's Common Code
(inspired by [Emzi's Common Code](https://github.com/Emzi0767/Common)) 

After reading through DSharpPlus source code and seeing they referenced a project called `Emzi0767.Common`, 
I decided to create my own collection of common reusable components that I use in most of my projects.

## Requirements
This library is built specifically for [.NET 5](https://docs.microsoft.com/en-us/dotnet/core/dotnet-five),
It's not that I don't want to support other frameworks, it's just that with the release of [.NET 5](https://docs.microsoft.com/en-us/dotnet/core/dotnet-five),
I believe that all projects should be migrated to the latest and greatest (if possible). I also almost never 
actually work with older frameworks because I do my best to actively avoid it.

## Nuget
As of right now since the repository is very new and empty, I don't plan on adding it nuget any time soon 
unfortunately.

## Documentation
Most of this library is very poorly documented for right now, but I'll eventually take a day to document everything,
so stay tuned because it'll be `coming soon™`

## Do I Accept PRs?
Yes and no. If you're **adding** new code entirely, I'll almost guaranteed decline it, because it likely isn't something
I'll commonly use since it'll be for you. If you're **refactoring** already existing code to be faster, or better in any way,
if it passes CI/CD then I'll most certainly merge it.

## Object Math
Have you ever wanted to add `(System.Object left) + (System.Object right)`? Well I have, so I made the hellish Object Math
extension just so you don't have to. It supports any boxed type inside of `System.Object` with all the correct 
return values (it will return `Nullable<System.Object>`), but they'll be operated on properly! It supports all arithmetic operators.

