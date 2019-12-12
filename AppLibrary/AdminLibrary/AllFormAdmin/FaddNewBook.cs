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
    public partial class FaddNewBook : Form
    {
        private AppLibrary.databaseAPPLM.Admintor controllerAdmin;
        public FaddNewBook()
        {
            this.controllerAdmin = new AppLibrary.databaseAPPLM.Admintor();
            InitializeComponent();
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.Load += FaddNewBook_Load;
        }
        private void load()
        {
            this.cboCategory.DataSource = this.controllerAdmin.getAllCategori();
            this.cboCategory.DisplayMember = "NAME";           
        }

        private void FaddNewBook_Load(object sender, EventArgs e)
        {
            this.load();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var name = this.txtName.Text;
            var author = this.txtAuthor.Text;
            var cate = this.cboCategory.Text;
            var year = int.Parse(this.txtYear.Text);
            this.controllerAdmin.AddNewBook(cate, name, author, year);
            MessageBox.Show("Add Successfully");
        }
    }
}
