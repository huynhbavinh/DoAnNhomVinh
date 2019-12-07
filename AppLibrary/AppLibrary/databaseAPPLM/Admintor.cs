using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.databaseAPPLM
{
    public class Admintor
    {
        public BOOK[] getAllBook()
        { 
            var data = new myLMDBEntities();
            var allBook = data.BOOKs.ToArray();
            return allBook;
        }
        public BOOK getBook(int id)
        {
            var data = new myLMDBEntities();
            var oneBook = data.BOOKs.Find(id);
            return oneBook;
        }
        public bool checkUser(string code, string pass)
        {
            var data = new myLMDBEntities();
            var userAcc = data.customers.Find(code);
            var tempCode = userAcc.STUDENT_CODE;
            var tempPass = userAcc.password;
            if (code.Equals(tempCode))
            {
                if (pass.Equals(tempPass))
                {
                    return true;
                }
            }
            return false;
        }
        public customer profile(string code)
        {
            var data = new myLMDBEntities();
            var proUser = data.customers.Find(code);
            return proUser;
        }
        public BOOK[] searchingBook(string name)
        {
            var data = new myLMDBEntities();
            var books = data.BOOKs.Where(b => b.NAME == name).ToArray();
            return books;
        }
        public BOOK[] serchingAttribute(string author,int year)
        {
            var data = new myLMDBEntities();
            var books = data.BOOKs.Where(book => book.AUTHOR == author)
           // another way : ...&& book => book.year_relases == year
                                  .Where(b => b.YEAR_RELEASEED == year)
                                  .ToArray();
            return books;
        }

    }
}
