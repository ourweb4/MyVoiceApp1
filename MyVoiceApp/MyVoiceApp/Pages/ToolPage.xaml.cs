// ***********************************************************************
// Assembly         : MyVoiceApp
// Author           : Bill   Banks
// Created          : 03-25-2021
//
// Last Modified By : Bill   Banks
// Last Modified On : 04-03-2021
// ***********************************************************************
// <copyright file="ToolPage.xaml.cs" company="MyVoiceApp">
//     Copyright (c) Ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MyVoiceApp.Models;
using MyVoiceApp.Utilys;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyVoiceApp.Pages
{
    /// <summary>
    /// Class ToolPage.
    /// Implements the <see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolPage : ContentPage
    {
        /// <summary>
        /// The database
        /// </summary>
        private Database db = new Database();

        /// <summary>
        /// The words
        /// </summary>
        private IList<Word> words;

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        /// <value>The uid.</value>
        public string uid { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolPage"/> class.
        /// </summary>
        public ToolPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>To be added.</remarks>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var app = Application.Current as App;
            uid = app.ukey;
            if (uid == null)
            {
                Navigation.PushModalAsync(new LoginPage()); 
            }

        }

        /// <summary>
        /// Handles the Clicked event of the Backup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Backup_Clicked(object sender, EventArgs e)
        {
             try { 
            var app = Application.Current as App;
            uid = app.ukey;
            ReadDB();
            var rec = new DataFB();
            rec.Uid = uid;

            var docs = await CrossCloudFirestore.Current
                .Instance
                .Collection("data")
                .WhereEqualsTo("Uid", uid)
                .GetAsync();
            foreach (var fbdoc in docs.Documents)
            {
                await CrossCloudFirestore.Current
                           .Instance
                           .Collection("data")
                           .Document(fbdoc.Id)
                           .DeleteAsync();
            }

            foreach (var w in words)
            {
                rec.word = w;
                await CrossCloudFirestore.Current
                 .Instance
                 .Collection("data")
                 .AddAsync<DataFB>(rec);

            }
            await DisplayAlert("Success", "Backup as been completed", "OK");

            }
            catch (Exception ex)

            {
                await DisplayAlert("Error", ex.Message, "OK");

            }
        }

        /// <summary>
        /// Handles the Clicked event of the Restore control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Restore_Clicked(object sender, EventArgs e)
        {
            try { 
            ReadDB();
            foreach (var w in words)
            {
                db.DeleteWord(w);
            }
            var q = await        CrossCloudFirestore.Current.Instance
                .Collection("data")
                .WhereEqualsTo("Uid", uid)
                .GetAsync();
            var recs = q.ToObjects<DataFB>();
            foreach (var rec in recs)
            {
                rec.word.Id = 0;
                db.WriteWord(rec.word);

            }

            await DisplayAlert("Success", "Restore as been completed", "OK");
            }
            catch (Exception ex)

            {
                await DisplayAlert("Error", ex.Message, "OK");

            }
        }


        /// <summary>
        /// Reads the database.
        /// </summary>
        private void ReadDB()
        {
            words = new List<Word>();

            words = db.ReadWords();

         //   ListWords.ItemsSource = words;
            //       NewWord();
        }

        private void Logoff_Clicked(object sender, EventArgs e)
        {

            var app = Application.Current as App;
            app.ukey = null;
            uid = app.ukey;
            if (uid == null)
            {
                Navigation.PushModalAsync(new LoginPage());
            }

        }

    }
}