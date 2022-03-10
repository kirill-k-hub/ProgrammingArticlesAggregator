using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesParser.Base
{
    public abstract class BaseSettings
    {
        public BaseSettings(string address, int start, int count)
        {
            if (start <= 0 || count <= 0)
                throw new ArgumentException("Argument can't be equal or less than 0.");

            Address = address;
            StartPage = start;
            Count = count;
        }

        public string Address { get; }
        public int StartPage { get; }
        public int Count { get; }
    }
}
