using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prcturebox_practice
{
    public partial class Form1 : Form
    {
        private int PicNo;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PicNo = 0;
            timer1.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "位图文件|*.bmp|JPEG文件|*.jpg|GIF 文件|*.gif";
            openFileDialog1.FilterIndex = 3;
            openFileDialog1.ShowDialog();
            listBox1.Items.Add(openFileDialog1.FileName);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = PicNo;
            string s = listBox1.SelectedItem.ToString(); //得到路径
            pictureBox1.Image = Image.FromFile(s);
            PicNo += 1;
            if (PicNo >= listBox1.Items.Count)
            {
                PicNo = 0;
            }
        }
    }
}
