using ArticlesParser.Base;

namespace ArticlesParser.Habr
{
    public class HabrParserSettings
    {
        public HabrParserSettings(int start, int count)
        {
            Address = "https://habr.com/en/all/page&/";
            StartPage = start;
            Count = count;
        }

        public string Address { get; }
        public int StartPage { get; }
        public int Count { get; }
    }
}
