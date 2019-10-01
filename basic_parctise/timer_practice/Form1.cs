using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace timer_practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Point p = new Point(0, 240);
            this.DesktopLocation = p;
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Point p = new Point(this.DesktopLocation.X + 1, this.DesktopLocation.Y);
            this.DesktopLocation = p;
            if (p.X == 550)
            {
                timer1.Enabled = false;
                timer2.Enabled = true;
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Point p = new Point(this.DesktopLocation.X - 1, this.DesktopLocation.Y);
            this.DesktopLocation = p;
            if (p.X == -150)
            {
                timer1.Enabled = true;
                timer2.Enabled = false;
            }
        }
    }
}
