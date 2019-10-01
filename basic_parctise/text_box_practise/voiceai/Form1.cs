using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace voiceai
{
    public partial class Form1 : Form
    {

        private string[] ti_mu = new string[4];
        private string[,] Item = new string[4, 5];

        private int[] Answer = new int[4];
        private int s;

        private int ti_shu, right_shu, result;

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, System.EventArgs e)
        {
            ti_mu[1] = "计算机诞生于（）年";
            ti_mu[2] = "防止控件到窗体的最迅速方法是（）";
            ti_mu[3] = "窗体Form1的Text属性为frm,则其Load事件名为（）";
            Item[1, 1] = "A.1994"; Item[1, 2] = "B.1945";
            Item[1, 3] = "C.1946"; Item[1, 4] = "D.1947";
            Item[2, 1] = "A.1994"; Item[2, 2] = "B.1945";
            Item[2, 3] = "C.1946"; Item[2, 4] = "D.1947";
            Item[3, 1] = "A.1994"; Item[3, 2] = "B.1945";
            Item[3, 3] = "C.1946"; Item[3, 4] = "D.1947";
            Answer[1] = 3;
            Answer[2] = 1;
            Answer[3] = 2;
            s = 1;
            chu_ti();
        }

        private void chu_ti()
        {
            label1.Text = ti_mu[s];
            Random randobj = new Random();
            int a = randobj.Next(10, 100);
            int b = randobj.Next(10, 100);
            int p = randobj.Next(0, 2);
            if (p == 0) // 出加法题
            {
                label1.Text = a.ToString() + " + " + b.ToString() + " = ";
                result = a + b;
            }
            else // 出减法题
            {
                if (a < b)
                {
                    int t = a;
                    a = b;
                    b = t;
                }
                label1.Text = a.ToString() + " - " + b.ToString() + " = ";
                result = a - b;
            }
            ti_shu += 1;
            textBox1.Text = "";
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            ti_shu = 0;
            right_shu = 0;
            chu_ti();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Item;
            double k;
            if (e.KeyChar == 13) // 表示按下回车键
            {
                if (Convert.ToInt16(textBox1.Text) == result)
                {
                    Item = label1.Text + textBox1.Text + " yes";
                    right_shu = right_shu + 1;
                }
                else
                    Item = label1.Text + textBox1.Text + " no";
                listBox1.Items.Add(Item);
                this.textBox1.Text = "";
                k = (double)right_shu;
                chu_ti();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
