namespace MetarSharp.Parse
{
    internal class Months
    {
        /// <summary>
        /// This removes the given number of months from the current UTC-DateTime and returns the Month of the DateTime
        /// Will throw if you use a negative number
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        internal static int Remove(int months) =>
            months > 0
                ? DateTime.UtcNow.AddMonths(-months).Month
                : throw new ParseException("Please use a posotive number");
    }
}
