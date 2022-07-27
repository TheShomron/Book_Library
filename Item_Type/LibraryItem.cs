using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_Type
{
    public abstract class LibraryItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public bool IsBorrowed;

        public LibraryItem(string title, DateTime publishDate , double price ,int quantity)
        {
            Id = Guid.NewGuid();
            this.Title=title;
            this.PublishDate=publishDate;
            Price = price;
            Quantity = quantity;
            IsBorrowed= false;
        }


        public override string ToString()
        {
            return $"Title: {Title} | Publish Date: {PublishDate:d} | Price: {Price:C} | Quantity: {Quantity} ";
        }
    }
}
