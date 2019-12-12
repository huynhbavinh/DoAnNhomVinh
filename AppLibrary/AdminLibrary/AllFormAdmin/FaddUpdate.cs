using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminLibrary.AllFormAdmin
{
    public partial class FaddUpdate : Form
    {
        AppLibrary.databaseAPPLM.Admintor controllerAdmin;
        private int temp;
        public FaddUpdate(int id)
        {
            this.temp = id;
            this.controllerAdmin = new AppLibrary.databaseAPPLM.Admintor();
            InitializeComponent();
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.Load += FaddUpdate_Load;
        }

        private void FaddUpdate_Load(object sender, EventArgs e)
        {
            var oldBook = this.controllerAdmin.getBook(this.temp);
            this.txtName.Text = oldBook.NAME;
            this.txtAuthor.Text = oldBook.AUTHOR;
            this.txtYear.Text = oldBook.YEAR_RELEASEED.ToString();
            this.cboCategory.ValueMember = "NAME";
            this.cboCategory.DisplayMember = "NAME";

            this.cboCategory.SelectedValue = oldBook.CATEGORY_BOOK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var name = this.txtName.Text;
            var author = this.txtAuthor.Text;
            var category = this.cboCategory.Text;
            var year = int.Parse(this.txtYear.Text);
           
            this.controllerAdmin.UpdateBook(this.temp,category, name, author, year);
            MessageBox.Show("Update Successfully");
        }
    }
}
