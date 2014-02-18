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
        private DataFileOptions _options;
        private const string Url = "www.basketball-reference.com/boxscores/index.cgi?month={0}&day={1}&year={2}";

        //TODO
        public bool IncludePreSeason { get; set; }
        public bool IncludePostSeason { get; set; }

        public BBRLinker(DateTime start, DateTime end, DataFileOptions options)
        {
            _startDate = start;
            _endDate = end;
            _options = options;
            IncludePreSeason = false;
            IncludePostSeason = false;
        }

        public IEnumerable<string> GetLinks()
        {
            List<string> links = new List<string>();
            DateTime currentDateTime = _startDate;

            while (!currentDateTime.Equals(_endDate))
            {
                links.AddRange(GetDateLinks(currentDateTime));
                currentDateTime = currentDateTime.AddDays(1);
            }

            return links;
        }

        private IEnumerable<string> GetDateLinks(DateTime date)
        {
            WebRequest request = WebRequest.Create(String.Format(Url, date.Month, date.Day, date.Year));
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = String.Empty;
            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
            }
        }
    }
}
