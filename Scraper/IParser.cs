using System.Collections.Generic;
using System.IO;

namespace Scraper
{
    public interface IParser<T>
    {
        T Parse(Link link);
    }
}
