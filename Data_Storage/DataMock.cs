using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Item_Type;

namespace Data_Storage
{
    public class DataMock
    {
       

        private static DataMock _data_base;
        public static DataMock DataBase
        {
            get
            {
                if (_data_base == null)
                    _data_base = new DataMock();
                return _data_base;
            }
        }

        public List<LibraryItem> LibraryItems { get; private set; }
        private DataMock()
        {
            LibraryItems = new List<LibraryItem>();
            Init();
        }

        private void Init()
        {
            
            Book.KnownPublishers.Add("Penguin english library");
            

            
          
            
            Book.KnownAuthors.Add("Jane Austen");
            Book.KnownAuthors.Add("Harper Lee");
            Book.KnownAuthors.Add("F. Scott Fitzgerald");

            Book.BookGenres.Add("Action and adventure");
            Book.BookGenres.Add("Art / architecture");
            Book.BookGenres.Add("Alternate history");
            Book.BookGenres.Add("Autobiography");
            Book.BookGenres.Add("Anthology");
            Book.BookGenres.Add("Biography");
            Book.BookGenres.Add("Chick lit");
            Book.BookGenres.Add("Business / economics");
            Book.BookGenres.Add("Children's");
            Book.BookGenres.Add("Crafts / hobbies");
            Book.BookGenres.Add("Classic");
            Book.BookGenres.Add("Cookbook");
            Book.BookGenres.Add("Comic book");
            Book.BookGenres.Add("Diary");
            Book.BookGenres.Add("Coming-of-age");
            Book.BookGenres.Add("Dictionary");
            Book.BookGenres.Add("Crime");
            Book.BookGenres.Add("Encyclopedia");
            Book.BookGenres.Add("Drama");
            Book.BookGenres.Add("Guide");
            Book.BookGenres.Add("Fairytale");
            Book.BookGenres.Add("Health / fitness");
            Book.BookGenres.Add("Fantasy");
            Book.BookGenres.Add("History");
            Book.BookGenres.Add("Graphic novel");
            Book.BookGenres.Add("Home and garden");
            Book.BookGenres.Add("Historical fiction");
            Book.BookGenres.Add("Humor");
            Book.BookGenres.Add("Horror");
            Book.BookGenres.Add("Journal");
            Book.BookGenres.Add("Mystery");
            Book.BookGenres.Add("Math");
            Book.BookGenres.Add("Paranormal romance");
            Book.BookGenres.Add("Memoir");
            Book.BookGenres.Add("Picture book");
            Book.BookGenres.Add("Philosophy");
            Book.BookGenres.Add("Poetry");
            Book.BookGenres.Add("Prayer");
            Book.BookGenres.Add("Political thriller");
            Book.BookGenres.Add("Religion, spirituality, and new age");
            Book.BookGenres.Add("Romance");
            Book.BookGenres.Add("Textbook");
            Book.BookGenres.Add("Satire");
            Book.BookGenres.Add("True crime");
            Book.BookGenres.Add("Science fiction");
            Book.BookGenres.Add("Review");
            Book.BookGenres.Add("Short story");
            Book.BookGenres.Add("Science");
            Book.BookGenres.Add("Suspense");
            Book.BookGenres.Add("Self help");
            Book.BookGenres.Add("Thriller");
            Book.BookGenres.Add("Sports and leisure");
            Book.BookGenres.Add("Western");
            Book.BookGenres.Add("Travel");
            Book.BookGenres.Add("Young adult");
            Book.BookGenres.Add("True crime");

            var book1 = new Book("Pride and Prejudice", new DateTime(2012, 6, 12), 39.37, 4);
            book1.Author.Add("Jane Austen");
            book1.Publisher.Add("Penguin english library");
            book1.Summary = "A lawyer's advice to his children as he defends the real mockingbird of Harper Lee's classic novel - a black man falsely charged with the rape of a white girl. Through the young eyes of Scout and Jem Finch, Harper Lee explores with exuberant humour the irrationality of adult attitudes to race and class in the Deep South of the 1930s. The conscience of a town steeped in prejudice, violence and hypocrisy is pricked by the stamina of one man's struggle for justice. But the weight of history will only tolerate so much.";
            book1.Genres.Add("Action and adventure");
            book1.Genres.Add("Classic");
            book1.Genres.Add("Drama");
            book1.Genres.Add("Historical fiction");
            
            

            var book2 = new Book("To Kill A Mockingbird", new DateTime(2015, 4, 6), 17.99);
            book2.Author.Add("Harper Lee");
            book2.Publisher.Add("Penguin english library");
            book2.Summary = "When Elizabeth Bennet first meets eligible bachelor Fitzwilliam Darcy, she thinks him arrogant and conceited; he is indifferent to her good looks and lively mind. When she later discovers that Darcy has involved himself in the troubled relationship between his friend Bingley and her beloved sister Jane, she is determined to dislike him more than ever. In the sparkling comedy of manners that follows, Jane Austen shows the folly of judging by first impressions and superbly evokes the friendships, gossip and snobberies of provincial middle-class life.";
            book2.Genres.Add("Young adult");
            book2.Genres.Add("Classic");
            book2.Genres.Add("Drama");
            book2.Genres.Add("Historical fiction");
           

            var book3 = new Book("The Great Gatsby", new DateTime(2000, 2, 24), 15.99);
            book3.Author.Add("F. Scott Fitzgerald");
            book3.Publisher.Add("Penguin english library");
            book3.Summary = "Young, handsome and fabulously rich, Jay Gatsby is the bright star of the Jazz Age, but as writer Nick Carraway is drawn into the decadent orbit of his Long Island mansion, where the party never seems to end, he finds himself faced by the mystery of Gatsby's origins and desires. Beneath the shimmering surface of his life, Gatsby is hiding a secret: a silent longing that can never be fulfilled. And soon, this destructive obsession will force his world to unravel.";
            book3.Genres.Add("Classic");
            book3.Genres.Add("Drama");
            book3.Genres.Add("Historical fiction");
           

            LibraryItems.AddRange(new[] { book1, book2, book3 });
        }
    }
}

