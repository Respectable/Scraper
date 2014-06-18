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
            BBR.ScraperWriter writer = new BBR.ScraperWriter();

            writer.write();
            //IEnumerable<String> uniqueStrs;
            //foreach (string arg in args)
            //{
            //    using (System.IO.FileStream file = System.IO.File.Open(arg, System.IO.FileMode.Open))
            //    {
            //        AntlrInputStream stream = new AntlrInputStream(file);
            //        BBRPBPLexer lexer = new BBRPBPLexer(stream);
            //        CommonTokenStream tokens = new CommonTokenStream(lexer);

            //        tokens.Fill();
            //        IList<IToken> allTokens = tokens.GetTokens();
            //        uniqueStrs = allTokens.Where(t => t.Type == 45)
            //                                  .Select(t => t.Text)
            //                                  .Distinct();
                    
            //    }

            //    using (StreamWriter outfile = new StreamWriter(arg + "words.txt"))
            //    {
            //        uniqueStrs.ToList().ForEach(s => outfile.WriteLine(s));
            //    }
            //}
            

        }
    }
}
