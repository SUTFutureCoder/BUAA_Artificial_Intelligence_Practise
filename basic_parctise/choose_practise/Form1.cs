using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace choose_practise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("中国");
            comboBox1.Items.Add("美国");
            comboBox1.Items.Add("日本");
            comboBox1.Items.Add("韩国");
            comboBox1.Items.Add("马来西亚");
            comboBox1.Text = "";
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool Flag = true;
            if (comboBox1.Text != "")
            {
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (comboBox1.Items[i].ToString() == comboBox1.Text)
                    {
                        Flag = true;
                        break;
                    }
                }
                if (Flag == false)
                {
                    comboBox1.Items.Add(comboBox1.Text);
                }
            } else
            {
                MessageBox.Show("请先输入国家名称");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择要删除的项目");
            }
            else
            {
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
