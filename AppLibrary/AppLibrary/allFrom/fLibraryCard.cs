﻿using System;
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
            this.btnCancel.Click += BtnCancel_Click;
            this.btnOKii.Click += BtnOKii_Click;
        }

        private void BtnOKii_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FLibraryCard_Load(object sender, EventArgs e)
        {
            var code = allFrom.loginForm.codeIDuser;
            var profile = controller.profile(code);
            this.txtPhone.Text = profile.PHONE_NUMBER.ToString();
            this.txtName.Text = profile.NAME;
            this.txtEmail.Text = profile.email;
            this.txtCode.Text = allFrom.loginForm.codeIDuser;
        }
    }
}