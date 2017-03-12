using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace OnlineZeit_V2
{
    public partial class Form1 : Form
    {
        int secs = 0;
        int mins = 0;
        int hrs = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            zeit_label.Text = ("00:00:00");
            create();
            timer.Start();
            last();
            best();
            total();
         
            first();
        }

        private void closed(object sender, FormClosedEventArgs e)
        {
            using (StreamWriter streamWriter = new StreamWriter("C:\\Users\\Public\\time.txt", true))
            {
                streamWriter.WriteLine(zeit_label.Text);
            }
        }

        private void last()
        {
            string[] last = File.ReadAllLines("C:\\Users\\Public\\time.txt");
            last_label.Text = last.Last();
        }

        private void create()
        {
            if (!File.Exists("C:\\Users\\Public\\time.txt"))
            {
                using (StreamWriter streamWriter = new StreamWriter("C:\\Users\\Public\\time.txt", true))
                {
                    streamWriter.WriteLine("00:00:00");
                }
            }

            if (!File.Exists("C:\\Users\\Public\\first.txt"))
            {
                using (StreamWriter streamWriter = new StreamWriter("C:\\Users\\Public\\first.txt", true))
                {
                    streamWriter.WriteLine("");
                }
            }
        }

        private void first()
        {
            string text = File.ReadAllText("C:\\Users\\Public\\first.txt");
            if (text.Length == 2)
            {
                using (StreamWriter streamWriter = new StreamWriter("C:\\Users\\Public\\first.txt", true))
                {
                    streamWriter.Write(DateTime.Now);
                }
            }
            string[] array = File.ReadAllLines("C:\\Users\\Public\\first.txt");
            first_label.Text = array[1].Remove(10, 9);
        }

        private void total()
        {
            string[] array = File.ReadAllLines("C:\\Users\\Public\\time.txt");
            int total_secs = 0;
            int total_mins = 0;
            int total_hrs = 0;
            int total_days = 0;
            for (int i = 0; i < array.Length; i++)
            {
                total_secs = total_secs + int.Parse(array[i].Remove(0, 6));
                total_mins = total_mins + int.Parse(array[i].Remove(0, 3).Remove(2, 3));
                total_hrs = total_hrs + int.Parse(array[i].Remove(2, 6));
            }
            total_mins = total_mins + (total_secs/60);
            total_hrs = total_hrs + (total_mins / 60);

            total_days = total_hrs/24;

            total_mins = total_mins % 60;
            total_secs = total_secs % 60;

            total_label.Text = (total_hrs + " Stunden / " + total_days + " Tage");
            /*
            //Aids
            if (total_hrs < 10 && total_mins < 10 && total_secs < 10)
            {
                total_label.Text = ("0" + total_hrs + ":0" + total_mins + ":0" + total_secs);
            }
            if (total_hrs < 10 && total_mins < 10 && total_secs >= 10)
            {
                total_label.Text = ("0" + total_hrs + ":0" + total_mins + ":" + total_secs);
            }
            if (total_hrs < 10 && total_secs < 10 && total_mins >= 10)
            {
                total_label.Text = ("0" + total_hrs + ":" + total_mins + ":0" + total_secs);
            }
            if (total_mins < 10 && total_secs < 10 && total_hrs >= 10)
            {
                total_label.Text = (total_hrs + ":0" + total_mins + ":0" + total_secs);
            }
            if (total_mins < 10 && total_secs >= 10 && total_hrs >= 10)
            {
                total_label.Text = (total_hrs + ":0" + total_mins + ":" + total_secs);
            }
            if (total_secs < 10 && total_mins >= 10 && total_hrs >= 10)
            {
                total_label.Text = (total_hrs + ":" + total_mins + ":0" + total_secs);
            }
            if (total_hrs < 10 && total_mins >= 10 && total_secs >= 10)
            {
                total_label.Text = ("0" + total_hrs + ":" + total_mins + ":" + total_secs);
            }
            if (total_hrs >= 10 && total_mins >= 10 && total_secs >= 10)
            {
                total_label.Text = (total_hrs + ":" + total_mins + ":" + total_secs);
            }
            */
            //Aids Ende

            //total_label.Text = total_hrs + ":" + total_mins + ":" + total_secs;

        }

        private void best()
        {
            string[] array = File.ReadAllLines("C:\\Users\\Public\\time.txt");
            best_label.Text = array.Max();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            secs++;
            if (secs == 60)
            {
                mins++;
                secs = 0;
            }
            if (mins == 60)
            {
                hrs++;
                mins = 0;
            }


            //Aids
            if (hrs < 10 && mins < 10 && secs < 10)
            {
                zeit_label.Text = ("0" + hrs + ":0" + mins + ":0" + secs);
            } 
            if (hrs < 10 && mins < 10 && secs >= 10)
            {
                zeit_label.Text = ("0" + hrs + ":0" + mins + ":" + secs);
            }
            if (hrs < 10 && secs < 10 && mins >= 10)
            {
                zeit_label.Text = ("0" + hrs + ":" + mins + ":0" + secs);
            }
            if (mins < 10 && secs < 10 && hrs >= 10)
            {
                zeit_label.Text = (hrs + ":0" + mins + ":0" + secs);
            }
            if (mins < 10 && secs >= 10 && hrs >= 10)
            {
                zeit_label.Text = (hrs + ":0" + mins + ":" + secs);
            }
            if (secs < 10 && mins >= 10 && hrs >= 10)
            {
                zeit_label.Text = (hrs + ":" + mins + ":0" + secs);
            }
            if (hrs < 10 && mins >= 10 && secs >= 10)
            {
                zeit_label.Text = ("0" + hrs + ":" + mins + ":" + secs);
            }
            //Aids Ende

        }
    }
}
