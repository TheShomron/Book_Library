using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_Type
{
    public class Book : LibraryItem, IFormattable
    {
        

        
        public static List<string> BookGenres = new List<string>();
    
        public static List<string> KnownAuthors = new List<string>();

        public static List<string> KnownPublishers = new List<string>();



        public  List<string> Publisher { get;private set; } 

        public List<string> Author { get; private set; }

        public List<string> Genres { get; private set; }

        


        public string Summary { get; set; }


        public Book(string title, DateTime publishDate, double price, 
            int quantity = 1 )
            : base(title, publishDate ,price ,quantity)
        {
           
            Author = new List<string>();
            Genres = new List<string>();
            Publisher = new List<string>();
        }

        public override string ToString()
        {
            return base.ToString() + $"| Author: {string.Join("|",Author)}\t" +
                $"\n----------------------------------------------------------------------------------------------------------------------";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "Auther":
                    return $"{string.Join("|", Author)}";
                case "Publisher":
                    return $"{string.Join("|", Publisher)}";
                case "Genre":
                    return $"{string.Join("|", Genres[0])}";
                default:
                    return this.ToString();
            }
        }
    }
}
