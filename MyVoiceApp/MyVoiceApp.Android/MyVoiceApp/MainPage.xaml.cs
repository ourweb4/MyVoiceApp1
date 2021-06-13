using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyVoiceApp
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void SpeakNow(string words)
        {
            TextToSpeech.SpeakAsync(words).ContinueWith((t) =>
            {
                // Logic that will run after utterance finishes.

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
