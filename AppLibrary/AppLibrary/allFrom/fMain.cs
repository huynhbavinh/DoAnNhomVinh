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
    public partial class fMain : Form
    {
        private databaseAPPLM.Admintor controller;
        public fMain()
        {
            InitializeComponent();
            this.controller = new databaseAPPLM.Admintor();
            this.Load += FMain_Load;
            this.btnCardLibrary.Click += BtnCardLibrary_Click;
        }

        private void BtnCardLibrary_Click(object sender, EventArgs e)
        {
            var card = new allFrom.fLibraryCard();
            card.ShowDialog();
        }

        private void LoadData()
        {
            var data = controller.getAllBook();
            var viewBook = new databaseAPPLM.BookView[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                viewBook[i] = new databaseAPPLM.BookView(data[i]);
            }
            this.dataGridView1.DataSource = viewBook;
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
