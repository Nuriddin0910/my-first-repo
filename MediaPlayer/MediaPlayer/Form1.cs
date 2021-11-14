using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class MediaPlayer : Form
    {
        public MediaPlayer()
        {
            InitializeComponent();
          
        
        }
        string[] paths, files;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
            label5.Text = "Playing...";


          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            label5.Text = "Pause...";
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if(ofd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames;
                paths = ofd.FileNames;
                for(int x=0;x<files.Length;x++)
                {
                    Medialar.Items.Add(files[x]);
                }
            }
        }

        private void Medialar_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = paths[Medialar.SelectedIndex];
            axWindowsMediaPlayer1.Ctlcontrols.play();
            label5.Text = "Playing...";
            timer1.Start();
            trackBar1.Value = 15;
            label4.Text = trackBar1.Value.ToString() + "%";
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if(Medialar.SelectedIndex<Medialar.Items.Count-1)
            {
                Medialar.SelectedIndex = Medialar.SelectedIndex + 1;
            }
        }

        private void Previus_Click(object sender, EventArgs e)
        {
            if(Medialar.SelectedIndex>0)
            {
                Medialar.SelectedIndex = Medialar.SelectedIndex - 1;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
            label4.Text = trackBar1.Value.ToString();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if(axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressBar1.Maximum = (int)axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration;
                progressBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition; 
            }
            label1.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
            label2.Text = axWindowsMediaPlayer1.Ctlcontrols.currentItem.durationString.ToString();

        }
    }
}
