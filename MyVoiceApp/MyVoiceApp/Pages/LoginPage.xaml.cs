// ***********************************************************************
// Assembly         : MyVoiceApp
// Author           : Bill   Banks
// Created          : 03-22-2021
//
// Last Modified By : Bill   Banks
// Last Modified On : 04-03-2021
// ***********************************************************************
// <copyright file="LoginPage.xaml.cs" company="MyVoiceApp">
//     Copyright (c) Ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Plugin.FirebaseAuth;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyVoiceApp.Pages
{
    /// <summary>
    /// Class LoginPage.
    /// Implements the <see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Clicked event of the btnlogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btnlogin_Clicked(object sender, EventArgs e)
        {
            var em = txtemail.Text;
            var pw = txtpassword.Text;
            // With Credential
            var credential = CrossFirebaseAuth.Current.EmailAuthProvider.GetCredential(em , pw);
            await CrossFirebaseAuth.Current.Instance.CurrentUser.ReauthenticateAsync(credential);
            var uid = CrossFirebaseAuth.Current.Instance.CurrentUser.Uid;
            if (uid != null)
            {
                var app = Application.Current as App;
                app.ukey = uid;
               await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Login failed", "OK");

            }



        }

        /// <summary>
        /// Handles the Clicked event of the btnreg control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btnreg_Clicked(object sender, EventArgs e)
        {
         await   Navigation.PushModalAsync(new RegistarPage());


        }
    }
}
