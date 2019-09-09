using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;

namespace Jarvis
{
    public partial class Form3 : Form
    {

        static ManualResetEvent _completed = null;
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();

        public Form3()
        {
            InitializeComponent();
        }

        private void speak(string msg)
        {
            SpeechSynthesizer _synthesizer = new SpeechSynthesizer();
            _synthesizer.Speak(msg);
            _synthesizer.Dispose();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            recognizer.LoadGrammar(new Grammar(new GrammarBuilder("What is your name?")) { Name = "testGrammar" });
            recognizer.LoadGrammar(new Grammar(new GrammarBuilder("Hello Jarvis")) { Name = "testGrammar1" });
            recognizer.LoadGrammar(new Grammar(new GrammarBuilder("How are you?")) { Name = "testGrammar2" });
            recognizer.LoadGrammar(new Grammar(new GrammarBuilder("Who is the most handsome guy?")) { Name = "testGrammar4" });
            recognizer.LoadGrammar(new Grammar(new GrammarBuilder("Close window")) { Name = "testGrammar5" });
            //recognizer.LoadGrammar(new Grammar(new GrammarBuilder("Hello")) { Name = "testGrammar4" });

            recognizer.SpeechRecognized += _recognizer_SpeechRecognized;
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            //recognizer.SpeechRecognitionRejected += _recognizer_SpeechRecognitionRejected;
        }

        void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            DateTime time = DateTime.Now;
            string AM_PM;
            string PM_EVE;
            AM_PM = time.ToLongTimeString().Substring(time.ToLongTimeString().Length - 2);
            PM_EVE = time.ToLongTimeString().Substring(time.ToLongTimeString().Length - 10);

            if (e.Result.Text == "What is your name?")
            {
                speak("Hello sir my name is Jarvis.");
            }
            else if (e.Result.Text == "Hello Jarvis")
            {
                if (AM_PM == "AM")
                {
                    speak("Good Morning sir");
                }
                else
                {
                    if (Convert.ToDateTime(PM_EVE) >= Convert.ToDateTime("7:00 PM"))
                    {
                        speak("Good evening sir");
                    }
                    else
                    {
                        speak("Good afternoon sir");
                    }
                }
            }
            else if (e.Result.Text == "How are you?")
            {
                speak("I'm doing well, thanks for asking.");
            }

            else if (e.Result.Text == "Who is the most handsome guy?")
            {
                speak("the most handsome guy here in S T I is Sir Jonathan Lorenzo.");
            }
            else if(e.Result.Text == "Close window")
            {
                speak("Terminating this form.");
                this.Dispose();
            }
            else
            {
                _completed.Set();
            }
        }

    }
}
