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
    public partial class fSearching : Form
    {
        private databaseAPPLM.Admintor controller;
        public fSearching()
        {
            this.controller = new databaseAPPLM.Admintor();
            InitializeComponent();
            this.btnSearch.Click += BtnSearch_Click;
            this.dataGridView1.DoubleClick += DataGridView1_DoubleClick;
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
           try
            { 
                if (this.dataGridView1.SelectedRows.Count == 1)
                {
                    var target = this.dataGridView1.SelectedRows[0];
                    var book_borrowing = (databaseAPPLM.BOOK)target.DataBoundItem;
                    (new fBorrowing(book_borrowing.ID)).ShowDialog(); 
                }
            }
            catch (Exception)
           {
                throw;
           }
        }

        private void searchForAttribute()
        {
            var year = int.Parse(this.txtyear.Text);
            this.dataGridView1.DataSource = this.controller.serchingAttribute(this.txtTacGia.Text,year);
        }
        private void searchForName()
        {
            var name = this.txtName.Text;
            this.dataGridView1.DataSource = controller.searchingBook(name);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                this.searchForName();
            }
            else
            {
                this.searchForAttribute();
            }
        }
    }
}
