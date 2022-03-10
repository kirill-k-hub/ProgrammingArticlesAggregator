using ArticlesParser.Base;

namespace ArticlesParser.Habr
{
    public class HabrParserSettings : BaseSettings
    {
        public HabrParserSettings(int start = 1, int count = 1) : base("https://habr.com/en/all/page&/", start, count)
        {
        }
    }
}
