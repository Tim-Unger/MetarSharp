![Logo](https://i.imgur.com/YCTLglq.png)
![](https://shields.io/nuget/v/:packageName)
![](https://img.shields.io/gitlab/v/release/Tim-Unger/MetarSharp)
![](https://shields.io/github/license/Tim-Unger/MetarSharp)

# Usage

Please head over to [**Metarsharp.Tim-u.me**](https://metarsharp.tim-u.me) for the full documentation

## Quickstart

This will give you a decoded Metar in the Metar-Class.

```
using MetarSharp;
```
 
 
```
Metar Metar = ParseMetar.FromString("EDDF 182320Z AUTO 26006KT 200V290 CAVOK 09/06 Q1016 NOSIG");
```

or

```
List<Metar> metarList = ParseMetar.FromList(yourInputList);
```
