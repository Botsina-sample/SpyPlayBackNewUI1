using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpyPlaybackNewUI1.Ultils
{
    class WindowInteraction
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_MAXIMIZE = 3;
        private const int SW_MINIMIZE = 6;
        public static void FocusWindow(Process targetWindow)
        {
            IntPtr hWnd = targetWindow.MainWindowHandle;
            if (hWnd != IntPtr.Zero)
            {
                SetForegroundWindow(hWnd);
                ShowWindow(hWnd, SW_MAXIMIZE);
            }
        }
        public static Process GetProcess(string ProcessName)
        {      
            Process[] process = Process.GetProcessesByName(ProcessName);
            return process[0];
        }
    }
}
