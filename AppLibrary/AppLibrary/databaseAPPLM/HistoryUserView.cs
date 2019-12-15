using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.databaseAPPLM
{
    public class HistoryUserView
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public System.DateTime date_start { get; set; }
        public System.DateTime date_end { get; set; }
        public HistoryUserView(History history)
        {
            this.id = history.id;
            this.code = history.code;
            this.name = history.name;
            this.date_start = history.date_start;
            this.date_end = history.date_end;
        }
    }
}
