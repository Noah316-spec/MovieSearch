using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;
using System.CodeDom.Compiler;
using System.IO;
using static System.Windows.Forms.LinkLabel;

namespace OOP_test
{
    public partial class Form1 : Form
    {
        public string ApiKey = "a514f1cf";
        Random rnd = new Random();
        List<string> list = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abfrage();
            comboboxsearch();
        }
        

        void comboboxsearch()
        {

            int i;
            string link, json;
            Movie.info Info;
           

            using (WebClient Web = new WebClient())
            {
                do
                {
                    i = rnd.Next(0083658, 9900000);
                    link = "https://www.omdbapi.com/?i=tt+" + i + "&apikey=" + ApiKey;
                    json = Web.DownloadString(link);
                    Info = JsonConvert.DeserializeObject<Movie.info>(json);
                }
                while (string.IsNullOrEmpty(Info.Title));

                if (Info.Title != null)
                {
                    comboBox1.Items.Add(Info.Title);
                    list.Add(Info.Title);
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            string link, json;
            Movie.info Info;
            textBox2.Clear();

            if (list.Contains(comboBox1.Text)) 
            {
                using (var webClient = new WebClient())
                {
                    i = rnd.Next(0083658, 9900000);
                    link = "https://www.omdbapi.com/?i=tt+" + i + "&apikey=" + ApiKey;
                    json = webClient.DownloadString(link);
                    Info = JsonConvert.DeserializeObject<Movie.info>(json);
                    textBox2.Text = "Titel: " + Info.Title + Environment.NewLine + "Year: " + Info.Year + Environment.NewLine + "Genre: " + Info.Genre + Environment.NewLine + "Awards: " + Info.Awards;
                    /*using (var web = new WebClient())
                    {
                        
                        byte[] imageBytes = web.DownloadData(Info.Poster);

                        using (var ms = new MemoryStream(imageBytes))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }*/
                }
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                label1.Visible = false;
                comboBox1.Visible = false;
                button2.Visible = false;
                label2.Visible = true;
                button1.Visible = true;
                textBox1 .Visible = true;

            }
            else if (comboBox2.SelectedIndex == 1) 
            {
                label1.Visible = true;
                comboBox1.Visible = true;
                button2.Visible = true;
                label2.Visible = false;
                button1.Visible = false;
                textBox1.Visible = true;


            }


        }
        void abfrage()
        {
            textBox2.Clear();

            using (WebClient Web = new WebClient())
            {

                string link = "https://www.omdbapi.com/?t=" + textBox1.Text.Replace(' ', '+') + "&apikey=" + ApiKey;
                var json = Web.DownloadString(link);
                Movie.info Info = JsonConvert.DeserializeObject<Movie.info>(json);

                if (titel.Checked)
                {
                    textBox2.Text = "Titel: " + Info.Title + Environment.NewLine;
                }
                if (year.Checked)
                {
                    textBox2.Text += "Year: " + Info.Year + Environment.NewLine;
                }
                if (genre.Checked)
                {
                    textBox2.Text+= "Genre: " + Info.Genre + Environment.NewLine;
                }
                if (awards.Checked)
                {
                    textBox2.Text+= "Award: " + Info.Awards + Environment.NewLine;
                }
                if (country.Checked)
                {
                    textBox2.Text += "Country: " + Info.Country + Environment.NewLine;
                }
                if (plot.Checked)
                {
                    textBox2.Text += "Plot: " + Info.Plot + Environment.NewLine;
                }
                using (var webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(Info.Poster);

                    using (var ms = new MemoryStream(imageBytes))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
            }

        }
    }
}
