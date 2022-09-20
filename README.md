![Logo](https://tim-u.me/metarsharplogo.png)
![](https://shields.io/nuget/v/:packageName)
![](https://shields.io/github/v/release/Tim-Unger/MetarSharp?display_name=tag)
![](https://shields.io/github/license/Tim-Unger/MetarSharp)
[![GitHub commits](https://badgen.net/github/commits/Tim-Unger/MetarSharp)](https://GitHub.com/Tim-Unger/MetarSharp/commit/)


# Usage

## Quickstart

This will give you a decoded Metar in the Metar-Class.
```
//This should be self-explanatory
using MetarSharp;

//Initializing the Metar directly with a parse
Metar Metar = MetarSharp.ParseFromString("EDDF 182320Z AUTO 26006KT 200V290 CAVOK 09/06 Q1016 NOSIG");
```

## Detailed Overview

### Parsing

You can us three different methods of Parsing a Metar-String.
```
//Parse from a string
Metar StringMetar = ParseMetar.ParseFromString("EDDF 182320Z AUTO 26006KT 200V290 CAVOK 09/06 Q1016 NOSIG");

//Parse from a link (this will download the entire website, so only use websites that only display the Metar)
Metar LinkMetar = ParseMetar.ParseFromLink("https://metar.vatsim.net/eddf");

//Parse a list of Metars
List<string> Metars = //Your list of Metars here (You can use Metars or a link to a website)
List<Metar> ListOfMetars = ParseMetar.ParseList(Metars); //Then you can run through the list
```

### Metar Overview

This shows you all the items in the Metar-Class, all the sub-items are followed below.
```
//This uses the Metar-Class from the quickstart

//The Airport (EDDF)
string Airport = Metar.Airport;

//The Reporting-Time
ReportingTime ReportingTime = Metar.ReportingTime;

//Whether the Metar-Report is automated
bool IsAutomated = Metar.IsAutomatedReport;

//The Wind
Wind Wind = Metar.Wind;

//The prevailing visibility
Visibility Visiblity = Metar.Visibility;

//A List of all Runway-Visibilities (if there are any)
List<RunwayVisibility>? RunwayVisibilities = Metar.RunwayVisibilities;

//A List of Weather around the airport (if there is any)
List<Weather>? Weather = Metar.Weather;

//A List of all clouds around the airport (can not be null, as the metar always needs to specify at least CAVOK)
List <Cloud> Clouds = Metar.Clouds;

//The Temperature
Temperature Temperature = Metar.Temperature;

//The Air-Pressure
Pressure Pressure = Metar.Pressure;

//The Trend
Trend Trend = Metar.Trend;

//A List of all Runway-Conditions (if there are any)
List<RunwayCondition>? RunwayConditions = Metar.RunwayConditions;

//Any Additional Information in Report
AdditionalInformation AdditionalInformation = Metar.AdditionalInformation;
```

#### ReportingTime

```
//The Reporting-Time exactly as presented in the Metar (182320Z)
string ReportingTimeRaw = ReportingTime.ReportingTimeRaw;

//The Date of the Reporting-Time as an int (18)
int ReportingDateRaw = ReportingTime.ReportingDateRaw

//The Reporting-Time (UTC) of the Metar (2320)
int ReportingTimeRaw = ReportingTime.ReportingTimeZuluRaw;

//The Reporting-Time as a DateTime
/*
If the current day matches the day of the report, it will use the current day
If not, it will check if the day has passed in the current month
If not, it will check if the day has passed in the preceding month
If not (e.g. 31st in February) it will use the month before that
*/
DateTime ReportingTimeDateTime = ReportingTime.ReportingTimeZulu;
```

### Wind

```
//The Wind exactly as presented in the Metar (13005G25KT 030V090)
string WindRaw = Wind.WindRaw;

//Whether the wind is calm (00000KT) or not
bool IsWindCalm = Wind.IsWindCalm;

//The Wind-Direction (130)
int WindDirection = Wind.WindDirection;

//The Wind-Strength (5)
int WindStrength = Wind.WindStrength

//The Wind-Unit (as presented in the Metar) (KT)
string WindUnit = Wind.WindUnitRaw;

//The Wind-Unit (Human-Readable) (Knots)
string WindUnitReadable = Wind.WindUnitDecoded;

//Whether there are Wind-Gusts
bool IsWindGusting = Wind.IsWindGusting;

//The Wind-Gusts (25)
int? WindGusts = Wind.WindGusts;

//Whether the wind is variable (VRB)
bool IsWindVrb = Wind.IsWindVariable;

//Whether the Direction of the Wind is varying (second part of the example at the top)
bool IsWindDirectionVariable = Wind.IsWindDirectionVaring;

//The Wind-Direction Variation exactly as presented in the Metar (030V090)
string WindVations = Wind.WindDirectionVariationRaw;

//The Low-Direction of the Wind-Direction-Variations (030)
int WindVarLow = Wind.WindVariationLow;

//The High-Direction of the Wind-Direction-Variation (090)
int WindVarHigh = Wind.WindVariationHigh;
```

### Visibility

### Runway-Visibility (RVR)

**The Metar-Class returns a List<>? of all current RVRs. This shows a single List-Item (RunwayVisibility)**
```
//The RVR exactly as presented in the Metar (R29L/0900VP1800D)
string RVRRaw = RunwayVisibility.RunwayVisibilityRaw;

//The Runway of the current RVR (29L)
string Runway = RunwayVisibility.Runway;

//the Designator of the Parallel-Runway (If it is a parallel runway) (L)
string? Designator = RunwayVisibility.ParallelRunwayDesignator;

//The Designator of the Parallel-Runway decoded (If it is a parallel runway) (Left)
string? DesignatorDecoded = RunwayVisibility.ParallelRunwayDesignatorDecoded;

//The Runway-Visual-Range (0900)
int RVR = RunwayVisibility.RunwayVisualRange;

//Whether the RVR is specified to be more or less than the value (false)
bool IsMoreOrLess = RunwayVisibility.IsRVRValueMoreOrLess;

//The more or less tendency decoded (null)
string MoreOrLessDecoded = RunwayVisibility.RVRMoreOrLessDecoded;

//The Tendency of the RVR as presented in the Metar (D)
string RVRTendency = RunwayVisibility.RVRTendencyRaw;

//The Tendency of the RVR decoded (Downgrading)
string RVRTendencyDecoded = RunwayVisibility.RVRTendencyDecoded;

//Whether the RVR is varying (true)
bool IsRVRVarying = RunwayVisibility.IsRVRVarying;

//Whether the Variation of the RVR is specified to be more or less of the value (true)
bool? IsVariationMoreOrLess = RunwayVisibility.IsRVRVariationMoreOrLess;

//The more or less tendency decoded (More)
string VariationMoreOrLessDecoded = RunwayVisibility.RVRVariationMoreOrLessDecoded;

//The Value of the RVR-Variation (1800)
int RVRVariation = RunwayVisibility.RVRVariationValue;

//The Tendency of the RVR-Variation
//TODO
```
### Weather
**The Metar-Class returns a List<>? of all current Weather. This shows a single List-Item (Weather)**

```

```

### Clouds
**The Metar-Class returns a List<> of all current Clouds. This shows a single List-Item (Cloud)**
```
//Whether the ceiling is CAVOK (false)
bool IsCavok = Cloud.IsCAVOK;

//Whether the cloud is measurable (if not it will be /// in the metar) (true)
bool IsCloudMeasurable = Cloud.IsCloudMeasurable;

//The Cloud as presented in the Metar (BKN016CB)
string CloudRaw = Cloud.CloudRaw;

//The type of Cloud-Coverage as presented in the Metar (BKN)
string CloudTypeRaw = Cloud.CloudCoverageTypeRaw;

//The type of Cloud-Coverage decoded (Broken Clouds)
string CloudTypeDecoded = Cloud.CloudCoverageTypeDecoded;

//Whether the Ceiling of the Cloud is measurable (if not it will be /// in the Metar) (true)
bool IsCloudCeilingMeasurable = Cloud.IsCeilingMeasurable;

//The Cloud-Ceiling (016)
int? CloudCeiling = Cloud.CloudCeiling;

//Whether the Cloud has Cumulonimbus-Clouds (true)
bool HasCB = Cloud.HasCumulonimbusClouds;

//Whether the Type of the Cumulonimbus-Cloud is measurable (if not it will be /// in the Metar) (true)
bool IsCBTypeMeasurable = Cloud.IsCBTypeMeasurable;

//The Type of the Cumulonimbus-Cloud as presented in the Metar (CB)
string CB = Cloud.CBCloudTypeRaw;

//The Type of the Cumulonimbus-Cloud decoded (Cumulonimbus)
string CBDecoded = Cloud.CBCloudTypeDecoded;

//Whether Vertical-Visibility is used instead of clouds (if the ceiling is too low for clouds) (false)
bool IsVerticalVisibility = Cloud.IsVerticalVisibility;

//Whether the Vertical-Visibility is measurable (if not it will be /// in the Metar) (null)
bool? IsVertivalVisibilityMeasurable = Cloud.IsVerticalVisibilityMeasurable;

//The Vertical-Visibility (null)
int? VerticalVisibility = Cloud.VerticalVisibility;
```
### Readable Report
The Metar also generates a readable Report as a string
```
//Readable Report
string Report = Metar.ReadableReport;

//A report will look something like this:
/*
Automated weather report for EDDF.
Reported today at 23:20 UTC
Wind: 170 Degrees 1 Knot
Ceiling and Visibility Okay
Temperature: 7°C
Dewpoint: 6°C
Pressure: 1025hPa or 30.00inHg
*/
```

## Parsing a Metar-Class into a String
