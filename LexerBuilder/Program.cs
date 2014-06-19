using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scraper.NBA.BBR.Parser;
using Antlr4.Runtime;
using System.IO;

namespace LexerBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            //BBR.ScraperWriter writer = new BBR.ScraperWriter();

            //writer.write();
            Console.BufferHeight = Int16.MaxValue - 1;
            string inputPath = @"D:\Anthony\Documents\Research\New Raw Data\2013-2014 Regular Season\";
            IEnumerable<string> filePaths = Directory.GetFiles(inputPath);

            IEnumerable<String> uniqueStrs = new List<String>();
            foreach (string path in filePaths)
            {
                using (System.IO.FileStream file = System.IO.File.Open(path, System.IO.FileMode.Open))
                {
                    AntlrInputStream stream = new AntlrInputStream(file);
                    BBRPBPLexer lexer = new BBRPBPLexer(stream);
                    CommonTokenStream tokens = new CommonTokenStream(lexer);

                    tokens.Fill();
                    IList<IToken> allTokens = tokens.GetTokens();
                    var temp = allTokens.Where(t => t.Type == 45)
                                              .Select(t => t.Text)
                                              .Distinct();

                    uniqueStrs = uniqueStrs.Union(temp);

                }

                
            }

            using (StreamWriter outfile = new StreamWriter(inputPath + "words.txt"))
            {
                uniqueStrs.ToList().ForEach(s => outfile.WriteLine(s));
            }
            

        }
    }
}
