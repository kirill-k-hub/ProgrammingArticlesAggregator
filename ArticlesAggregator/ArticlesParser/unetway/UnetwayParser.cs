using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using ArticlesParser.unetway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesParser.unetway
{
    public class UnetwayParser
    {
        private static HttpClient client;

        static UnetwayParser()
        {
            client = new HttpClient();
        }

        public async Task<List<UnetwayArticle>> Parse(UnetwayParserSettings settings)
        {
            List<UnetwayArticle> articles = new List<UnetwayArticle>();

            List<IHtmlDocument> docs = await GetDocs(settings);
            List<IElement> namesLinks = new List<IElement>(),
                dates = new List<IElement>(),
                usernames = new List<IElement>();

            foreach (var doc in docs)
            {
                namesLinks.AddRange(doc.QuerySelectorAll("header.post-header"));
                dates.AddRange(doc.QuerySelectorAll("span.post-date-create"));
                usernames.AddRange(doc.QuerySelectorAll("span.post-user-link"));

                for (int i = 0; i < namesLinks.Count; i++)
                {
                    articles.Add(new UnetwayArticle(namesLinks[i].Children.First().Children.First().TextContent,
                        new Uri(namesLinks[i].Children.First().Children.First().GetAttribute("href")), 
                        usernames[i].Children.Last().TextContent.Trim(), DateTime.Parse(dates[i].TextContent.Trim())));
                }
            }

            return articles;
        }

        private async Task<List<IHtmlDocument>> GetDocs(UnetwayParserSettings settings)
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
