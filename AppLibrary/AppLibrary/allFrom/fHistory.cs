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
    public partial class fHistory : Form
    {
        private databaseAPPLM.Admintor controller;
        public fHistory()
        {
            this.controller = new databaseAPPLM.Admintor();
            InitializeComponent();
            this.Load += FHistory_Load;
        }
        private void loadhistory()
        {
            var allHistory = controller.getAllHistory();
            this.dataGridView1.DataSource = allHistory;
        }
        private void FHistory_Load(object sender, EventArgs e)
        {
            this.loadhistory();
        }
    }
}
