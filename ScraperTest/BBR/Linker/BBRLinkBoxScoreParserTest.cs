using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Scraper.NBA.BBR.Linker;
using System.IO;
using System.Reflection;

namespace ScraperTest.BBR.Linker
{
    [TestFixture]
    class BBRLinkBoxScoreParserTest
    {
        private BBRLinkBoxScoreParser _testParser;
        private string _testText;

        [SetUp]
        public void Init()
        {
            _testParser = new BBRLinkBoxScoreParser();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "ScraperTest.BBR.Linker.testHTML.html";

            using (Stream s = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader sr = new StreamReader(s))
            {
                _testText = sr.ReadToEnd();
            }
        }

        [Test]
        public void PBP_Link_Parser_Parses_Links_Correctly()
        {
            var links = _testParser.ParseString(_testText);
            links.ToList().ForEach(l => Console.WriteLine(l.LinkPath));
            Assert.True(links.Select(l => l.LinkPath).Contains(@"www.basketball-reference.com/boxscores/201403110CHI.html"));
            Assert.True(links.Select(l => l.LinkPath).Contains(@"www.basketball-reference.com/boxscores/201403110DET.html"));
            Assert.True(links.Select(l => l.LinkPath).Contains(@"www.basketball-reference.com/boxscores/201403110GSW.html"));
            Assert.True(links.Select(l => l.LinkPath).Contains(@"www.basketball-reference.com/boxscores/201403110IND.html"));
            Assert.True(links.Select(l => l.LinkPath).Contains(@"www.basketball-reference.com/boxscores/201403110MEM.html"));
            Assert.True(links.Select(l => l.LinkPath).Contains(@"www.basketball-reference.com/boxscores/201403110MIN.html"));
            Assert.True(links.Select(l => l.LinkPath).Contains(@"www.basketball-reference.com/boxscores/201403110OKC.html"));
            Assert.AreEqual(links.Count(), 7);
        }
    }
}
