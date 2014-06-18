using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using System.IO;
using Scraper;
using Scraper.NBA.BBR.Linker;

namespace ScraperTest.BBR.Linker
{
    [TestFixture]
    class BBRLinkerTest
    {
        private BBRLinker _linky;
        private DateTime _testStartDate;
        private DateTime _testEndDate;
        private Mock<IBBRLinkParser> _mockLinkParser;

        [Test]
        public void Check_Downloading_For_A_Single_Day_Works()
        {
            _testStartDate = new DateTime(2014, 3, 11);
            _mockLinkParser = new Mock<IBBRLinkParser>();
            _linky = new BBRLinker(_testStartDate, _testStartDate, _mockLinkParser.Object);

            _mockLinkParser.Setup(lp => lp.ParseString(It.IsAny<String>()))
                           .Returns(new List<Link>() {new Link(LinkType.PlayByPlay, "test")});

            var testData = _linky.GetLinks();

            Assert.AreEqual(testData.Count(), 1);
            _mockLinkParser.Verify(lp => lp.ParseString(It.IsAny<String>()), Times.Once);
        }

        [Test]
        public void Check_Downloading_For_Several_Days_Works()
        {
            _testStartDate = new DateTime(2014, 3, 11);
            _testEndDate = new DateTime(2014, 3, 15);
            var _dayDiff = Convert.ToInt32((_testEndDate - _testStartDate).TotalDays) + 1;
            _mockLinkParser = new Mock<IBBRLinkParser>();
            _linky = new BBRLinker(_testStartDate, _testEndDate, _mockLinkParser.Object);

            _mockLinkParser.Setup(lp => lp.ParseString(It.IsAny<String>()))
                           .Returns(new List<Link>() { new Link(LinkType.PlayByPlay, "test") });

            var testData = _linky.GetLinks();

            Assert.AreEqual(testData.Count(), _dayDiff);
            _mockLinkParser.Verify(lp => lp.ParseString(It.IsAny<String>()), Times.Exactly(_dayDiff));
        }
    }
}
