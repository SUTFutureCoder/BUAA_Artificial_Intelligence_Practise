using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baidu.Aip.Nlp;
using Newtonsoft.Json.Linq;

namespace NLP
{
    public partial class Form1 : Form
    {
        String APPID = "17515731";
        String APIKEY = "IjRnPBB3XkrzSfrTlbDE0B09";
        String SECRETKEY = "jGuvliw6bkV8EmPddtGawELtEld0Tnif";
        Nlp nlp;

        public Form1()
        {
            InitializeComponent();
        }

        private Nlp getClient()
        {
            if (this.nlp != null)
            {
                return this.nlp;
            }
            this.nlp = new Nlp(APIKEY, SECRETKEY);
            this.nlp.Timeout = 60000;
            return this.nlp;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String cifa = this.textBox1.Text;
            var result = this.getClient().Lexer(cifa);
            int num = 0;
            listView1.Items.Clear();
            foreach (JObject retObj in result.Value<JArray>("items"))
            {
                listView1.Items.Add(num.ToString());
                listView1.Items[num].SubItems.Add(retObj.Value<string>("item"));
                listView1.Items[num].SubItems.Add(retObj.Value<string>("pos"));
                listView1.Items[num].SubItems.Add(retObj.Value<JArray>("basic_words").ToString());
                num++;              
            }
            

        }
    }
}
