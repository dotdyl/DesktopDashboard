using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopDashboard
{
    public struct Zone
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public Zone(int x, int y, int width, int height) {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }



    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
