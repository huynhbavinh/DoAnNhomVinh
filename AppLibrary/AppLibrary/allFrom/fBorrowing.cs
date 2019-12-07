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
            this.dateStart.ValueChanged += DateStart_ValueChanged;
            this.btnCancel.Click += BtnCancel_Click;
            this.btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var code = this.txtCode.Text;
            var name = this.txtBook.Text;
            var start = this.dateStart.Value;
            var end = this.dateEnd.Value;
            controller.AddHistory(code, name, start, end);
            MessageBox.Show("Mượn thành công");
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DateStart_ValueChanged(object sender, EventArgs e)
        {
            this.dateEnd.Value = this.dateStart.Value.AddDays(7);
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
