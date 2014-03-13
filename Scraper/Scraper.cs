using System;
using System.Collections.Generic;
using System.IO;

namespace Scraper
{
    public class Scraper<T>
    {
        private readonly ILinker _linker;
        private readonly IParser<T> _parser;
        private readonly IWriter<T> _writer;

        public Scraper(ILinker linker, IParser<T> parser, IWriter<T> writer)
        {
            if (linker == null ||
                parser == null ||
                writer == null ) throw new ArgumentNullException();
            _linker = linker;
            _parser = parser;
            _writer = writer;
        }

        public void Scrape()
        {
            IEnumerable<Link> links = _linker.GetLinks();
            foreach (Link link in links)
            {
                _writer.Write(_parser.Parse(link));
            }
        }
    }
}