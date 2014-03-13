using Scraper.NBA.BBR.Linker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.BBR.Linker
{
    class BBRLinker : ILinker
    {
        private DateTime _startDate;
        private DateTime _endDate;
        //PBP, Shots, or Box
        private IBBRLinkParser _parser;
        private const string Url = "www.basketball-reference.com/boxscores/index.cgi?month={0}&day={1}&year={2}";

        //TODO
        //public bool IncludePreSeason { get; set; }
        //public bool IncludePostSeason { get; set; }

        public BBRLinker(DateTime start, DateTime end, IBBRLinkParser parser)
        {
            _startDate = start;
            _endDate = end;
            _parser = parser;
            //IncludePreSeason = false;
            //IncludePostSeason = false;
        }

        public IEnumerable<Link> GetLinks()
        {
            return GetLinks(new List<Link>(), _startDate);
        }

        //inclusive of endDate
        private IEnumerable<Link> GetLinks(IEnumerable<Link> links, DateTime currentDateTime)
        {
            var newLinks = GetDateLinks(currentDateTime);

            if (currentDateTime.Equals(_endDate))
                return links.Concat(newLinks);
            else
                return GetLinks(links.Concat(newLinks), currentDateTime.AddDays(1));
        }

        private IEnumerable<Link> GetDateLinks(DateTime date)
        {
            WebRequest request = WebRequest.Create(String.Format(Url, date.Month, date.Day, date.Year));
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = String.Empty;
            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
            }

            return _parser.ParseString(html);
        }
    }
}
