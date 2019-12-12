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
    public partial class loginForm : Form
    {
        public static string codeIDuser;
        private databaseAPPLM.Admintor controller;
        public loginForm()
        {
            this.controller = new databaseAPPLM.Admintor();
            InitializeComponent();
            this.btnLogin.Click += BtnLogin_Click;
            this.btnExit.Click += BtnExit_Click;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            codeIDuser = this.txtUsername.Text;
            var acc = this.txtUsername.Text;
            var pass = this.txtPass.Text;
            try
            {
                if (controller.checkUser(acc, pass))
                {
                    MessageBox.Show("Login thành Công");
                    var fMain = new allFrom.fMain();
                    fMain.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

      
    }
}
