using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLibrary.databaseAPPLM;

namespace AdminLibrary.databasee
{
    class AddminFunction
    {
        public AppLibrary.databaseAPPLM.History[] getALLHistories()
        {
            var data = new AppLibrary.databaseAPPLM.myLMDBEntities();
            var myHistory = data.Histories.ToArray();
            return myHistory;
        }
    }
}
