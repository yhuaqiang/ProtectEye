using System.Windows.Forms;
using System;
namespace ProtectEye
{
    public struct KeyMsg  // 注意成员的顺序
    {
        public int vkCode;
        public int scanCode;
        public int falgs;
        public int time;
        public int dwExtraInfo;
    }
    public class ConstValue
    {
         public const string Password = "admin";
        public const int EyePeriod = 50;
        public const byte AutoClosePeriod = 10;
        public const int WH_KEYBOARD = 13;
        public const int WH_KEYBOARD_LL = 13;

        public enum SystemStatus
        {
            System,Online,Offline
        }
        public class CtrlKeys
        {
            public static uint None = 0;
            public static uint Alt = 1;
            public static uint Control = 2;
            public static uint Shift = 4;
        }
        public const Keys KKeySystem = Keys.Q;
        public const Keys KKeySetting = Keys.E;
        public delegate int HookProcDelegate(int nCode, Int32 wParam, IntPtr lParam);



    }
}