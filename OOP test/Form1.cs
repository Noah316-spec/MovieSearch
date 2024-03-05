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

namespace OOP_test
{
    public partial class Form1 : Form
    {
        public string ApiKey = "a514f1cf";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getMovie();
        }
        void getMovie()
        {
            using (WebClient Web = new WebClient()) 
            {
                string link = "https://www.omdbapi.com/?t=" + textBox1.Text + "&apikey=" + ApiKey;
                var json = Web.DownloadString(link);
                Movie.info Info = JsonConvert.DeserializeObject<Movie.info>(json);
                textBox2.Text = "Titel: "+ Info.Title + Environment.NewLine + "Year: "+ Info.Year + Environment.NewLine + "Genre: "+ Info.Genre + "Awards: "+ Info.Awards;
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
