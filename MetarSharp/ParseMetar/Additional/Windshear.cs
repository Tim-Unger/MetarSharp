namepace MetarSharp.Parse.Windshear
{
    internal class WindshearParse
    {
        internal static WindShear Parse(GroupCollection groups)
        {
            WindShear wind = new WindShear();

                wind.WindShearRaw = groups[5].Value;

                if (groups[7].Value == "ALL RWY")
                {
                    wind.IsAllRunways = true;

                    wind.Runway = null;
                    windShear.Add(wind);

                    return wind;
                }
            
            wind.IsAllRunways = false;

            //TODO parallel runways

            if (int.TryParse(groups[9].Value, out int Runway))
            {
                wind.Runway = Runway;
            }
            wind.Runway = int.TryParse(groups[9].Value, out int runway) ? runway : throw new Exception("Could not read Runway");

        }
    }
}