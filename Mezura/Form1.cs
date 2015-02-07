using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        List<string> linkler;

 
        private void btnEval_Click(object sender, EventArgs e)
        {

            
            txtReport.Clear();

            tabPanel.Enabled = true;
            lblStatus.Text = "Başlık bilgileri alınıyor";
            this.HeaderAl();
            lblStatus.Text = "Başlık bilgileri alındı";
            this.LinkleriAl();
            
        }

        private void LinkleriAl() 
        {
            try
            {
                linkler = new List<string>();
                HtmlWeb hw = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = hw.Load(txtURL.Text);

                List<string> hrefTags = new List<string>();
                doc.DocumentNode.SelectNodes("//a[@href]");
                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a"))
                {
                    // Linkleri listeye atıyoruz.
                    linkler.Add(node.GetAttributeValue("href", null));
                }

            }
            catch 
            {
                this.HataBas("Linkler alınırken hata oluştu.");
            }

            foreach (string element in linkler)
            {
                txtReport.AppendText(element);
                txtReport.AppendText(Environment.NewLine);
            }

        }

        private void HeaderAl()
        {
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(txtURL.Text);
                myRequest.Method = "GET";
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                WebHeaderCollection myHeaders = myResponse.Headers;
                txtReport.Text = "Adres: " + txtURL.Text;
                txtReport.AppendText(Environment.NewLine);
                txtReport.AppendText(Environment.NewLine);
                txtReport.AppendText("Başlık Bilgileri:");
                txtReport.AppendText(Environment.NewLine);
                txtReport.Text += myHeaders.ToString();
                progressBar1.Value += 100;
            }
            catch
            {
                this.HataBas("URL hatalı yada erişilemiyor");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Bileşen ayarlamaları
            tabPanel.Enabled = false;
            tabPage1.Text = " ÖZET ;"
          
        }

        private void HataBas(string hataMetni)
        {
            MessageBox.Show(hataMetni, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}

