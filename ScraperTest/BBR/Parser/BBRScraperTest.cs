using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Scraper.NBA.BBR.Parser.PBP;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ScraperTest.BBR.Parser
{
    class BBRScraperTest
    {

        [Test]
        public void FindTextNodes()
        {
            String path = @"D:\Anthony\Dropbox\NBA Final\BBR PBP\2013-2014\";

            foreach (string fileName in Directory.GetFiles(path))
            {
                //does filename need to be combined with path
                using (System.IO.FileStream file = System.IO.File.Open(fileName, System.IO.FileMode.Open))
                {
                    var inputStream = new AntlrInputStream(file);
                    BBRPBPLexer lexer = new BBRPBPLexer(inputStream);
                    var tokenStream = new CommonTokenStream(lexer);
                    var parser = new BBRPBPParser(tokenStream);
                    IParseTree tree = parser.game();
                    //how to parse text nodes from tree?
                }
            }
        }

        [Test]
        public void FindErrorNodes()
        {
            String path = @"D:\Anthony\Dropbox\NBA Final\BBR PBP\2013-2014\";

            foreach (string fileName in Directory.GetFiles(path))
            {
                using (System.IO.FileStream file = System.IO.File.Open(fileName, System.IO.FileMode.Open))
                {
                    var inputStream = new AntlrInputStream(file);
                    var lexer = new BBRPBPLexer(inputStream);
                    var tokenStream = new CommonTokenStream(lexer);
                    var parser = new BBRPBPParser(tokenStream);
                    IParseTree tree = parser.game();
                    //Console.Out.Write(scraper.Scrape(file).Aggregate((x, y) => x + "\n" + y));
                }
            }

        }
    }
}
