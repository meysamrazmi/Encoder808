namespace Encoder808
{
    partial class Publishfrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.chkRequire = new System.Windows.Forms.CheckBox();
            this.mstxtVersion = new System.Windows.Forms.MaskedTextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.lblLastVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ورژن :";
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(276, 272);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 2;
            this.btnAction.Text = "ثبت";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // chkRequire
            // 
            this.chkRequire.AutoSize = true;
            this.chkRequire.Location = new System.Drawing.Point(36, 252);
            this.chkRequire.Name = "chkRequire";
            this.chkRequire.Size = new System.Drawing.Size(148, 17);
            this.chkRequire.TabIndex = 3;
            this.chkRequire.Text = "بروزرسانی اجباری میباشد";
            this.chkRequire.UseVisualStyleBackColor = true;
            // 
            // mstxtVersion
            // 
            this.mstxtVersion.Location = new System.Drawing.Point(84, 28);
            this.mstxtVersion.Mask = "0.0.0.0";
            this.mstxtVersion.Name = "mstxtVersion";
            this.mstxtVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mstxtVersion.Size = new System.Drawing.Size(100, 20);
            this.mstxtVersion.TabIndex = 4;
            this.mstxtVersion.ValidatingType = typeof(int);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(84, 133);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(267, 103);
            this.txtDescription.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "توضیحات :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "لینک دانلود :";
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(84, 71);
            this.txtLink.Multiline = true;
            this.txtLink.Name = "txtLink";
            this.txtLink.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLink.Size = new System.Drawing.Size(267, 47);
            this.txtLink.TabIndex = 7;
            // 
            // lblLastVersion
            // 
            this.lblLastVersion.AutoSize = true;
            this.lblLastVersion.Location = new System.Drawing.Point(206, 31);
            this.lblLastVersion.Name = "lblLastVersion";
            this.lblLastVersion.Size = new System.Drawing.Size(16, 13);
            this.lblLastVersion.TabIndex = 9;
            this.lblLastVersion.Text = "...";
            // 
            // Publishfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 321);
            this.Controls.Add(this.lblLastVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.mstxtVersion);
            this.Controls.Add(this.chkRequire);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Publishfrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Publishfrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.CheckBox chkRequire;
        private System.Windows.Forms.MaskedTextBox mstxtVersion;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label lblLastVersion;
    }
}