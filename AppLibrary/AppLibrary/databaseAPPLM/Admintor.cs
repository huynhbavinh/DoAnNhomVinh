using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.databaseAPPLM
{
    public class Admintor
    {
        public string userLogin = "" ;
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
            userLogin += userAcc.STUDENT_CODE;
            if (code.Equals(tempCode))
            {
                if (pass.Equals(tempPass))
                {
                    return true;
                }
            }
            return false;
        }
        public customer profile()
        {

            var id = userLogin;
            var data = new myLMDBEntities();
            var proUser = data.customers.Find(id);
            return proUser;
        }
    }
}
