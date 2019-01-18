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
        BackgroundWorker bckWrkr = new BackgroundWorker();

        public Mainfrm()
        {
            InitializeComponent();
            bckWrkr.WorkerReportsProgress = true;
            bckWrkr.DoWork += new DoWorkEventHandler(bckWrkr_DoWork);
            bckWrkr.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bckWrkr_RunWorkerCompleted);

            txtSourceFolder.AllowDrop = true;
            txtSourceFolder.DragEnter += new DragEventHandler(SourceFolder_DragEnter);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            bckWrkr.RunWorkerAsync();
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
            {
                btnExit_Click(sender, e);
                return;
            }

            userLogin = loginFrm.Tag as UserLogin;
            lblUsername.Text =  userLogin.user.name;
            #endregion

            
            txtSourceFolder.Text = Application.StartupPath;
            txtDestinationFolder.Text = Application.StartupPath;
            txtCode.Text = "20732";
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
        private void SourceFolder_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (!Directory.Exists(file))
                {
                    MessageBox.Show("پوشه مورد وجود ندارد", "پیام سیستم", MessageBoxButtons.OK);
                    break;
                }
                txtSourceFolder.Text = file;
                var tempFile = Directory.GetParent(file);
                txtDestinationFolder.Text = tempFile.FullName + @"\output";
            }
        }
        private void bckWrkr_DoWork(object sender, DoWorkEventArgs e)
        {

            if (string.IsNullOrEmpty(txtSourceFolder.Text) || string.IsNullOrEmpty(txtDestinationFolder.Text))
            {
                MessageBox.Show("پوشه مبدا یا مقصد را انتخاب نمایید", "پیام سیستم", MessageBoxButtons.OK);
                return;
            }

            if (!Directory.Exists(txtSourceFolder.Text))
            {
                MessageBox.Show("پوشه مبدا وجود ندارد", "پیام سیستم", MessageBoxButtons.OK);
                return;
            }

            var sourcePath = txtSourceFolder.Text + "\\";
            var destinationPath = txtDestinationFolder.Text + "\\";

            var title = txtTitle.Text.Trim();
            var code = txtCode.Text.Trim();
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(code))
            {
                MessageBox.Show("کد و عنوان مجموعه نمی تواند خالی باشد", "پیام سیستم", MessageBoxButtons.OK);
                return;
            }

            AddToListResult("شروع فرایند کد کردن");

            ProcessApp(code, title, sourcePath, destinationPath);

            AddToListResult("پایان فرایند کد کردن");
            GC.Collect(0);
            GC.Collect(1);
            GC.Collect(2);
            GC.WaitForPendingFinalizers();
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
        private void ProcessApp(string code, string title, string sourcePath, string destinationPath)
        {
            var directory = new DirectoryInfo(sourcePath);
            var resultMessage = DialogResult.None;

            var inputFiles = directory.GetFiles();
            if (inputFiles.Count() == 0)
            {
                MessageBox.Show("فایلی یافت نشد", "پیام سیستم", MessageBoxButtons.OK);
                return;
            }

            if (!Directory.Exists(destinationPath))
                Directory.CreateDirectory(destinationPath);

            picWait.Invoke((MethodInvoker)delegate
            {
                picWait.Visible = true;
            });

            AddToListResult(string.Format("تعداد {0} فایل شناسایی شد", inputFiles.Count()));
            foreach (var item in inputFiles)
            {
                conflictLable:

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
                AddToListResult(string.Format("فایل از نام {0} به نام {1} ذخیره شد", model.name, model.new_name + model.new_extension));

                retryLable:

                try
                {
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
                        {
                            AddToListResult(ex.InnerException.Message);
                            resultMessage = MessageBox.Show("درارتباط با سرور خطایی رخ داده مایلید همین فایل دوباره ارسال شود؟", "پیام سیستم", MessageBoxButtons.RetryCancel);
                        }
                    }
                }
                if (resultMessage == DialogResult.Yes)
                {
                    resultMessage = DialogResult.None;
                    goto conflictLable;
                }

                if (resultMessage == DialogResult.Retry)
                {
                    resultMessage = DialogResult.None;
                    goto retryLable;
                }
            }

            var directories = directory.GetDirectories();
            foreach (var directoryItem in directories)
                ProcessApp(code, title, directoryItem.FullName + "\\", Path.Combine(destinationPath, directoryItem.Name + "\\"));

        }
    }
}
