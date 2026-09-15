using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopDashboard
{

    public partial class Form1 : Form
    {
        // Importing Win32 API functions
        #region Win32 API Functions
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        #endregion

        // Win32 Constants
        private const int GWL_STYLE = -16;
        private const int WS_POPUP = 0x8000000;
        private const int WS_CHILD = 0x40000000;

        private IntPtr embeddedAppHandle = IntPtr.Zero;

        public Form1()
        {
            // Initialize the main form and it's componenets
            InitializeComponent();

            EnumWindows((hWnd, lParam) =>
            {
                // Only inspect windows that the user can actually see
                if (IsWindowVisible(hWnd))
                {
                    GetWindowThreadProcessId(hWnd, out uint processId);

                    try
                    {
                        Process proc = Process.GetProcessById((int)processId);
                        string processName = proc.ProcessName;

                        // Optional: Print open apps to terminal to see what's discoverable
                        if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                        {
                            Console.WriteLine($"Found App: {processName} | Title: {proc.MainWindowTitle}");
                            embedOpenAppsList.Items.Add(proc.MainWindowTitle);
                        }
                    }
                    catch
                    {
                        // Ignore system processes that deny access permissions
                    }
                }
                return true; // Keep looping through other windows
            }, IntPtr.Zero);
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();

            if (od.ShowDialog() == DialogResult.OK)
            {
                // Start the target process
                Process proc = Process.Start(od.FileName);

                // Give the application a brief moment to create its main UI thread window handle
                proc.WaitForInputIdle();
                while (proc.MainWindowHandle == IntPtr.Zero)
                {
                    Thread.Sleep(50);
                    proc.Refresh();
                }

                embeddedAppHandle = proc.MainWindowHandle;

                // Remove native borders and title bars so it acts as an integrated child element
                int style = GetWindowLong(embeddedAppHandle, GWL_STYLE);
                style = (style & ~WS_POPUP) | WS_CHILD;
                //SetWindowLong(embeddedAppHandle, GWL_STYLE, style);

                // Bind the external program window to live inside your local layout UI panel
                SetParent(embeddedAppHandle, containerPanel.Handle);

                // Force the newly trapped window to fill out the workspace boundaries completely
                ResizeEmbeddedApp();

                Console.WriteLine($"Successfully started and captured '{od.FileName}'");
            }
            else
            {
                Console.WriteLine($"Failed to start or capture '{od.FileName}'");
            }
        }

        private void ContainerPanel_SizeChanged(object sender, EventArgs e)
        {
            ResizeEmbeddedApp();
        }

        private void ResizeEmbeddedApp()
        {
            if (embeddedAppHandle != IntPtr.Zero)
            {
                // Align the position perfectly over the parent boundaries
                MoveWindow(embeddedAppHandle, 0, 0, containerPanel.Width, containerPanel.Height, true);
            }
        }

        private void embedOpenAppsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (embedOpenAppsList.SelectedIndex != -1)
            {
                string selectedValue = embedOpenAppsList.SelectedItem.ToString();
                int selectedIdx = embedOpenAppsList.SelectedIndex;
                Console.WriteLine($"Selected index {selectedIdx} : {selectedValue}");

                IntPtr foundWindowHandle = IntPtr.Zero;

                EnumWindows((hWnd, lParam) =>
                {
                    // Only inspect windows that the user can actually see
                    if (IsWindowVisible(hWnd))
                    {
                        GetWindowThreadProcessId(hWnd, out uint processId);

                        try
                        {
                            Process proc = Process.GetProcessById((int)processId);
                            string processName = proc.MainWindowTitle;

                            // Match against our target application
                            if (processName.Equals(selectedValue, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Found target application!");
                                foundWindowHandle = hWnd;
                                SetParent(hWnd, containerPanel.Handle);
                                return false; // Stop looping early, we found our window!
                            }
                        }
                        catch
                        {
                            // Ignore system processes that deny access permissions
                        }
                    }
                    return true; // Keep looping through other windows
                }, IntPtr.Zero);
            }
        }
    }
}
