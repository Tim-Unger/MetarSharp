
namespace MetarSharp.Tests.ReportingTime
{
    internal class ReportingTime
    {
        [Test]
        public void CheckReportingTime_ReturnsTrue()
        {
            Assert.That(MetarsParsed.All(x => x.ReportingTime.ReportingTimeRaw != null));
        }
    }
}
