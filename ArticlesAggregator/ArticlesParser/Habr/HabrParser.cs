using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using ArticlesParser.Habr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesParser.Habr
{
    public sealed class HabrParser
    {
        private static HttpClient client;

        static HabrParser()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// Продумать как будет работать парсер, разобрать ошибки с получением данных.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task<List<HabrArticle>> Parse(HabrParserSettings settings)
        {
            List<HabrArticle> articles = new List<HabrArticle>();

            List<IHtmlDocument> docs = await GetDocs(settings);
            List<IElement> namesLinks = new List<IElement>(),
                dates = new List<IElement>(),
                usernames = new List<IElement>();

            foreach (var doc in docs)
            {
                namesLinks.AddRange(doc.QuerySelectorAll("a.tm-article-snippet__title-link"));
                dates.AddRange(doc.QuerySelectorAll("span.tm-article-snippet__datetime-published"));
                usernames.AddRange(doc.QuerySelectorAll("a.tm-user-info__username"));

                for (int i = 0; i < namesLinks.Count; i++)
                {
                    articles.Add(new HabrArticle(namesLinks[i].Children.First().TextContent,
                        new Uri("https://habr.com" + namesLinks[i].GetAttribute("href")),
                        usernames[i].TextContent,
                        DateTime.Parse(dates[i].Children.First().GetAttribute("datetime"))
                    ));
                }
            }

            return articles;
        }

        /// <summary>
        /// Получение списка страниц со статьями.
        /// </summary>
        /// <param name="settings">Настройки</param>
        /// <returns></returns>
        private async Task<List<IHtmlDocument>> GetDocs(HabrParserSettings settings)
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
