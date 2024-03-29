﻿namespace Encoder808
{
    partial class Mainfrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.lblSourceFolder = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblDestinationFolder = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtDestinationFolder = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.outputList = new System.Windows.Forms.ListBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.picWait = new System.Windows.Forms.PictureBox();
            this.lblText = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnPublish = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Location = new System.Drawing.Point(116, 52);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSourceFolder.Size = new System.Drawing.Size(281, 20);
            this.txtSourceFolder.TabIndex = 0;
            this.txtSourceFolder.Click += new System.EventHandler(this.txtSourceFolder_Click);
            // 
            // lblSourceFolder
            // 
            this.lblSourceFolder.AutoSize = true;
            this.lblSourceFolder.Location = new System.Drawing.Point(22, 55);
            this.lblSourceFolder.Name = "lblSourceFolder";
            this.lblSourceFolder.Size = new System.Drawing.Size(81, 13);
            this.lblSourceFolder.TabIndex = 1;
            this.lblSourceFolder.Text = "آدرس فولدر مبدا:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(24, 190);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "شروع";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblDestinationFolder
            // 
            this.lblDestinationFolder.AutoSize = true;
            this.lblDestinationFolder.Location = new System.Drawing.Point(22, 107);
            this.lblDestinationFolder.Name = "lblDestinationFolder";
            this.lblDestinationFolder.Size = new System.Drawing.Size(88, 13);
            this.lblDestinationFolder.TabIndex = 3;
            this.lblDestinationFolder.Text = "آدرس فولدر مقصد:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(22, 159);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(75, 13);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "عنوان مجموعه:";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(231, 156);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(60, 13);
            this.lblCode.TabIndex = 5;
            this.lblCode.Text = "کد مجموعه:";
            // 
            // txtDestinationFolder
            // 
            this.txtDestinationFolder.Location = new System.Drawing.Point(116, 104);
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDestinationFolder.Size = new System.Drawing.Size(281, 20);
            this.txtDestinationFolder.TabIndex = 6;
            this.txtDestinationFolder.Click += new System.EventHandler(this.txtDestinationFolder_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(116, 152);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(100, 20);
            this.txtTitle.TabIndex = 7;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(297, 156);
            this.txtCode.Name = "txtCode";
            this.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 8;
            // 
            // outputList
            // 
            this.outputList.FormattingEnabled = true;
            this.outputList.Location = new System.Drawing.Point(24, 229);
            this.outputList.Name = "outputList";
            this.outputList.Size = new System.Drawing.Size(372, 381);
            this.outputList.TabIndex = 9;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(105, 190);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // picWait
            // 
            this.picWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picWait.Image = global::Encoder808.Properties.Resources.wait;
            this.picWait.Location = new System.Drawing.Point(24, 190);
            this.picWait.Name = "picWait";
            this.picWait.Size = new System.Drawing.Size(75, 23);
            this.picWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWait.TabIndex = 11;
            this.picWait.TabStop = false;
            this.picWait.UseWaitCursor = true;
            this.picWait.Visible = false;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(22, 9);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(64, 13);
            this.lblText.TabIndex = 12;
            this.lblText.Text = "نام کاربری :";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(92, 9);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(64, 13);
            this.lblUsername.TabIndex = 13;
            this.lblUsername.Text = "نام کاربری :";
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(291, 9);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(121, 23);
            this.btnPublish.TabIndex = 14;
            this.btnPublish.Text = "مدیریت پابلیش";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // Mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 632);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.picWait);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.outputList);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtDestinationFolder);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDestinationFolder);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblSourceFolder);
            this.Controls.Add(this.txtSourceFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mainfrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mainfrm";
            this.Load += new System.EventHandler(this.Mainfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Label lblSourceFolder;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblDestinationFolder;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtDestinationFolder;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.ListBox outputList;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox picWait;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnPublish;
    }
}