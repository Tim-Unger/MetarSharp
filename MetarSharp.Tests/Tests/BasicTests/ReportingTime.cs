
namespace MetarSharp.Tests.Tests.BasicTests
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
