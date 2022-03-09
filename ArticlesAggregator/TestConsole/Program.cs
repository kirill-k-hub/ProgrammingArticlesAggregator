using ArticlesParser.Habr;
using ArticlesParser.Habr.Models;
using ArticlesParser.MsDevBlog;
using ArticlesParser.MsDevBlog.Models;
using ArticlesParser.unetway;
using ArticlesParser.unetway.Models;
using System;
using System.Collections.Generic;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<HabrArticle> articles = new List<HabrArticle>();

            //HabrParser parser = new HabrParser();
            //HabrParserSettings settings = new HabrParserSettings(3, 1);

            //var result = parser.Parse(settings).Result;

            //foreach (var article in result)
            //{
            //    Console.WriteLine(article.Name + " : " + article.Link);
            //}

            //List<DevsBlogArticle> articles = new List<DevsBlogArticle>();

            //MsDevsBlogParser parser = new MsDevsBlogParser();
            //DevsBlogParserSettings settings = new DevsBlogParserSettings(1, 1);

            //var result = parser.Parse(settings).Result;

            //foreach (var article in result)
            //{
            //    Console.WriteLine(article.Name + " : " + article.Link);
            //}

            List<UnetwayArticle> articles = new List<UnetwayArticle>();

            UnetwayParser parser = new UnetwayParser();
            UnetwayParserSettings settings = new UnetwayParserSettings(1, 1);

            var result = parser.Parse(settings).Result;

            foreach (var article in result)
            {
                Console.WriteLine(article.Name + " - " + article.AuthorNickname + " : " + article.PublicationDate);
            }
        }
    }
}
