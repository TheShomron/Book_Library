using   Product_Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class DataMock
    {
        public List<LibraryItem> LibraryItems { get; private set; }

        public DataMock()
        {
            LibraryItems = new List<LibraryItem>() ;
            Init();
        }

        private void Init()
        {

        }
    }
}
