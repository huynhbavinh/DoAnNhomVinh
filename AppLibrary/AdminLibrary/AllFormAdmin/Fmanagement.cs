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
        internal int id;

        public Fmanagement()
        {
            this.controllerAdmin = new AppLibrary.databaseAPPLM.Admintor();
            InitializeComponent();
            this.Load += Fmanagement_Load;
            this.MenuADD.Click += MenuADD_Click;
            this.MenuUppdate.Click += MenuUppdate_Click;
            this.MEnuDelete.Click += MEnuDelete_Click;
        }

        private void MEnuDelete_Click(object sender, EventArgs e)
        {
            (new FdisplayDelete()).ShowDialog();
        }

        private void MenuUppdate_Click(object sender, EventArgs e)
        {
            (new FdisplayUpdate()).ShowDialog();
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
