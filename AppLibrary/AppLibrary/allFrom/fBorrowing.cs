using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLibrary.allFrom
{
    public partial class fBorrowing : Form
    {
        private databaseAPPLM.Admintor controller;
        private int id_book;
        public fBorrowing(int id)
        {
            this.controller = new databaseAPPLM.Admintor();
            this.id_book = id;
            InitializeComponent();
            this.Load += FBorrowing_Load;
        }

        private void FBorrowing_Load(object sender, EventArgs e)
        {
            var book_need = controller.getBook(this.id_book);
            this.txtCode.Text = allFrom.loginForm.codeIDuser;
            this.txtBook.Text = book_need.NAME;
            this.dateStart.Value = System.DateTime.Now;
            this.dateEnd.Value = this.dateStart.Value.AddDays(7);
        }
    }
}
