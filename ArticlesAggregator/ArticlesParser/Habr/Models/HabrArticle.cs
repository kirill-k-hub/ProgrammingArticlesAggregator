using ArticlesParser.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesParser.Habr.Models
{
    public sealed class HabrArticle : BaseModel
    {
        public HabrArticle(string name, Uri link, string authorNickname, DateTime publicationDate)
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
