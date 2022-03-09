namespace ArticlesParser.unetway
{
    public class UnetwayParserSettings
    {
        public UnetwayParserSettings(int start, int count)
        {
            Address = "https://unetway.com/blog?page=&/";
            StartPage = start;
            Count = count;
        }

        public string Address { get; }
        public int StartPage { get; }
        public int Count { get; }
    }
}