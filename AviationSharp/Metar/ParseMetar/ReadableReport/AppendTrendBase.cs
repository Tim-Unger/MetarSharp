namespace AviationSharp.Metar.Parse.ReadableReport 
{ 
    internal class TrendBase
    {
        internal static string Append(AviationSharp.Metar.Trend trend)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Trend: ");

            if(trend.IsTimeRestricted)
            {
                stringBuilder.Append(trend.TimeRestrictionType.ToString()).Append(' ');
                stringBuilder.Append(trend.TimeRestrictionDateTime!.Value.ToString("HH:mm")).Append("UTC ");
            }

            if (trend.TrendType != TrendType.NoSignificantChange)
            {
                stringBuilder.Append(trend.TrendTypeDecoded).Append(' ');
            }

            return stringBuilder.ToString();
        }
    }
}
