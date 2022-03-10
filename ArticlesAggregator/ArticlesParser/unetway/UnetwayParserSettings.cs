using ArticlesParser.Base;

namespace ArticlesParser.unetway
{
    public class UnetwayParserSettings : BaseSettings
    {
        public UnetwayParserSettings(int start = 1, int count = 1) : base("https://unetway.com/blog?page=&/", start, count)
        {
        }
    }
}