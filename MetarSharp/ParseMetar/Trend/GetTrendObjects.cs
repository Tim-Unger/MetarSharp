namespace MetarSharp.Parse
{
    internal class TrendObjects
    {
        //First, all trend objects are split by this big regex
        private static readonly Regex _trendRegex = new(@"(\s[0-9]{4}(?:\s|$))|(RE)?(-|\+|VC)?(MI|BC|BL|SH|TS|FZ|DZ|RA|SN|PL|GR|GS|UP|BR|FG|FU|VA|DU|SA|HZ|SQ|FC|SS){1,}\s|((([0-9]{3})([0-9]{1,3})|VRB([0-9]{1,3})|(/{3})(/{1,3}))(G([0-9]{1,3}))?)(KT|MPS|MPH)(\s(([0-9]{3})V([0-9]{3})))?|((CAVOK)|((FEW|SCT|BKN|OVC|VV|NSC|NCD|///)([0-9]{3}|///)(CB|TCU|///)?))", RegexOptions.Multiline);

        //These are the Regexes for each individual trend element
        private static readonly Regex _visRegex = new(@"(\s[0-9]{4}(?:\s|$))", RegexOptions.Multiline);

        private static readonly Regex _weatherRegex = new(@"(RE)?(-|\+|VC)?(MI|BC|BL|SH|TS|FZ|DZ|RA|SN|PL|GR|GS|UP|BR|FG|FU|VA|DU|SA|HZ|SQ|FC|SS){1,}\s");

        private static readonly Regex _windRegex = new("((([0-9]{3})([0-9]{1,3})|VRB([0-9]{1,3})|(/{3})(/{1,3}))(G([0-9]{1,3}))?)(KT|MPS|MPH)(\\s(([0-9]{3})V([0-9]{3})))?");

        private static readonly Regex _cloudRegex = new("((CAVOK)|((FEW|SCT|BKN|OVC|VV|NSC|NCD|///)([0-9]{3}|///)(CB|TCU|///)?))");

        internal static List<object> Get(string input)
        {
            var result = new List<object>();

            MatchCollection matches = _trendRegex.Matches(input);

            //this uses the individual regex on each trend object and checks which one it is
            foreach (var match in matches.Cast<Match>())
            {
                if (_visRegex.IsMatch(match.Value))
                {
                    result.Add(GetVisibility(match.Value));
                }

                if (_weatherRegex.IsMatch(match.Value))
                {
                    result.Add(GetWeather(match.Value));
                }

                if (_windRegex.IsMatch(match.Value))
                {
                    result.Add(GetWind(match.Value));
                }

                if (_cloudRegex.IsMatch(match.Value))
                {
                    result.Add(GetCloud(match.Value));
                }
            }

            return result;
        }

        private static Visibility GetVisibility(string input) => ParseVisibility.ReturnVisibility(input, null);

        private static Weather GetWeather(string input) => WeatherFromTrend.Get(input);

        private static Wind GetWind(string input) => ParseWind.ReturnWind(input, null);

        private static Cloud GetCloud(string input) => ParseClouds.ReturnClouds(input).First();
    }
}
