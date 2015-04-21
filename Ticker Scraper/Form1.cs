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

namespace Ticker_Scraper
{
    public partial class Form1 : Form
    {
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public Form1()
        {
            InitializeComponent();
            txtPath.Text = folder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Set path for Dow30.txt file
            string path = folder + @"\Dow30.txt";

            //Access barchart.com to get Dow 30 components
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.barchart.com/stocks/industrials.php?view=main");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Read source of request to webPageInfo string
            StreamReader stream = new StreamReader(response.GetResponseStream());
            string webPageInfo = stream.ReadToEnd();

            //Trim returned text to get tickers
            int index = webPageInfo.IndexOf("\"symbols\"");
            webPageInfo = webPageInfo.Substring(index + 9);

            index = webPageInfo.IndexOf("=\"");
            webPageInfo = webPageInfo.Substring(index + 2);

            index = webPageInfo.IndexOf(",,");
            webPageInfo = webPageInfo.Substring(0, index);

            webPageInfo = webPageInfo.Replace(",", ", ");

            //Write string to text file
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(webPageInfo);
                MessageBox.Show(path + " download complete");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Set path for SP100.txt file
            string path = folder + @"\SP100.txt";

            //Access barchart.com to get Dow 30 components
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.barchart.com/stocks/sp100.php");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Read source of request to webPageInfo string
            StreamReader stream = new StreamReader(response.GetResponseStream());
            string webPageInfo = stream.ReadToEnd();

            //Trim returned text to get tickers
            int index = webPageInfo.IndexOf("\"symbols\"");
            webPageInfo = webPageInfo.Substring(index + 9);

            index = webPageInfo.IndexOf("=\"");
            webPageInfo = webPageInfo.Substring(index + 2);

            index = webPageInfo.IndexOf("\"");
            webPageInfo = webPageInfo.Substring(0, index);

            webPageInfo = webPageInfo.Replace(",", ", ");

            //Write string to text file
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(webPageInfo);
                MessageBox.Show(path + " download complete");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Set path for NASDAQ100.txt file
            string path = folder + @"\NASDAQ100.txt";

            //Access barchart.com to get Dow 30 components
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.barchart.com/stocks/nasdaq100.php");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Read source of request to webPageInfo string
            StreamReader stream = new StreamReader(response.GetResponseStream());
            string webPageInfo = stream.ReadToEnd();

            //Trim returned text to get tickers
            int index = webPageInfo.IndexOf("\"symbols\"");
            webPageInfo = webPageInfo.Substring(index + 9);

            index = webPageInfo.IndexOf("=\"");
            webPageInfo = webPageInfo.Substring(index + 2);

            index = webPageInfo.IndexOf("\"");
            webPageInfo = webPageInfo.Substring(0, index);

            webPageInfo = webPageInfo.Replace(",", ", ");

            //Write string to text file
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(webPageInfo);
                MessageBox.Show(path + " download complete");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
                folder = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
