using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Type
{
    internal class Book : LibraryItem
    {
        public ISBN ISBN { get; private set; }
        public List<string> Authors { get; set; }

        public Book(string title, DateTime publishDate) : base(title, publishDate)
        {

        }
    }
}
