using ArticlesParser.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesParser.MsDevBlog
{
    public class DevsBlogParserSettings : BaseSettings
    {
        public DevsBlogParserSettings(int start = 1, int count = 1) : base("https://devblogs.microsoft.com/page/&/", start, count)
        {
        }
    }
}
