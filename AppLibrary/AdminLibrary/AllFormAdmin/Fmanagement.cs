using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLibrary.databaseAPPLM;

namespace AdminLibrary.AllFormAdmin
{
    public partial class Fmanagement : Form
    {
        private AppLibrary.databaseAPPLM.Admintor controllerAdmin;
        public Fmanagement()
        {
            this.controllerAdmin = new AppLibrary.databaseAPPLM.Admintor();
            InitializeComponent();
            this.Load += Fmanagement_Load;
            this.MenuADD.Click += MenuADD_Click;
        }

        private void MenuADD_Click(object sender, EventArgs e)
        {
            (new FaddNewBook()).ShowDialog();
        }

        private void load()
        {
            var result = this.controllerAdmin.getAllHistory();
            this.dataGridView1.DataSource = result;
        }

        private void Fmanagement_Load(object sender, EventArgs e)
        {
            this.load();
        }
    }
}
