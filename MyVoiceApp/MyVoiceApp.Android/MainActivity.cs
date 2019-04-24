// ***********************************************************************
// Assembly         : MyVoiceApp.Android\
// Author           : Bill Banks
// Created          : 03-13-2019
//
// Last Modified By : Bill Banks
// Last Modified On : 03-13-2019
// ***********************************************************************
// <copyright file="MainActivity.cs" company="Ourweb.net">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Provider;
using Environment = System.Environment;

namespace MyVoiceApp.Droid
{
    /// <summary>
    /// Class MainActivity.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.FormsAppCompatActivity" />
    [Activity(Label = "MyVoiceApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="savedInstanceState">State of the saved instance.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            string dbname = "data.sqlite";
            string dbpath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string fullpath = Path.Combine(dbpath, dbname);


            LoadApplication(new App(fullpath));
       }
    }
}