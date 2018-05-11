using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;

namespace ProtectEye
{
    public partial class MainForm : Form
    {
        bool bProtecting = false;
        int scaler = 60 * 1000;

        int x = 0, y = 0, offset = 2, speed = 10;
        int dirs = 8, curDir = 0, nextDir = 1;//方向：上为0.顺时针 8 方向
        byte btMinutes = 10, btSeconds = 0;
        int nStrHeight = 20;
        string strInfo = "{0}分:{1}秒后自动关闭";
        Graphics g = null;
        Image imgFloat = null;
        Bitmap bmpBuffer;
        Graphics gBuffer;

        Point ptImg;
        Font ftText;
        Brush bshText;
        static int hKeyHook = 0;
        Point ptLocation;
        ConstValue.HookProcDelegate hookFunDelegate;
        FileStream fsTaskManager = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ChildForm_Load(object sender, EventArgs e)
        {
            ptLocation = this.Location;
            this.DoubleBuffered = true; 
            this.ShowInTaskbar = false;
            this.BackColor = Color.Yellow;
            this.TransparencyKey = this.BackColor;
            this.notifyIconMain.Icon = Properties.Resources.System;
            pnlMain.Dock = DockStyle.Fill;
            timerEye.Interval = Messager.GetEyePeriod() * scaler;
            timerEye.Start();
            
            ShowSettingUI();
            /* for test lock ui
            ShowLockUI();
            //*/
        }

        private void ShowSettingUI()
        {
            this.AcceptButton = btnModify;
            this.CancelButton = btnCancelModify;
            this.Location = ptLocation;
            this.Size = new Size(320, 390);
            this.Padding = new Padding(0, 0, 0, 0); // eye
            int totalMinutes = Messager.GetEyePeriod();
            if (totalMinutes < 60)
            {
                numEyeHour.Value = 0;
                numEyeMinute.Value = totalMinutes;
            }
            else
            {
                numEyeHour.Value = totalMinutes / 60;
                numEyeMinute.Value = totalMinutes % 60;
            }
            lblEye.Text = FormatEyeString(totalMinutes);
            cbDesktop.Checked = Messager.GetOnlyDesktop();
            cbAutoStart.Checked = Messager.GetAutoStart();
            //
            this.Activate();
            gbSetting.BringToFront();
            gbSetting.Select();
        }

        private void ShowLockUI()
        {
            bProtecting = true;
            timerEye.Stop();
            if (Messager.GetOnlyDesktop())
            {
                ((Shell32.IShellDispatch4)new Shell32.ShellClass()).ToggleDesktop();
            }
            this.Location = new Point(0);
            this.AcceptButton = btnUnlock;
            this.CancelButton = btnCancel;
            this.Size = SystemInformation.VirtualScreen.Size;
            int lrPadding = (this.Width - 220) / 2;
            int topPadding = (this.Height - 300) / 3;
            int bottomPadding = (this.Height - 200) / 2;
            this.Padding = new Padding(lrPadding, topPadding, lrPadding, bottomPadding);
            pnlMain.Show();
            btnUnlock.BringToFront();
            btnUnlock.Select();
            this.Activate();
            this.Show();
            InitFloatImg();

            Messager.SetHook();
        }

        private void InitFloatImg()
        {
            g = this.CreateGraphics();
            imgFloat = Properties.Resources.Smile;
            ptImg = new Point(
                new Random(DateTime.Now.Millisecond).Next(0, Math.Abs(this.Width - imgFloat.Width)),
                new Random(DateTime.Now.Millisecond).Next(0, Math.Abs(this.Height - imgFloat.Height))
             );

            curDir = NextDirection();

            bmpBuffer = new Bitmap(imgFloat.Width, imgFloat.Height + nStrHeight);//(this.Width, this.Height);//
            gBuffer = Graphics.FromImage(bmpBuffer);
            // string
            ftText = new Font("Comic Sans MS",20f, FontStyle.Bold, GraphicsUnit.Pixel);
            bshText = new SolidBrush(Color.Red);
            
            // timer
            timerFloat.Interval = speed;
            timerFloat.Start();
            timerAutoClose.Start();
        }

