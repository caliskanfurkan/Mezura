using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mezura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEval_Click(object sender, EventArgs e)
        {
            tabPanel.Enabled = true;

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(txtURL.Text);
            myRequest.Method = "GET";
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            WebHeaderCollection myHeaders = myResponse.Headers;
            txtReport.Text = myHeaders.ToString();
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabPanel.Enabled = false;
            tabPage1.Text = "Başlık Bilgileri";
            tabPage2.Text = "Port Tarama";
        }
    }
}
