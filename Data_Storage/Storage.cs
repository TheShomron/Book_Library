using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Item_Type;

namespace Data_Storage
{
    public class Storage : IStorage<LibraryItem>
    {
        private readonly DataMock _context = DataMock.DataBase;


        public LibraryItem Add(LibraryItem item)
        {
            _context.LibraryItems.Add(item);
            return item;
        }

        public LibraryItem Delete(Guid id)
        {
            var item = _context.LibraryItems.FirstOrDefault(i => i.Id == id);
            if (item != null)
                _context.LibraryItems.Remove(item);
            return item;
        }

        public IQueryable<LibraryItem> Get()
        {
            return _context.LibraryItems.AsQueryable();
        }

        public LibraryItem Get(Guid id)
        {
            return _context.LibraryItems.FirstOrDefault(i => i.Id == id);
        }

        public LibraryItem Update(LibraryItem item)
        {
            var old = _context.LibraryItems.FirstOrDefault(i => i.Id == item.Id);
            if (old != null)
            {
                _context.LibraryItems.Remove(old);
                _context.LibraryItems.Add(item);
            }
            return item;
        }


        public  void sort()
        {
            _context.LibraryItems.OrderBy(LibraryItem => LibraryItem.Price);
        }
      

       
    }
}
