using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using ArticlesParser.MsDevBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesParser.MsDevBlog
{
    public class DevsBlogParser
    {
        private static HttpClient client;

        static DevsBlogParser()
        {
            client = new HttpClient();
        }

        public async Task<List<DevsBlogArticle>> Parse(DevsBlogParserSettings settings)
        {
            List<DevsBlogArticle> articles = new List<DevsBlogArticle>();

            List<IHtmlDocument> docs = await GetDocs(settings);
            List<IElement> namesLinks = new List<IElement>(),
                dates = new List<IElement>(),
                usernames = new List<IElement>();

            foreach (var doc in docs)
            {
                namesLinks.AddRange(doc.QuerySelectorAll("h5.entry-title"));
                dates.AddRange(doc.QuerySelectorAll("span.entry-post-date-mini"));
                usernames.AddRange(doc.QuerySelectorAll("span.entry-author-link"));

                for (int i = 0; i < namesLinks.Count; i++)
                {
                    articles.Add(new DevsBlogArticle(namesLinks[i].Children.First().TextContent.Trim(),
                        new Uri(namesLinks[i].Children.First().GetAttribute("href")),
                        usernames[i].Children.First().TextContent.Trim(),
                        DateTime.Parse(dates[i].TextContent.Trim())
                    ));
                }
            }

            return articles;
        }

        private async Task<List<IHtmlDocument>> GetDocs(DevsBlogParserSettings settings)
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
