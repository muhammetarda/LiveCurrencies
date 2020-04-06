using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Dynamic;
using HtmlAgilityPack;
using System.Xml;
using Fizzler.Systems.HtmlAgilityPack;



// Install-Package HtmlAgilityPack -Version 1.11.23
// Install-Package Fizzler.Systems.HtmlAgilityPack -Version 1.2.0

namespace LiveCurrencies
{
    public partial class Form1 : Form
    {
        public void versionCheck()

        // Doğukan Yıldıran - VersionCheck - https://github.com/0x21/Versioncheck/blob/master/versioncheck/Program.cs
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString("https://raw.githubusercontent.com/muhammetarda/LiveCurrencies/version/version.txt");
            string text = "1\n";
            if (text != reply)
            {
                Console.WriteLine("Github Version : "+reply);
                Console.WriteLine("Local Code Version : " + text);
                MessageBox.Show(
                    "The software is out of date, please download the new version!\n" +
                    "Github Version: "+reply + "\n" +
                    "Local Code Version : " + text + "\n" +
                    "Opening New Version Page.....");
                System.Diagnostics.Process.Start("https://github.com/muhammetarda/LiveCurrencies/releases");
                Application.Exit();
                this.Close();
                

            }
            else
            {

                Console.WriteLine("Version Good!");
                Console.WriteLine("Github Version : " + reply);
                Console.WriteLine("Local Code Version : " + text);
                label8.Text = (text);

            }

        }

        public void Dolar()
        {
            var html1 = @"http://tr.investing.com/currencies/usd-try";
            HtmlWeb web1 = new HtmlWeb();
            var htmlDoc1 = web1.Load(html1);
            var nodes1 = htmlDoc1.DocumentNode.SelectNodes("//span[@class = 'arial_26 inlineblock pid-18-last']");
            foreach (var node1 in nodes1)
                usdData.Text = (node1.InnerText);
        }
        public void GPB()
        {
            var html2 = @"https://tr.investing.com/currencies/gbp-try";
            HtmlWeb web2 = new HtmlWeb();
            var htmlDoc2 = web2.Load(html2);
            var nodes2 = htmlDoc2.DocumentNode.SelectNodes("//span[@class = 'arial_26 inlineblock pid-97-last']");
            foreach (var node2 in nodes2)
                gpbData.Text = (node2.InnerText);
        }
        public void Euro()
        {
            var html3 = @"https://tr.investing.com/currencies/eur-try";
            HtmlWeb web3 = new HtmlWeb();
            var htmlDoc3 = web3.Load(html3);
            var nodes3 = htmlDoc3.DocumentNode.SelectNodes("//span[@class = 'arial_26 inlineblock pid-66-last']");
            foreach (var node3 in nodes3)
                euroData.Text = (node3.InnerText);
        }

        public void Bitcoin()
        {
            var html4 = @"https://tr.investing.com/crypto/bitcoin/btc-try";
            HtmlWeb web4 = new HtmlWeb();
            var htmlDoc4 = web4.Load(html4);
            var nodes4 = htmlDoc4.DocumentNode.SelectNodes("//span[@class = 'arial_26 inlineblock pid-1052426-last']");
            foreach (var node4 in nodes4)
                btcData.Text = (node4.InnerText);
        }
        public Form1()
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                InitializeComponent();
                Dolar();
                GPB();
                Euro();
                Bitcoin();
                versionCheck();

            }
            else
            {
                MessageBox.Show("Ups... Not connect Internet :(\n" + "Please try again");
            }
            

         
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Application.DoEvents();


        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info info = new info();
            info.Show();
        }
    }
}
