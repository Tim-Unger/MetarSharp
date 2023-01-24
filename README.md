![Logo](https://i.imgur.com/YCTLglq.png)
![](https://shields.io/nuget/v/:packageName)
![](https://shields.io/github/v/release/Tim-Unger/MetarSharp?display_name=tag)
![](https://shields.io/github/license/Tim-Unger/MetarSharp)

# Usage

Please head over to [**MetarSharp.Tim-U.me**](https://metarsharp.tim-u.me) for the full documentation

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
