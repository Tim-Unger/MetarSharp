using static MetarSharp.Extensions.TryParseExtensions;

namespace MetarSharp.Parse
{
    internal class VerticalVisibility
    {
        internal static (string, bool, int?) Get(GroupCollection groups)
        {
            var verticalVisibilityRaw = groups[4].Value + groups[5].Value;

            var isVerticalVisibilityMeasurable = groups[5].Value != "///";

            int? verticalVisibility = null;
            if (isVerticalVisibilityMeasurable)
            {
                verticalVisibility = IntTryParseWithThrow(groups[5].Value) * 100;
            }

            return (verticalVisibilityRaw, isVerticalVisibilityMeasurable, verticalVisibility);
        }
    }
}
