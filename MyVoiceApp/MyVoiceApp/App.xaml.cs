// ***********************************************************************
// Assembly         : MyVoiceApp
// Author           : Bill   Banks
// Created          : 03-13-2019
//
// Last Modified By : Bill   Banks
// Last Modified On : 06-01-2021
// ***********************************************************************
// <copyright file="App.xaml.cs" company="MyVoiceApp">
//     Copyright (c) Ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyVoiceApp
{
    /// <summary>
    /// Class App.
    /// Implements the <see cref="Xamarin.Forms.Application" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Application" />
    public partial class App : Application
    {
        /// <summary>
        /// The database location
        /// </summary>
        public static string DatabaseLocation = String.Empty;

        /// <summary>
        /// The ver
        /// </summary>
        private const string _ver = "Ver 1.5.1";

        // settings keys

        /// <summary>
        /// The automatic key
        /// </summary>
        public const string AutoKey = "AUTO";
        /// <summary>
        /// The uu key
        /// </summary>
        public const string UUKey = "UKey";

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        public string Version
        {
            get { return _ver; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <param name="databaseLocation">The database location.</param>
        public App(string databaseLocation)
        {

            InitializeComponent();

            DatabaseLocation = databaseLocation;

            MainPage = new NavigationPage(new MainPage());
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application starts.
        /// </summary>
        /// <remarks>To be added.</remarks>
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application enters the sleeping state.
        /// </summary>
        /// <remarks>To be added.</remarks>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application resumes from a sleeping state.
        /// </summary>
        /// <remarks>To be added.</remarks>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="App"/> is autoflag.
        /// </summary>
        /// <value><c>true</c> if autoflag; otherwise, <c>false</c>.</value>
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


        /// <summary>
        /// Gets or sets the ukey.
        /// </summary>
        /// <value>The ukey.</value>
        public string  ukey
        {
            set
            {
                Properties[UUKey] = value;

                SavePropertiesAsync();

            }
            get
            {
                if (Properties.ContainsKey(UUKey) == false)
                {
                    return null;
                }
                return (string )Properties[UUKey];


            }
        }

    }
}