        private bool IsBadDirection()
        {
            return (nextDir == curDir) || (Math.Abs(nextDir - curDir) == 4);
        }

        private int NextDirection()
        {
            do
            {
                nextDir = new Random(DateTime.Now.Millisecond).Next(0, dirs);
            }
            while (IsBadDirection());

            switch (nextDir)
            {
                case 0:
                    x = 0;
                    y = -offset;
                    break;
                case 1:
                    x = offset;
                    y = -offset;
                    break;
                case 2:
                    x = offset;
                    y = 0;
                    break;
                case 3:
                    x = offset;
                    y = offset;
                    break;
                case 4:
                    x = 0;
                    y = offset;
                    break;
                case 5:
                    x = -offset;
                    y = offset;
                    break;
                case 6:
                    x = -offset;
                    y = 0;
                    break;
                case 7:
                    x = -offset;
                    y = -offset;
                    break;
            }
            return nextDir;
        }

        private void ChildForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToggleLockUI();
            }
        }

        private void ToggleLockUI()
        {
            pnlMain.Visible = !pnlMain.Visible;
        }
 
        private void btnUnlock_Click(object sender, EventArgs e)
        {
            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
            pnlMain.Padding = new Padding(10);
            gbUnlock.BringToFront();
            txtPassword.Clear();
            txtPassword.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == btnOk)
            {
                if (txtPassword.Text.Trim() == Messager.GetPassword())
                {
                    Exit();
                }
                else
                {
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                }
            }
            else if (btn == btnCancel)
            {
                txtPassword.Clear();
                btnUnlock.BringToFront();
                this.AcceptButton = btnUnlock;
                this.CancelButton = null;
            }
        }

        private void Exit()
        {
            if (Messager.GetOnlyDesktop())
            {
                ((Shell32.IShellDispatch4)new Shell32.ShellClass()).ToggleDesktop();
            }

            this.Hide();
            this.AcceptButton = null;
            this.CancelButton = null;
            bProtecting = false;
            btMinutes = ConstValue.AutoClosePeriod;
            btSeconds = 0;
            timerAutoClose.Stop();
            timerFloat.Stop();
            timerEye.Start();
            Messager.Unhook();
        }

        private void timerFloat_Tick(object sender, EventArgs e)
        {

            if ((ptImg.X <= 0) || (ptImg.X + imgFloat.Width >= this.Width) || (ptImg.Y <= 0) || (ptImg.Y + imgFloat.Height >= this.Height))
            {
                ptImg.Offset(-x, -y);
                //File.AppendAllText("d:\\1.txt", "\nold " + curDir);
                curDir = NextDirection();
                //File.AppendAllText("d:\\1.txt", "\nnew " + curDir);
            }
            else
            {
                //*
                //DrawString();
                //
                ptImg.Offset(x, y);
                gBuffer.Clear(this.BackColor);
                gBuffer.DrawImage(imgFloat, 0, nStrHeight);
                gBuffer.DrawString(
                   string.Format(strInfo, btMinutes, btSeconds).Replace("0分:", ""),
                   ftText, bshText, 0, 0);
                g.DrawImage(bmpBuffer, ptImg);
              //*/
            }
        }

        private int KeyHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            //if (nCode == Messager.HC_ACTION)
            //{
            //    KeyMsg msg = (KeyMsg)Marshal.PtrToStructure(lParam, typeof(KeyMsg));
            //    File.AppendAllText("c:\\1.txt", "\n---" + ((Keys)msg.vkCode).ToString() + "," + Control.ModifierKeys.ToString());
            //    if (
            //           (msg.vkCode >= (int)Keys.F1 && msg.vkCode <= (int)Keys.F24)
            //        ||  ((Keys)msg.vkCode == Keys.LWin) || ((Keys)msg.vkCode == Keys.RWin)
            //        //|| ((msg.falgs & Messager.LLKHF_ALTDOWN) == 0)  // alt
            //        //|| ((msg.falgs & Messager.LLKHF_ALTDOWN) != 0)
            //        //|| ((Messager.GetKeyState(Messager.VK_CONTROL) & 0x8000) != 0)// ctrl
            //        //|| ((Messager.GetKeyState(Messager.VK_SHIFT) & 0x8000) != 0) //  shift
            //        || (Control.ModifierKeys >= Keys.Shift)// shift contrl alt 的值最小

            //        //|| (Control.ModifierKeys == Keys.Control)
            //        //|| (Control.ModifierKeys == Keys.Alt)
            //        //|| ((msg.vkCode == (int)Keys.F4) && (Control.ModifierKeys == Keys.Alt))  // alt+f4
            //        //|| ((msg.vkCode == (int)Keys.Tab) && (Control.ModifierKeys == Keys.Alt)) // alt+tab
            //        //|| ((msg.vkCode == (int)Keys.Escape) && (Control.ModifierKeys == Keys.Alt))  // alt+escape
            //        //|| ((msg.vkCode == (int)Keys.Escape) && (Control.ModifierKeys == Keys.Control))//left ctrl+escape
            //        //|| ((msg.vkCode == (int)Keys.Escape) && (Control.ModifierKeys == Keys.Control)) // right ctrl+escape
            //        //|| ((msg.vkCode == (int)Keys.Escape) && ((int)Control.ModifierKeys == 196608))//ctrl+shift+escape
            //        //|| ((msg.vkCode == (int)Keys.Z) && ((int)Control.ModifierKeys == 393216))   // ctrl+alt+z

            //        )
            //    {
            //        return 1;
            //    }
            //}
            return Messager.CallNextHookEx(hKeyHook, nCode, wParam, lParam);
        }

        private void HookStop()
        {
            //Messager.Unhook();

  /*
            if (hKeyHook != 0)
            {
                Messager.UnhookWindowsHookEx(hKeyHook);
                hKeyHook = 0;
            }
            if (null != fsTaskManager)
            {
                fsTaskManager.Close();
            }
            Messager.EnableSysHotKeys(true);
            Messager.ReleaseCAS();
//*/
        }
    
        private void HookStart()
        {
            //Messager.SetHook();
   /*         
            if (hKeyHook == 0)
            {
                
                hookFunDelegate = new ConstValue.HookProcDelegate(KeyHookProc);
                hKeyHook = Messager.SetWindowsHookEx(
                    ConstValue.WH_KEYBOARD_LL, hookFunDelegate,
                    Messager.GetModuleHandle(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName),
                    //Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]),
                    0
                );
                 
                if (hKeyHook == 0)
                {
                    //MessageBox.Show("Hook Failed");
                    HookStop();
                }
                else
                {
                    try
                    {
                        Messager.EnableSysHotKeys(false);
                        //System.Diagnostics.Process.Start("regedit");
                        fsTaskManager = new FileStream(
                            Environment.ExpandEnvironmentVariables("%windir%\\system32\\taskmgr.exe"),
                            FileMode.Open);
                        byte[] bytes = new byte[(int)fsTaskManager.Length];
                        fsTaskManager.Write(bytes, 0, (int)fsTaskManager.Length);

                    }
                    catch (Exception){}
                }
            }
            //*/
        }

        private void timerAutoClose_Tick(object sender, EventArgs e)
        {
            this.TopLevel = true;
            this.Activate();

            if (btSeconds-- <= 0)
            {
                btSeconds = 59;
                btMinutes--;
            }
            if (btMinutes <= 0 && btSeconds <= 0)
            {               
                Exit();
            }
            
            //DrawString();
           
        }

        private void DrawString()
        {

            try
            {
                Bitmap bmpBuffer = new Bitmap(250, 50);
                Graphics gBuffer = Graphics.FromImage(bmpBuffer);
                gBuffer.Clear(this.BackColor);
                gBuffer.DrawString(
                    string.Format("{0}分:{1}秒后自动关闭", btMinutes, btSeconds),
                    ftText, bshText, 0, 0);// pnlMain.Left, pnlMain.Top - 50);
                g.DrawImage(bmpBuffer, pnlMain.Left, pnlMain.Top - 50);
                bmpBuffer.Dispose();
                gBuffer.Dispose();

            }
            catch (Exception)
            {
                
            }
        }
   
        private void ChildForm_VisibleChanged(object sender, EventArgs e)
        {
            //if (this.Visible)
            //{
            //    Messager.SetHook();
            //}
            //else
            //{
            //    Messager.Unhook();
            //}
        }

        private void tsmiSetting_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi == tsmiSetting)
            {
                ShowSettingUI();
                this.Show();
                txtOriginPswd.Focus();
            }           
            else if (tsmi == tsmiExit)
            {
                this.Hide();
                this.Close();
            }
        }

        private void ChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Messager.Unhook();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn == btnModify)
            {
                if (cbPswd.Checked)
                {
                    if (txtOriginPswd.Text.Trim() != Messager.GetPassword())
                    {
                        txtOriginPswd.Focus();
                        txtOriginPswd.SelectAll();
                        return;
                    }
                    else if (txtNewPswd.Text.Trim().Length == 0)
                    {
                        txtNewPswd.Focus();
                        txtNewPswd.SelectAll();
                        return;
                    }
                    else if (txtConfirmPswd.Text.Trim() != txtNewPswd.Text.Trim())
                    {
                        txtConfirmPswd.Focus();
                        txtConfirmPswd.SelectAll();
                        return;
                    }
                    else
                    {
                        Messager.SetPassword(txtNewPswd.Text.Trim());
                        txtOriginPswd.Clear();
                        txtNewPswd.Clear();
                        txtConfirmPswd.Clear();
                    }
                }
                // 
                int hour = Convert.ToInt32(numEyeHour.Value);
                int minute = Convert.ToInt32(numEyeMinute.Value);
                int totalMin = hour * 60 + minute;
                if (totalMin != Messager.GetEyePeriod())
                {
                    timerEye.Interval = totalMin * scaler;
                    Messager.SetEyePeriod(totalMin);
                    this.notifyIconMain.ShowBalloonTip(1000, "Y(^_^)Y", FormatEyeString(totalMin), ToolTipIcon.Info);
                }
                if (cbAutoStart.Checked != Messager.GetAutoStart())
                {
                    Messager.SetAutoStart(cbAutoStart.Checked);
                }
                if (cbDesktop.Checked != Messager.GetOnlyDesktop())
                {
                    Messager.SetOnlyDesktop(cbDesktop.Checked);
                }
               
            }
            else if(btn == btnCancelModify)
            {
                txtOriginPswd.Clear();
                txtNewPswd.Clear();
                txtConfirmPswd.Clear();
            }
            this.AcceptButton = null;
            this.CancelButton = null;
            this.Hide();
        }

        private string FormatEyeString(int total)
        {
            return (total < 60) ?
                   string.Format("护眼：{0}分钟", total) :
                   string.Format("护眼：{0}小时 {1}分钟", numEyeHour.Value, numEyeMinute.Value).Replace(" 0分钟", "");
        }

        private void timerEye_Tick(object sender, EventArgs e)
        {
            ShowLockUI();
        }

        private void notifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowSettingUI();
                this.Visible = !this.Visible;
            }
        }

        private void cbPswd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPswd.Checked == false)
            {
                txtOriginPswd.Clear();
                txtNewPswd.Clear();
                txtConfirmPswd.Clear();
            }
            txtOriginPswd.Enabled = txtNewPswd.Enabled = txtConfirmPswd.Enabled = cbPswd.Checked;
            txtOriginPswd.Focus();
        }


    }
}

