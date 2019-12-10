using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.databaseAPPLM
{
    public class BookView
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string CATEGORY_BOOK { get; set; }
        public string AUTHOR { get; set; }
        public int YEAR_RELEASEED { get; set; }
        
        public BookView(BOOK book)
        {
            this.ID = book.ID;
            this.NAME = book.NAME;
            this.CATEGORY_BOOK = book.CATEGORY.NAME;
            this.AUTHOR = book.AUTHOR;
            this.YEAR_RELEASEED = book.YEAR_RELEASEED;
        }
    }
}
