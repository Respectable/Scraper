using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using System.IO;

namespace Throwaway
{
    class Program
    {
        static void Main(string[] args)
        {

            string inputPath = @"D:\Anthony\Desktop\TestGrammar.txt";

            using (System.IO.FileStream file = System.IO.File.Open(inputPath, System.IO.FileMode.Open))
            {
                AntlrInputStream stream = new AntlrInputStream(file);
                Lexer1 lexer = new Lexer1(stream);
                CommonTokenStream tokens = new CommonTokenStream(lexer);

                tokens.Fill();
                IList<IToken> allTokens = tokens.GetTokens();
                var temp = allTokens.Where(t => t.Type == 45)
                                          .Select(t => t.Text)
                                          .Distinct();
            }
        }
    }
}
