using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Jarvis
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void speak(string msg)
        {
            SpeechSynthesizer _synthesizer = new SpeechSynthesizer();
            _synthesizer.Speak(msg);
            _synthesizer.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            speak(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            speak("Closing this window.");
            this.Dispose();
        }
    }
}
