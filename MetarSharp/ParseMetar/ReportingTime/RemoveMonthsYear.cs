namespace MetarSharp.Parse
{
    internal class Year
    {
        /// <summary>
        /// This removes the given number of months from the current UTC-DateTime and returns the year of the DateTime
        /// Will throw if you use a negative number
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        internal static int RemoveMonths(int months) =>
            months > 0
                ? DateTime.UtcNow.AddMonths(-months).Year
                : throw new ParseException("Please use a posotive number");
    }
}
