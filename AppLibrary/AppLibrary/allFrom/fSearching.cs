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
            this.Load += FSearching_Load;
        }

        private void FSearching_Load(object sender, EventArgs e)
        {
            this.cboTheLoai.DataSource = this.controller.getAllCategori();
            this.cboTheLoai.DisplayMember = "NAME";
            this.cboTheLoai.ValueMember = "ID";
        }
        private void searchCATEGORY()
        {
            try
            {
                var target = this.cboTheLoai.Text;
                var result = this.controller.searchingCATEGORY(target);
                var returnResult = new databaseAPPLM.BookView[result.Length];

                for (int i = 0; i < result.Length; i++)
                {
                    returnResult[i] = new databaseAPPLM.BookView(result[i]);
                }
                this.dataGridView1.DataSource = returnResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
           try
            { 
                if (this.dataGridView1.SelectedRows.Count == 1)
                {
                    var target = this.dataGridView1.SelectedRows[0];
                    var book_borrowing = (databaseAPPLM.BookView)target.DataBoundItem;
  
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
            try
            {
                var author = this.txtTacGia.Text.ToString();
                var year = this.txtyear.Text;
                if (author.Length != 0)
                {
                    if (year.Length != 0)
                    {
                        var yearINT = int.Parse(year);
                        var result = this.controller.serchingAttribute(author, yearINT);
                        var returnBook = new databaseAPPLM.BookView[result.Length];


                        for (int i = 0; i < result.Length; i++)
                        {
                            returnBook[i] = new databaseAPPLM.BookView(result[i]);
                        }
                        this.dataGridView1.DataSource = returnBook;
                    }
                    else
                    {
                        var r_author = this.controller.searchingAuthor(author);
                        var returnBook = new databaseAPPLM.BookView[r_author.Length];

                        for (int i = 0; i < r_author.Length; i++)
                        {
                            returnBook[i] = new databaseAPPLM.BookView(r_author[i]);
                        }
                        this.dataGridView1.DataSource = returnBook;

                    }
                }
                else
                {

                    var yearINT = int.Parse(this.txtyear.Text);
                    var r_years = this.controller.searchingYears(yearINT);
                    var returnBook = new databaseAPPLM.BookView[r_years.Length];

                    for (int i = 0; i < r_years.Length; i++)
                    {
                        returnBook[i] = new databaseAPPLM.BookView(r_years[i]);
                    }
                    this.dataGridView1.DataSource = returnBook;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void searchForName()
        {
            var name = this.txtName.Text;
            var result = controller.searchingBook(name);
            var returnBook = new databaseAPPLM.BookView[result.Length];

            for (int i = 0; i < result.Length; i++)
            {
                returnBook[i] = new databaseAPPLM.BookView(result[i]);
            }
            this.dataGridView1.DataSource = returnBook;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.check.Checked == true)
                {
                    this.searchCATEGORY();
                }
                else
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
            catch (Exception)
            {
                MessageBox.Show("Không hợp lệ");              
            }            
        }
    }
}
