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

        public string ApiKey = "a514f1cf"; //api key
        Random rnd = new Random(); //random zahl
        List<string> list = new List<string>(); //Liste erstellen
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0; // standart wert festlegen
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Aufruf der Funktionen
            bool i = false;
            abfrage(i);
            comboboxsearch();
        }


        void comboboxsearch()
        {
            //Deklarien
            int i;
            string link, json;
            Movie.info Info;


            // Ein WebClient-Objekt wird erstellt, um eine HTTP-Anfrage zu senden.
            using (WebClient Web = new WebClient())
            {
                // Schleife wird gestartet, die so lange läuft, bis ein gültiger Filmtitel gefunden wird.
                do
                {
                    i = rnd.Next(0083658, 9900000);
                    link = "https://www.omdbapi.com/?i=tt+" + i + "&apikey=" + ApiKey;
                    // Die JSON-Antwort von der OMDB-API wird heruntergeladen.
                    json = Web.DownloadString(link);
                    // Die JSON-Antwort wird in ein 'Movie.info'-Objekt deserialisiert.
                    Info = JsonConvert.DeserializeObject<Movie.info>(json);
                }
                // Die Schleife wird fortgesetzt, bis ein Film mit einem nicht-leeren Titel gefunden wird.
                while (string.IsNullOrEmpty(Info.Title));
                // Wenn der Filmtitel nicht null ist, wird er zur ComboBox und zur Liste hinzugefügt.
                if (Info.Title != null)
                {
                    comboBox1.Items.Add(Info.Title);
                    list.Add(Info.Title);
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool b = true;
            abfrage(b);
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // auswahl so erstellen das nur die die angezeigt werden sollen angezeigt werden
            if (comboBox2.SelectedIndex == 0)
            {
                label1.Visible = false;
                comboBox1.Visible = false;
                button2.Visible = false;
                label2.Visible = true;
                button1.Visible = true;
                textBox1.Visible = true;

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
        void abfrage(bool check)
        {
            // Zuerst wird der Inhalt von textBox2 gelöscht.
            textBox2.Clear();

            // Ein WebClient-Objekt wird erstellt, um eine HTTP-Anfrage zu senden.
            using (WebClient Web = new WebClient())
            {
                int i;
                string link = "";
                if(check == false)
                {
                    // Der Link zur OMDB-API wird erstellt. Der Filmtitel aus textBox1 wird verwendet und Leerzeichen werden durch '+' ersetzt.
                   link = "https://www.omdbapi.com/?t=" + textBox1.Text.Replace(' ', '+') + "&apikey=" + ApiKey;
                }
               else if(check == true)
               {
                    if (list.Contains(comboBox1.Text))
                    {
                        i = rnd.Next(0083658, 9900000); // random Film Nummer ca zwischen 0 bis 9900000
                        link = "https://www.omdbapi.com/?i=tt+" + i + "&apikey=" + ApiKey;
                    }
               }

                // Die JSON-Antwort von der OMDB-API wird heruntergeladen.
                var json = Web.DownloadString(link);

                // Die JSON-Antwort wird in ein Movie.info-Objekt deserialisiert.
                Movie.info Info = JsonConvert.DeserializeObject<Movie.info>(json);

                // Abhängig von den ausgewählten Checkboxen werden verschiedene Informationen zum Film in textBox2 eingefügt.
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
                    textBox2.Text += "Genre: " + Info.Genre + Environment.NewLine;
                }
                if (awards.Checked)
                {
                    textBox2.Text += "Award: " + Info.Awards + Environment.NewLine;
                }
                if (country.Checked)
                {
                    textBox2.Text += "Country: " + Info.Country + Environment.NewLine;
                }
                if (plot.Checked)
                {
                    textBox2.Text += "Plot: " + Info.Plot + Environment.NewLine;
                }

                if(check == false)
                {
                    // Ein weiteres WebClient-Objekt wird erstellt, um das Filmposter herunterzuladen.
                    using (var webClient = new WebClient())
                    {
                        // Das Filmposter wird als Byte-Array heruntergeladen.
                        byte[] imageBytes = webClient.DownloadData(Info.Poster);

                        // Das Byte-Array wird in ein MemoryStream-Objekt umgewandelt und dann in ein Image-Objekt konvertiert, das in pictureBox1 angezeigt wird.
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
                
               
            }


        }
    }
}
