using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesParser.MsDevBlog
{
    public class DevsBlogParserSettings
    {
        public DevsBlogParserSettings(int start, int count)
        {
            Address = "https://devblogs.microsoft.com/page/&/";
            StartPage = start;
            Count = count;
        }

        public string Address { get; }
        public int StartPage { get; }
        public int Count { get; }
    }
}
