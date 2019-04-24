// ***********************************************************************
// Assembly         : MyVoiceApp.UWP
// Author           : Bill Banks
// Created          : 03-13-2019
//
// Last Modified By : Bill Banks
// Last Modified On : 03-13-2019
// ***********************************************************************
// <copyright file="MainPage.xaml.cs" company="Ourweb.net">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MyVoiceApp;

namespace MyVoiceApp.UWP
{
    /// <summary>
    /// Class MainPage. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.UWP.WindowsPage" />
    public sealed partial class MainPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            string dbname = "data.sqlite";
            StorageFolder currentLocalFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string dbpath = currentLocalFolder.Path;
            string fullpath = Path.Combine(dbpath, dbname);

            LoadApplication(new MyVoiceApp.App(fullpath));
        }
    }
}
