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
        private AdminLibrary.databasee.AddminFunction controllerAdmin;
        public Fmanagement()
        {
            this.controllerAdmin = new AdminLibrary.databasee.AddminFunction();
            InitializeComponent();
            this.Load += Fmanagement_Load;
        }
        private void load()
        {
            var result = this.controllerAdmin.getALLHistories();
            this.dataGridView1.DataSource = result;
        }

        private void Fmanagement_Load(object sender, EventArgs e)
        {
            this.load();
        }
    }
}
