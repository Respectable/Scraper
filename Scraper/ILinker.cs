using System;
using System.Collections.Generic;

namespace Scraper
{
    public interface ILinker
    {
        IEnumerable<String> GetLinks();
    }
}
