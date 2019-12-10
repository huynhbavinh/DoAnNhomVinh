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
            //var books = data.BOOKs.Where(book => book.AUTHOR == author)
            //another way : ...&& book => book.year_relases == year
            //                      .Where(b => b.YEAR_RELEASEED == year)
            //                      .ToArray();

            var r1 = data.BOOKs.Where(book1 => book1.AUTHOR == author).ToArray();
            var r2 = data.BOOKs.Where(book2 => book2.YEAR_RELEASEED == year).ToArray();
            var uni = r1.Union(r2).ToArray();
            return uni;
        }
        public void AddHistory(string code,string name,DateTime dateStart ,DateTime dateEnd)
        {
            var newHistory = new History();
            newHistory.name = name;
            newHistory.code = code;
            newHistory.date_start = dateStart;
            newHistory.date_end = dateEnd;

            var data = new myLMDBEntities();
            data.Histories.Add(newHistory);
            data.SaveChanges();
        }
        public History[] getAllHistory()
        {
            var data = new myLMDBEntities();
            var myHistory = data.Histories.ToArray();
            return myHistory;
        }
        public CATEGORY[] getAllCategori()
        {
            var data = new myLMDBEntities();
            var myCollection = data.CATEGORies.ToArray();
            return myCollection;

        }
        public BOOK[] searchingCATEGORY(string target)
        {
            var data = new myLMDBEntities();
            var result = data.BOOKs.Where(b => b.CATEGORY_BOOK == target).ToArray();
            return result;
        }
    }
}
