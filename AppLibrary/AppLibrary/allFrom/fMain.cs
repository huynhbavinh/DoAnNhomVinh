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
            this.btnSearching.Click += BtnSearching_Click;
            this.btnHistory.Click += BtnHistory_Click;
            this.dataGridView1.DoubleClick += DataGridView1_DoubleClick;
            this.btnExit.Click += BtnExit_Click;
            Timer timer = new Timer();
            timer.Interval = 700;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            this.label2.BackColor = Color.FromArgb((rd.Next(0, 255)), (rd.Next(0, 255)),(rd.Next(0, 255)));
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            (new allFrom.fHistory()).ShowDialog();
        }

        private void BtnSearching_Click(object sender, EventArgs e)
        {
            var search = new allFrom.fSearching();
            search.ShowDialog();
            
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
            var code = allFrom.loginForm.codeIDuser;
            var profile = controller.profile(code);
            this.label2.Text = "Chào bạn, " + profile.NAME.ToString();
            LoadData();
        }
    }
}
