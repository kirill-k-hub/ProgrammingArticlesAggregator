using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesParser.unetway.Models
{
    public class UnetwayArticle
    {
        public UnetwayArticle(string name, Uri link, string authorNickname, DateTime publicationDate)
        {
            Name = name;
            Link = link;
            AuthorNickname = authorNickname;
            PublicationDate = publicationDate;
        }

        #region Properties
        public string Name { get; }
        public Uri Link { get; }
        public string AuthorNickname { get; }
        public DateTime PublicationDate { get; }
        #endregion
    }
}
