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
    public partial class FdisplayDelete : Form
    {
        private AppLibrary.databaseAPPLM.Admintor controllerAdmin;
        public FdisplayDelete()
        {
            this.controllerAdmin = new AppLibrary.databaseAPPLM.Admintor();
            InitializeComponent();
            this.Load += FdisplayDelete_Load;
            this.dataGridView1.DoubleClick += DataGridView1_DoubleClick;
        }

        void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count == 1)
            {
                if(MessageBox.Show("Do you want to delete this row?", "Confirm", 
                    MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    var DeleteBook = (BookView)this.dataGridView1.SelectedRows[0].DataBoundItem;
                    this.controllerAdmin.DeleteBook(DeleteBook.ID);
                    this.load();
                }
            }
        }

        public void load()
        {
            var data = controllerAdmin.getAllBook();
            var view = new BookView[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                view[i] = new BookView(data[i]);
            }
            this.dataGridView1.DataSource = view;
        }
        private void FdisplayDelete_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
