using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;
using System.IO;

namespace TTS
{
    public partial class Form1 : Form
    {
        private SpeechSynthesizer synth;
        System.Globalization.CultureInfo culture;
        List<string> voiceinfo;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            culture = new System.Globalization.CultureInfo(1);
            synth = new SpeechSynthesizer();
            voiceinfo = new List<string>();
           // synth.SetOutputToNull();
            foreach (InstalledVoice voice in synth.GetInstalledVoices())
            {
                VoiceInfo info = voice.VoiceInfo;
                voiceinfo.Add(info.Name);
               // comboBox1.DataSource += info.Name;
            }
                comboBox1.DataSource = voiceinfo;

           


        }
        private void label1_Click(object sender, EventArgs e)
        {
        
        }
        public static DateTime PauseForMilliSeconds(int SecondsToPauseFor)
        {
            System.DateTime ThisMoment = System.DateTime.Now;
            System.TimeSpan duration = new System.TimeSpan(0, 0, 0, SecondsToPauseFor);
            System.DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = System.DateTime.Now;
            }

            return System.DateTime.Now;
        }
        private void button1_Click(object sender, EventArgs e)//Play
        {
            string path = "D:\\Voice\\" + textBox1.Text;
            PauseForMilliSeconds(15);
            // Configure the audio output.   
             synth.SetOutputToWaveFile(@"D:\Voice\"+textBox1.Text,
             new SpeechAudioFormatInfo(32000, AudioBitsPerSample.Sixteen, AudioChannel.Mono));
            if (Directory.GetFiles(@"D:\Voice\", "*.wav").Contains(path))
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\Voice\" + textBox1.Text);
                player.Play();
            }
            else if (Directory.GetFiles(@"D:\Voice\", "*.txt").Contains(path))
            {
                
                string data = File.ReadAllText(path);
                synth.Speak(data);
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(richTextBox1.Text))
                    synth.SpeakAsync(richTextBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)//Resume
        {
            synth.Resume();
        }

        private void button4_Click(object sender, EventArgs e)//Pause
        {
            synth.Pause();
        }

        private void button3_Click(object sender, EventArgs e)//Stop
        {
            synth.SpeakAsyncCancelAll();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            synth.SelectVoice(comboBox1.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Male")
            {
                synth.SelectVoice(comboBox1.Text);
                synth.SelectVoiceByHints(VoiceGender.Male);
            }
            else
                synth.SelectVoiceByHints(VoiceGender.Female);

        }

        private void trackBar1Volume_Scroll(object sender, EventArgs e)
        {
            synth.Volume = trackBar1Volume.Value;
        }

        private void trackBar1Speed_Scroll(object sender, EventArgs e)
        {
            synth.Rate = trackBar1Speed.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
