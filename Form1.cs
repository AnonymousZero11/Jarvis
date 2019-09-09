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
    public partial class Form1 : Form
    {

        static ManualResetEvent _completed = null;
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        int counter = 0;

        public Form1()
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
            
            speak("I am glad for choosing this module.");
            Form2 form2 = new Form2();
            form2.ShowDialog();
            
        }

        private void unloadGrammars()
        {
            try
            {
                foreach (Grammar gr in recognizer.Grammars)
                {
                    recognizer.UnloadGrammar(gr);
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            recognizer.LoadGrammar(new Grammar(new GrammarBuilder("Text to Speech.")) { Name = "testGrammar" });
            recognizer.LoadGrammar(new Grammar(new GrammarBuilder("Voice Recognition.")) { Name = "testGrammar1" });
            recognizer.LoadGrammar(new Grammar(new GrammarBuilder("Trivia Question.")) { Name = "testGrammar2" });
            //recognizer.LoadGrammar(new Grammar(new GrammarBuilder("Hello")) { Name = "testGrammar4" });

            recognizer.SpeechRecognized += _recognizer_SpeechRecognized;
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            //recognizer.SpeechRecognitionRejected += _recognizer_SpeechRecognitionRejected;
        }

        void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string result = e.Result.Text;
            if (result == "Text to Speech.")
            {
                speak("I am glad for choosing this module.");
                Form2 form2 = new Form2();
                form2.ShowDialog();
                
            }
            else if (result == "Voice Recognition.")
            {
                speak("Right away sir.");
                Form3 form3 = new Form3();
                form3.ShowDialog();
            }
            else if (result == "Trivia Question.")
            {
                speak("Affirmative.");
                Form4 form4 = new Form4();
                form4.ShowDialog();
            }
            else
            {
                _completed.Set();
            }

            //unloadGrammars();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            //unloadGrammars();
            
            
            //counter++;
            //if (counter == 1)
            //{
            //    DateTime time = DateTime.Now;
            //    string AM_PM;
            //    string PM_EVE;
            //    AM_PM = time.ToLongTimeString().Substring(time.ToLongTimeString().Length - 2);
            //    PM_EVE = time.ToLongTimeString().Substring(time.ToLongTimeString().Length - 10);

            //    if (AM_PM == "AM")
            //    {
            //        speak("Good Morning sir Jonathan Lorenzo, it is good to see you again, it is currently " + time.ToLongTimeString().Replace(':',' ') + ", what would you like me to do first.");
            //    }
            //    else
            //    {
            //        if (Convert.ToDateTime(PM_EVE) >= Convert.ToDateTime("7:00 PM"))
            //        {
            //            speak("Good evening sir Jonathan Lorenzo, it is good to see you again, it is currently " + time.ToLongTimeString().Replace(':', ' ') + ", what would you like me to do first.");
            //        }
            //        else
            //        {
            //            speak("Good afternoon sir Jonathan Lorenzo, it is good to see you again, it is currently " + time.ToLongTimeString().Replace(':', ' ') + ", what would you like me to do first.");
            //        }
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            speak("Right away sir.");
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            speak("Affirmative.");
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            //unloadGrammars();
        }

    }
}
