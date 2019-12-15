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
            this.MenuUppdate.Click += MenuUppdate_Click;
            this.MEnuDelete.Click += MEnuDelete_Click;
            this.MenuRefreshh.Click += MenuRefreshh_Click;
            this.btnSearching.Click += BtnSearching_Click;
            this.dataGridView1.DoubleClick += DataGridView1_DoubleClick;
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Do you want to delete this row?", "Confirm",
                    MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    var Delete = (History)this.dataGridView1.SelectedRows[0].DataBoundItem;
                    this.controllerAdmin.DeleteHistory(Delete.id);
                    this.load();
                }
            }
        }

        private void BtnSearching_Click(object sender, EventArgs e)
        {
            var target = this.textBox1.Text;
            var result = this.controllerAdmin.getUSER_history(target);

            this.dataGridView1.DataSource = result;
        }

        private void MenuRefreshh_Click(object sender, EventArgs e)
        {
            this.load();
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
