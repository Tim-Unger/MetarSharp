![Logo](https://i.imgur.com/YCTLglq.png)
<a href ="https://www.nuget.org/packages/MetarSharp/"> <img src="https://shields.io/nuget/v/MetarSharp"/></a>
<a href="https://github.com/Tim-Unger/MetarSharp/releases/latest"> <img src="https://img.shields.io/github/v/release/Tim-Unger/MetarSharp"/> </a>
<a href="https://github.com/Tim-Unger/MetarSharp/blob/main/LICENSE.md"> <img src="https://shields.io/github/license/Tim-Unger/MetarSharp"/> </a>

# Usage

Please head over to [**tim-u.gitbook.io/metarsharp/**](https://tim-u.gitbook.io/metarsharp/) for the full documentation

## Quickstart

This will give you a decoded Metar in the Metar-Class.

```cs
using MetarSharp;
```
 
 
```cs
Metar metar = ParseMetar.FromString("EDDF 182320Z AUTO 26006KT 200V290 CAVOK 09/06 Q1016 NOSIG");
```

or

```cs
List<Metar> metarList = ParseMetar.FromList(yourInputList);
```

# Dependencies

MetarSharp itself uses no NuGet-Packages/Dependencies, although some are used for the other programs:

- [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)

- [Coverlet](https://github.com/coverlet-coverage/coverlet)

- [NUnit](https://github.com/nunit/nunit)
