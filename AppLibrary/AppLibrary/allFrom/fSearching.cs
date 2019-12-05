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
        }
        private void searchForAttribute()
        {
            var year = int.Parse(this.txtYear.Text);
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
