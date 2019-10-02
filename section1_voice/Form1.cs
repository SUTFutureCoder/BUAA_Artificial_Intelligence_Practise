using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Media;
using System.Windows.Forms;

namespace section1_voice
{
    public partial class Form1 : Form
    {
        private String appId = "17408619";
        private String apiKey = "DbGiQICwnx4ic3QSlF1X2o3G";
        private String apiSecret = "UE3DKkYIt48KhSIRY02AIGpXdYsGVlo7";
        private Baidu.Aip.Speech.Asr client;
        private Baidu.Aip.Speech.Tts ttsClient;


        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/SUTFutureCoder/BUAA_Artificial_Intelligence_Practise");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/SUTFutureCoder/resume/blob/master/README.md");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("pcm");
            comboBox2.Items.Add("wav");
            comboBox2.Items.Add("amr");
            client = new Baidu.Aip.Speech.Asr(apiKey, apiSecret);
            client.Timeout = 60000;
            ttsClient = new Baidu.Aip.Speech.Tts(apiKey, apiSecret);
            ttsClient.Timeout = 60000;
            for (int i = 0; i <= 9; i++)
            {
                comboBox1.Items.Add(i);
                comboBox3.Items.Add(i);
            }
            
            for (int i = 0; i <= 4; i++)
            {
                comboBox4.Items.Add(i);
            }
            comboBox1.SelectedItem = 0;
            comboBox3.SelectedItem = 0;
            comboBox4.SelectedItem = 0;
               
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var data = File.ReadAllBytes(textBox1.Text);
            Newtonsoft.Json.Linq.JObject res = client.Recognize(data, comboBox2.SelectedItem.ToString(), 16000, null);
            if (res.Value<Int32>("err_no") != 0 )
            {
                MessageBox.Show(res.Value<String>("err_msg"));
                return;
            }
            Newtonsoft.Json.Linq.JArray resultList = res.Value<Newtonsoft.Json.Linq.JArray>("result");
            textBox3.Text = "";
            foreach (String resultStr in resultList)
            {
                textBox3.Text += resultStr + "\n";
            }
            
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var option = new Dictionary<string, object>()
            {
                {"spd", comboBox1.SelectedItem },
                {"vol", comboBox3.SelectedItem },
                {"per", comboBox4.SelectedItem }
            };

            var data = ttsClient.Synthesis(textBox2.Text, option);
           if (data.ErrorCode != 0)
            {
                MessageBox.Show(data.ErrorMsg);
                return;
            }
            File.WriteAllBytes("test.mp3", data.Data);
            axWindowsMediaPlayer1.URL = @"test.mp3";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            File.Delete("test.mp3");
        }

        private void AxWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            this.Button4_Click(sender, e);
        }
    }
}
