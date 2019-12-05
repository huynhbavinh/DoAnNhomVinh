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
    public partial class fLibraryCard : Form
    {
        private databaseAPPLM.Admintor controller;
        
        public fLibraryCard()
        {
            this.controller = new databaseAPPLM.Admintor();
            InitializeComponent();
            this.Load += FLibraryCard_Load;
        }

        private void FLibraryCard_Load(object sender, EventArgs e)
        {
            var user = this.controller.profile();
            var temp = user.PHONE_NUMBER.ToString();
            this.txtCode.Text = user.STUDENT_CODE;
            this.txtName.Text = user.NAME;
            this.txtEmail.Text = user.email;
            this.txtPhone.Text = temp;
        }
    }
}
