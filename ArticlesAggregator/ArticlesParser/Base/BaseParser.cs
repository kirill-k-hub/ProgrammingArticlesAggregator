using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArticlesParser.Base
{
    public abstract class BaseParser<T, S> where S : BaseSettings
    {
        protected internal readonly static HttpClient client;

        static BaseParser()
        {
            client = new HttpClient();
        }

        public abstract Task<List<T>> Parse(S settings);
        protected abstract T CreateArticle(string name, string uri, string authorName, DateTime publicationDate);

        protected async Task<List<IHtmlDocument>> GetDocs(S settings)
        {
            List<IHtmlDocument> docs = new List<IHtmlDocument>();
            HtmlParser parser = new HtmlParser();

            for (int i = settings.StartPage; i < settings.StartPage + settings.Count; i++)
            {
                docs.Add(
                    await parser.ParseDocumentAsync(
                        await client.GetStringAsync(settings.Address.Replace("&", i.ToString()))
                    )
                );
            }

            return docs;
        }
    }
}
