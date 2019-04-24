using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyVoiceApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = String.Empty;

        private const string _ver = "Ver 1.0.0";

        // settings keys

        public const string AutoKey = "AUTO";


        public string Version
        {
            get { return _ver; }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaseLocation)
        {

            InitializeComponent();

            DatabaseLocation = databaseLocation;

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public bool autoflag
        {
            set
            {
                Properties[AutoKey] = value;
                SavePropertiesAsync();

            }
            get
            {
                if (Properties.ContainsKey(AutoKey) == false)
                {
                    return true;
                }
                return (bool)Properties[AutoKey];


            }
        }

    }
}
