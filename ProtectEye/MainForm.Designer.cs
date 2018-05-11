namespace ProtectEye
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.timerFloat = new System.Windows.Forms.Timer(this.components);
            this.timerAutoClose = new System.Windows.Forms.Timer(this.components);
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbDesktop = new System.Windows.Forms.CheckBox();
            this.cbAutoStart = new System.Windows.Forms.CheckBox();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnCancelModify = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numEyeHour = new System.Windows.Forms.NumericUpDown();
            this.numEyeMinute = new System.Windows.Forms.NumericUpDown();
            this.lblEye = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbPswd = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPswd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmPswd = new System.Windows.Forms.TextBox();
            this.txtOriginPswd = new System.Windows.Forms.TextBox();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.gbUnlock = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerEye = new System.Windows.Forms.Timer(this.components);
            this.cmsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.gbSetting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEyeHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEyeMinute)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbUnlock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerFloat
            // 
            this.timerFloat.Tick += new System.EventHandler(this.timerFloat_Tick);
            // 
            // timerAutoClose
            // 
            this.timerAutoClose.Interval = 1000;
            this.timerAutoClose.Tick += new System.EventHandler(this.timerAutoClose_Tick);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.cmsMain;
            this.notifyIconMain.Text = "^_-眼睛小护士-_^";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseDoubleClick);
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSetting,
            this.tsmiExit});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsMain.Size = new System.Drawing.Size(110, 48);
            // 
            // tsmiSetting
            // 
            this.tsmiSetting.Name = "tsmiSetting";
            this.tsmiSetting.Size = new System.Drawing.Size(152, 22);
            this.tsmiSetting.Text = "设置...";
            this.tsmiSetting.Click += new System.EventHandler(this.tsmiSetting_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(152, 22);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiSetting_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Black;
            this.pnlMain.BackgroundImage = global::ProtectEye.Properties.Resources.LockBg;
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMain.Controls.Add(this.btnUnlock);
            this.pnlMain.Controls.Add(this.gbUnlock);
            this.pnlMain.Controls.Add(this.gbSetting);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(321, 391);
            this.pnlMain.TabIndex = 3;
            // 
            // gbSetting
            // 
            this.gbSetting.BackColor = System.Drawing.Color.Transparent;
            this.gbSetting.Controls.Add(this.groupBox2);
            this.gbSetting.Controls.Add(this.btnModify);
            this.gbSetting.Controls.Add(this.btnCancelModify);
            this.gbSetting.Controls.Add(this.groupBox3);
            this.gbSetting.Controls.Add(this.groupBox1);
            this.gbSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSetting.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSetting.ForeColor = System.Drawing.Color.Olive;
            this.gbSetting.Location = new System.Drawing.Point(10, 10);
            this.gbSetting.Margin = new System.Windows.Forms.Padding(10);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.gbSetting.Size = new System.Drawing.Size(301, 371);
            this.gbSetting.TabIndex = 5;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbDesktop);
            this.groupBox2.Controls.Add(this.cbAutoStart);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ForeColor = System.Drawing.Color.Olive;
            this.groupBox2.Location = new System.Drawing.Point(10, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 72);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "系统";
            // 
            // cbDesktop
            // 
            this.cbDesktop.AutoSize = true;
            this.cbDesktop.Font = new System.Drawing.Font("宋体", 12F);
            this.cbDesktop.Location = new System.Drawing.Point(17, 23);
            this.cbDesktop.Name = "cbDesktop";
            this.cbDesktop.Size = new System.Drawing.Size(155, 20);
            this.cbDesktop.TabIndex = 0;
            this.cbDesktop.Text = "锁屏时只显示桌面";
            this.cbDesktop.UseVisualStyleBackColor = true;
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.AutoSize = true;
            this.cbAutoStart.Font = new System.Drawing.Font("宋体", 12F);
            this.cbAutoStart.Location = new System.Drawing.Point(17, 45);
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.Size = new System.Drawing.Size(91, 20);
            this.cbAutoStart.TabIndex = 0;
            this.cbAutoStart.Text = "开机启动";
            this.cbAutoStart.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            this.btnModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnModify.Location = new System.Drawing.Point(54, 320);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(72, 40);
            this.btnModify.TabIndex = 0;
            this.btnModify.Text = "设置";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnCancelModify
            // 
            this.btnCancelModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelModify.Location = new System.Drawing.Point(162, 320);
            this.btnCancelModify.Name = "btnCancelModify";
            this.btnCancelModify.Size = new System.Drawing.Size(72, 40);
            this.btnCancelModify.TabIndex = 1;
            this.btnCancelModify.Text = "取消";
            this.btnCancelModify.UseVisualStyleBackColor = true;
            this.btnCancelModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.numEyeHour);
            this.groupBox3.Controls.Add(this.numEyeMinute);
            this.groupBox3.Controls.Add(this.lblEye);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.ForeColor = System.Drawing.Color.Olive;
            this.groupBox3.Location = new System.Drawing.Point(10, 155);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox3.Size = new System.Drawing.Size(281, 88);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "护眼间隔";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "时";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "分";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numEyeHour
            // 
            this.numEyeHour.BackColor = System.Drawing.Color.Silver;
            this.numEyeHour.ForeColor = System.Drawing.Color.Green;
            this.numEyeHour.Location = new System.Drawing.Point(48, 40);
            this.numEyeHour.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numEyeHour.Name = "numEyeHour";
            this.numEyeHour.Size = new System.Drawing.Size(41, 26);
            this.numEyeHour.TabIndex = 51;
            this.numEyeHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numEyeHour.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numEyeMinute
            // 
            this.numEyeMinute.BackColor = System.Drawing.Color.Silver;
            this.numEyeMinute.ForeColor = System.Drawing.Color.Green;
            this.numEyeMinute.Location = new System.Drawing.Point(115, 40);
            this.numEyeMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numEyeMinute.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEyeMinute.Name = "numEyeMinute";
            this.numEyeMinute.Size = new System.Drawing.Size(41, 26);
            this.numEyeMinute.TabIndex = 52;
            this.numEyeMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numEyeMinute.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblEye
            // 
            this.lblEye.AutoSize = true;
            this.lblEye.Location = new System.Drawing.Point(46, 21);
            this.lblEye.Name = "lblEye";
            this.lblEye.Size = new System.Drawing.Size(56, 16);
            this.lblEye.TabIndex = 8;
            this.lblEye.Text = "当前：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPswd);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNewPswd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtConfirmPswd);
            this.groupBox1.Controls.Add(this.txtOriginPswd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.Olive;
            this.groupBox1.Location = new System.Drawing.Point(10, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 133);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // cbPswd
            // 
            this.cbPswd.AutoSize = true;
            this.cbPswd.Location = new System.Drawing.Point(5, 15);
            this.cbPswd.Name = "cbPswd";
            this.cbPswd.Size = new System.Drawing.Size(91, 20);
            this.cbPswd.TabIndex = 6;
            this.cbPswd.Text = "解锁密码";
            this.cbPswd.UseVisualStyleBackColor = true;
            this.cbPswd.CheckedChanged += new System.EventHandler(this.cbPswd_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Green;
            this.linkLabel1.Location = new System.Drawing.Point(115, 16);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(136, 16);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "初始密码：admin ";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "原密码:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "确认密码:";
            // 
            // txtNewPswd
            // 
            this.txtNewPswd.BackColor = System.Drawing.Color.Silver;
            this.txtNewPswd.Enabled = false;
            this.txtNewPswd.Location = new System.Drawing.Point(102, 67);
            this.txtNewPswd.Name = "txtNewPswd";
            this.txtNewPswd.PasswordChar = '.';
            this.txtNewPswd.Size = new System.Drawing.Size(160, 26);
            this.txtNewPswd.TabIndex = 2;
            this.txtNewPswd.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "新密码:";
            // 
            // txtConfirmPswd
            // 
            this.txtConfirmPswd.BackColor = System.Drawing.Color.Silver;
            this.txtConfirmPswd.Enabled = false;
            this.txtConfirmPswd.Location = new System.Drawing.Point(102, 96);
            this.txtConfirmPswd.Name = "txtConfirmPswd";
            this.txtConfirmPswd.PasswordChar = '.';
            this.txtConfirmPswd.Size = new System.Drawing.Size(160, 26);
            this.txtConfirmPswd.TabIndex = 3;
            this.txtConfirmPswd.UseSystemPasswordChar = true;
            // 
            // txtOriginPswd
            // 
            this.txtOriginPswd.BackColor = System.Drawing.Color.Silver;
            this.txtOriginPswd.Enabled = false;
            this.txtOriginPswd.Location = new System.Drawing.Point(102, 38);
            this.txtOriginPswd.Name = "txtOriginPswd";
            this.txtOriginPswd.PasswordChar = '.';
            this.txtOriginPswd.Size = new System.Drawing.Size(160, 26);
            this.txtOriginPswd.TabIndex = 3;
            this.txtOriginPswd.UseSystemPasswordChar = true;
            // 
            // btnUnlock
            // 
            this.btnUnlock.BackColor = System.Drawing.Color.Transparent;
            this.btnUnlock.BackgroundImage = global::ProtectEye.Properties.Resources.LockBg;
            this.btnUnlock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUnlock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUnlock.Font = new System.Drawing.Font("宋体", 35F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUnlock.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnUnlock.Image = global::ProtectEye.Properties.Resources.Lock;
            this.btnUnlock.Location = new System.Drawing.Point(10, 10);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(301, 371);
            this.btnUnlock.TabIndex = 1;
            this.btnUnlock.Text = "解锁";
            this.btnUnlock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUnlock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUnlock.UseVisualStyleBackColor = false;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // gbUnlock
            // 
            this.gbUnlock.BackColor = System.Drawing.Color.Transparent;
            this.gbUnlock.Controls.Add(this.btnCancel);
            this.gbUnlock.Controls.Add(this.btnOk);
            this.gbUnlock.Controls.Add(this.txtPassword);
            this.gbUnlock.Controls.Add(this.pictureBox1);
            this.gbUnlock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUnlock.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbUnlock.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.gbUnlock.Location = new System.Drawing.Point(10, 10);
            this.gbUnlock.Name = "gbUnlock";
            this.gbUnlock.Size = new System.Drawing.Size(301, 371);
            this.gbUnlock.TabIndex = 2;
            this.gbUnlock.TabStop = false;
            this.gbUnlock.Text = "请输入解锁密码：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(107, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 55);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(20, 156);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 55);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "解锁";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Silver;
            this.txtPassword.Location = new System.Drawing.Point(41, 71);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '.';
            this.txtPassword.Size = new System.Drawing.Size(152, 29);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ProtectEye.Properties.Resources.Lock;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(7, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // timerEye
            // 
            this.timerEye.Interval = 10000;
            this.timerEye.Tick += new System.EventHandler(this.timerEye_Tick);
            // 
            // ChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::ProtectEye.Properties.Resources.SystemBg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(321, 391);
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChildForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChildForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.ChildForm_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ChildForm_MouseDoubleClick);
            this.VisibleChanged += new System.EventHandler(this.ChildForm_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChildForm_FormClosing);
            this.cmsMain.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.gbSetting.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEyeHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEyeMinute)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbUnlock.ResumeLayout(false);
            this.gbUnlock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox gbUnlock;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerFloat;
        private System.Windows.Forms.Timer timerAutoClose;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.TextBox txtConfirmPswd;
        private System.Windows.Forms.TextBox txtNewPswd;
        private System.Windows.Forms.Button btnCancelModify;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOriginPswd;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbAutoStart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numEyeHour;
        private System.Windows.Forms.NumericUpDown numEyeMinute;
        private System.Windows.Forms.Label lblEye;
        private System.Windows.Forms.CheckBox cbPswd;
        private System.Windows.Forms.Timer timerEye;
        private System.Windows.Forms.CheckBox cbDesktop;
    }
}