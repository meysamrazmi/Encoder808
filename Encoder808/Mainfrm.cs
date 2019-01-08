using Encoder808.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encoder808
{
    public partial class Mainfrm : Form
    {
        delegate void InvokeDelegate();
        UserLogin userLogin = null;
        string newExt = ".bin";
        string Data;

        public Mainfrm()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSourceFolder.Text) || string.IsNullOrEmpty(txtDestinationFolder.Text))
            {
                MessageBox.Show("پوشه مبدا یا مقصد را انتخاب نمایید", "پیام سیستم", MessageBoxButtons.OK);
                return;
            }

            var sourcePath = txtSourceFolder.Text + "\\";
            var destinationPath = txtDestinationFolder.Text + "\\";

            var title = txtTitle.Text.Trim();
            var code = txtCode.Text.Trim();

            var directory = new DirectoryInfo(sourcePath);
            DialogResult resultMessage = DialogResult.None;

            Task.Run(() =>
            {
                var inputFiles = directory.GetFiles();
                if (inputFiles.Count() == 0)
                {
                    MessageBox.Show("فایلی یافت نشد", "پیام سیستم", MessageBoxButtons.OK);
                    return;
                }
                AddToListResult(string.Format("تعداد {0} فایل شناسایی شد", inputFiles.Count()));
                AddToListResult("شروع فرایند کد کردن");
                foreach (var item in inputFiles)
                {
                    exceptionLable:

                    try
                    {
                        var model = new EncryptedFilm()
                        {
                            extension = item.Extension,
                            name = item.Name,
                            new_extension = newExt,
                            new_name = Guid.NewGuid().ToString().Split('-').First(),
                            password = Classes.Helper.RandomString(),
                            nid = code,
                            title = title + "-" + item.Name
                        };
                        var destinationPathFile = destinationPath + model.new_name + model.new_extension;
                        AddToListResult(string.Format("درحال بارگذاری فایل {0}", model.name));


                        var data = File.ReadAllBytes(item.FullName);

                        var encData = Classes.Helper.EncryptData(data, model.password);
                        File.WriteAllBytes(destinationPathFile, encData);
                        outputList.Invoke((MethodInvoker)delegate
                        {
                            AddToListResult(string.Format("درحال ذخیره فایل {0} با رمز {1}", model.name, model.password));
                        });

                        var resultSever = WebService.encrypted_film(model, userLogin.session_name + "=" + userLogin.sessid, userLogin.token);
                        if (resultSever)
                            AddToListResult("فراخوانی وب سرویس با موفقیت انجام شد");
                    }
                    catch (Exception ex)
                    {
                        AddToListResult(ex.Message);
                        if (ex.InnerException != null)
                        {
                            if (ex.InnerException.Message == "Conflict")
                            {
                                resultMessage = MessageBox.Show("فایلی با این نام قبلا درسیستم ذخیره شده است مایلید دوباره سعی شود؟", "پیام سیستم", MessageBoxButtons.YesNo);
                            }
                            else
                                AddToListResult(ex.InnerException.Message);
                        }
                    }
                    if (resultMessage == DialogResult.Yes)
                    {
                        resultMessage = DialogResult.None;
                        goto exceptionLable;
                    }
                }
                AddToListResult("پایان فرایند کد کردن");
            });

        }
        private void Result()
        {
            if (Data != "")
            {
                outputList.Items.Add(Data);
            }
        }
        private void AddToListResult(string data)
        {
            Data = data;
            if (InvokeRequired)
            {
                outputList.Invoke(new InvokeDelegate(Result));
            }
            else
            {
                Result();
            }
        }
        private void Mainfrm_Load(object sender, EventArgs e)
        {

            #region Login User
            var loginFrm = new Loginfrm();
            if (loginFrm.ShowDialog() != DialogResult.OK)
                btnExit_Click(sender, e);

            userLogin = loginFrm.Tag as UserLogin;
            #endregion


            txtSourceFolder.Text = @"C:\Users\Amirhossein\Desktop\s";
            txtDestinationFolder.Text = @"C:\Users\Amirhossein\Desktop\d";
            txtCode.Text = "17063";
        }
        private void txtSourceFolder_Click(object sender, EventArgs e)
        {
            var openFileDialog = new FolderBrowserDialog(); openFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog.SelectedPath))
                txtSourceFolder.Text = openFileDialog.SelectedPath;
        }
        private void txtDestinationFolder_Click(object sender, EventArgs e)
        {
            var openFileDialog = new FolderBrowserDialog(); openFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog.SelectedPath))
                txtDestinationFolder.Text = openFileDialog.SelectedPath;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (userLogin != null && !string.IsNullOrEmpty(userLogin.session_name))
                Classes.WebService.logout(userLogin.session_name + "=" + userLogin.sessid, userLogin.token);

            Application.Exit();
        }

    }
}
