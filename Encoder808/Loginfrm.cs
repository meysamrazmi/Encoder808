using Encoder808.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Encoder808
{
    public partial class Loginfrm : Form
    {
        BackgroundWorker bckWrkr = new BackgroundWorker();
        public Loginfrm()
        {
            InitializeComponent();
            bckWrkr.WorkerReportsProgress = true;
            bckWrkr.DoWork += new DoWorkEventHandler(bckWrkr_DoWork);
            bckWrkr.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bckWrkr_RunWorkerCompleted);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            txtUsername.Text = txtUsername.Text.Trim();
            txtPassword.Text = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                MessageBox.Show("نام کاربری یا رمز عبور را وارد کنید");

            bckWrkr.RunWorkerAsync();
        }

        private void Loginfrm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "amir6972";
            txtPassword.Text = "123456aA";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bckWrkr_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                picWait.Invoke((MethodInvoker)delegate
                {
                    picWait.Visible = true;
                });


                var resultLogin = Classes.WebService.login(txtUsername.Text, txtPassword.Text);

                if (!string.IsNullOrEmpty(resultLogin.sessid))
                {
                    this.Tag = resultLogin;
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bckWrkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                picWait.Invoke((MethodInvoker)delegate
                {
                    picWait.Visible = false;
                });
            }
            catch 
            {
            }
        }
    }
}
