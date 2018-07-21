using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace At_Yarışı
{
    public partial class Form1 : Form
    {
        
        Random dice = new Random();
        string path_horse;
        string path_applause;
        public Form1()
        {
            InitializeComponent();
            label6.Text = ("Saddle up your steed and guess a winner?");
            path_horse = Path.GetFullPath(@"..\..\raw\horse.mp3");
            path_applause = Path.GetFullPath(@"..\..\raw\applause.mp3");
            axWindowsMediaPlayer1.URL = path_horse;



        }
       
      

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label6.Text = ("START");
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left+=dice.Next(2, 15);
            pictureBox2.Left += dice.Next(2, 15);
            pictureBox3.Left += dice.Next(2, 15);
            int bitiş = label5.Left;
            int biren = pictureBox1.Width;
            int ikien = pictureBox2.Width;
            int üçen = pictureBox3.Width;

            if(pictureBox1.Left > pictureBox2.Left + 5 && pictureBox1.Left > pictureBox3.Left + 5)
            {
                label6.Text = ("Unbeatable Speed. First Jockey gone wild");
            }
            if (pictureBox2.Left > pictureBox1.Left + 5 && pictureBox2.Left > pictureBox3.Left + 5)
            {
                label6.Text = ("Horse #2 is in good shape ladies and gentlemen. Someone must exercise a lot !");
            }
            if (pictureBox3.Left > pictureBox1.Left + 5 && pictureBox3.Left > pictureBox1.Left + 5)
            {
                label6.Text = ("Now, the leader is Horse Number #3!");
            }



            if (pictureBox1.Left + biren >= bitiş)
            {
                Play();
                timer1.Enabled = false;
                label6.ForeColor = Color.White;
                label6.Text = ("Winner is Horse #1!");
               
            }
            if (pictureBox2.Left + ikien >= bitiş)
            {
                Play();
                timer1.Enabled = false;
                label6.ForeColor = Color.White;
                label6.Text = ("Winner is Horse #2");
                
            }
            if (pictureBox3.Left + üçen >= bitiş)
            {
                Play();
                timer1.Enabled = false;
                label6.ForeColor = Color.White;
                label6.Text = ("Winner is Horse #1");
                
          
            }
        }

        private void Play()
        {
            axWindowsMediaPlayer1.URL = path_applause;
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Left = 0;
            pictureBox2.Left = 0;
            pictureBox3.Left = 0;
            axWindowsMediaPlayer1.close();
            axWindowsMediaPlayer1.URL = path_horse;
            label6.Text = "";

        }

        private void axWindowsMediaPlayer2_Enter(object sender, EventArgs e)
        {

        }
    }
}
