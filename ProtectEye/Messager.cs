using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ProtectEye
{
    static class Messager
    {
 
        public static string GetPassword()
        {
            RegistryKey serviceKey =
                Registry.CurrentUser.OpenSubKey("Software")
                .OpenSubKey("ProtectEyes");

            try
            {
                return (serviceKey != null) ?
            serviceKey.GetValue("Password").ToString()
            : ConstValue.Password;

            }
            catch (Exception)
            {
                return ConstValue.Password;
            }
        }

        public static void SetPassword(string pswd)
        {
            RegistryKey serviceKey =
                Registry.CurrentUser.OpenSubKey("Software",true)
                .CreateSubKey("ProtectEyes", RegistryKeyPermissionCheck.ReadWriteSubTree);
            
            serviceKey.SetValue( "Password",serviceKey == null ? ConstValue.Password : pswd);
        }

        public static bool GetAutoStart()
        {
            RegistryKey serviceKey =
                Registry.CurrentUser.OpenSubKey("Software")
                .OpenSubKey("ProtectEyes");

            try
            {
                return (serviceKey != null) ?
            Convert.ToBoolean(serviceKey.GetValue("AutoStart"))
            : true;

            }
            catch (Exception)
            {
                return true;
            }
        }

        public static void SetAutoStart(bool auto)
        {
            RegistryKey aaKey =
                Registry.CurrentUser
                .CreateSubKey("Software")
                .CreateSubKey("microsoft")
                .CreateSubKey("windows")
                .CreateSubKey("currentversion")
                .CreateSubKey("run");
            aaKey.SetValue("ProtectEye", Application.ExecutablePath);
            
            RegistryKey serviceKey =
                Registry.CurrentUser.OpenSubKey("Software", true)
                .CreateSubKey("ProtectEyes", RegistryKeyPermissionCheck.ReadWriteSubTree);

            serviceKey.SetValue("AutoStart", serviceKey == null ? true : auto);


        }

        public static void SetEyePeriod(int minutes)
        {
            RegistryKey serviceKey =
                Registry.CurrentUser.OpenSubKey("Software", true)
                .CreateSubKey("ProtectEyes", RegistryKeyPermissionCheck.ReadWriteSubTree);
            if (serviceKey != null)
            {
                serviceKey.SetValue("EyePeriod", minutes);
            }
            else
            {
                serviceKey.SetValue("EyePeriod", ConstValue.EyePeriod);
            }
        }

        public static int GetEyePeriod()
        {
            try
            {
                RegistryKey serviceKey =
                    Registry.CurrentUser.OpenSubKey("Software")
                    .OpenSubKey("ProtectEyes");

                try
                {
                    return serviceKey == null ? ConstValue.EyePeriod : Convert.ToInt32(serviceKey.GetValue("EyePeriod"));

                }
                catch (Exception)
                {
                    return ConstValue.EyePeriod;
                }
            }
            catch (Exception)
            {
                return ConstValue.EyePeriod;
            }
        }
    
        public static bool GetOnlyDesktop()
        {
            RegistryKey serviceKey =
                Registry.CurrentUser.OpenSubKey("Software")
                .OpenSubKey("ProtectEyes");

            try
            {
                return (serviceKey != null) ?
                     Convert.ToBoolean(serviceKey.GetValue("OnlyDesktop"))
                    : true;

            }
            catch (Exception)
            {
                return true;
            }
        }

        public static void SetOnlyDesktop(bool auto)
        {
            RegistryKey serviceKey =
                Registry.CurrentUser.OpenSubKey("Software", true)
                .CreateSubKey("ProtectEyes", RegistryKeyPermissionCheck.ReadWriteSubTree);

            serviceKey.SetValue("OnlyDesktop", serviceKey == null ? true : auto);
            
        }


        public const int INTERNET_CONNECTION_MODEM = 1;
        public const int INTERNET_CONNECTION_LAN = 2;
        [DllImport("winInet.dll ")]
        public static extern bool InternetGetConnectedState(
            ref   int dwFlag,
            int dwReserved
        );
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(//第一个参数代表钩子ID（13代表键盘钩子，14代表鼠标钩子），
            int idHook, 
            ConstValue.HookProcDelegate lpfn, 
            IntPtr hInstance, 
            int threadID
           );

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(
            int idHook, 
            int nCode, 
            Int32 wParam, 
            IntPtr lParam
        );
        [DllImport("ProtectEyes.dll", EntryPoint = "SetHook")]
        public static extern void SetHook();

        [DllImport("ProtectEyes.dll", EntryPoint = "Unhook")]
        public static extern void Unhook();


        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVK, byte bScan, uint dwFlags, uint dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern byte MapVirtualKey(byte wCode, int wMap);


        public static void ReleaseCAS()
        {
            byte btShift = 16, btCtrl = 17, btAlt = 18;
            keybd_event(btShift, MapVirtualKey(btShift, 0), 0, 0);
            keybd_event(btShift, MapVirtualKey(btShift, 0), 0x2, 0);
            keybd_event(btCtrl, MapVirtualKey(btCtrl, 0), 0, 0);
            keybd_event(btCtrl, MapVirtualKey(btCtrl, 0), 0x2, 0);
            keybd_event(btAlt, MapVirtualKey(btAlt, 0), 0, 0);
            keybd_event(btAlt, MapVirtualKey(btAlt, 0), 0x2, 0);
        }

        public static void EnableSysHotKeys(bool enable)
        {
            string strLockWorkstation = "DisableLockWorkstation";
            string strTaskMgr = "DisableTaskMgr";
            string strWinKeys = "NoWinKeys";
            RegistryKey serviceKey =
                Registry.CurrentUser.OpenSubKey("Software")
                .OpenSubKey("Microsoft")
                .OpenSubKey("Windows")
                .OpenSubKey("CurrentVersion")
                .OpenSubKey("Policies")
                .OpenSubKey("System",true);
            if (serviceKey != null)
            {
                try
                {
                    int val = enable ? 0 : 1;
                    serviceKey.SetValue(strLockWorkstation, val);
                    serviceKey.SetValue(strWinKeys, val);
                    serviceKey.SetValue(strTaskMgr, val);                 

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (enable)
                    {
                        try
                        {
                            serviceKey.DeleteValue(strLockWorkstation);
                            serviceKey.DeleteValue(strWinKeys);
                            serviceKey.DeleteValue(strTaskMgr);
                        }
                        catch (Exception)
                        {
                            
                        }
                    }
                }
            }
        }
    }
}
