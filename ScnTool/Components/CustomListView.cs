/*************************************************************************
OAKListView 1.0
10/02/2004
Developer: Carlos Carvalho
carvalho@flag.com.br
+55 31 99440862 / +55 31 32616977
**************************************************************************/

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomListView
{
    /// <summary>
    /// Summary description for OAKListView.
    /// </summary>
    public class CustomListView : ListView
    {
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct LV_ITEM
        {
            public uint mask;
            public int iItem;
            public int iSubItem;
            public uint state;
            public uint stateMask;
            public string pszText;
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
        }

        public const int LVM_FIRST = 0x1000;
        public const int LVM_GETITEM = LVM_FIRST + 5;
        public const int LVM_SETITEM = LVM_FIRST + 6;
        public const int LVIF_TEXT = 0x0001;
        public const int LVIF_IMAGE = 0x0002;

        public const int LVW_FIRST = 0x1000;
        public const int LVM_GETEXTENDEDLISTVIEWSTYLE = LVW_FIRST + 54;

        public const int LVS_EX_GRIDLINES = 0x00000001;
        public const int LVS_EX_SUBITEMIMAGES = 0x00000002;
        public const int LVS_EX_CHECKBOXES = 0x00000004;
        public const int LVS_EX_TRACKSELECT = 0x00000008;
        public const int LVS_EX_HEADERDRAGDROP = 0x00000010;
        public const int LVS_EX_FULLROWSELECT = 0x00000020; // applies to report mode only
        public const int LVS_EX_ONECLICKACTIVATE = 0x00000040;

        /// <summary>
        /// Changing the style of listview to accept image on subitems
        /// </summary>
        public CustomListView()
        {
            // Change the style of listview to accept image on subitems
            var m = new Message
            {
                HWnd = Handle,
                Msg = LVM_GETEXTENDEDLISTVIEWSTYLE,
                LParam = (IntPtr)(LVS_EX_GRIDLINES |
                                LVS_EX_FULLROWSELECT |
                                LVS_EX_SUBITEMIMAGES |
                                LVS_EX_CHECKBOXES |
                                LVS_EX_TRACKSELECT),
                WParam = IntPtr.Zero
            };
            WndProc(ref m);
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(
            IntPtr hWnd,    // handle to destination window 
            int Msg,        // message 
            IntPtr wParam,  // first message parameter 
            IntPtr lParam   // second message parameter 
            );

        [DllImport("user32.dll")]
        public static extern bool SendMessage(
            IntPtr hWnd,        // handle to destination window 
            int msg,            // message 
            int wParam,
            ref LV_ITEM lParam);// pointer to struct of LV_ITEM
    }
}
