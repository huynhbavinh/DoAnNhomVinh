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
    public partial class FdisplayUpdate : Form
    {
        private AppLibrary.databaseAPPLM.Admintor controllerAdmin;
        public FdisplayUpdate()
        {
            this.controllerAdmin = new AppLibrary.databaseAPPLM.Admintor();
            InitializeComponent();
            this.Load += FdisplayUpdate_Load;
        }
        public void loadbook()
        {
            var data = controllerAdmin.getAllBook();
            var view = new BookView[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                view[i]= new BookView(data[i]);
            }
            this.dataGridView1.DataSource = view;
        }

        private void FdisplayUpdate_Load(object sender, EventArgs e)
        {
            loadbook();
        }
    }
}
