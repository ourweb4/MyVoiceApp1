// ***********************************************************************
// Assembly         : MyVoiceApp
// Author           : Bill   Banks
// Created          : 03-18-2021
//
// Last Modified By : Bill   Banks
// Last Modified On : 06-13-2021
// ***********************************************************************
// <copyright file="RegistarPage.xaml.cs" company="MyVoiceApp">
//     Copyright (c) Ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MyVoiceApp.Models;
using System;
using Plugin.FirebaseAuth;
using Plugin.CloudFirestore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyVoiceApp.Pages
{
    /// <summary>
    /// Class RegistarPage.
    /// Implements the <see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistarPage : ContentPage
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistarPage" /> class.
        /// </summary>
        public RegistarPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Clicked event of the save control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private async void  save_Clicked(object sender, EventArgs e)
        {
            var em = txtemail.Text;
            var pw = txtpassword.Text;
            if (em != null && pw != null )
            {
                try
                {
                    var result = await CrossFirebaseAuth.Current.Instance.CreateUserWithEmailAndPasswordAsync(em, pw);
                    var uid = result.User.Uid;
                    if (uid != null)
                    {
                        User user = new User();
                        var app = Application.Current as App;
                        app.ukey = uid;
                        user.Uid = uid;
                        user.address = txtaddress.Text;
                        user.city = txtcity.Text;
                        user.email = em;
                        user.first = txtfirstname.Text;
                        user.phone = txtphone.Text;
                        user.state = txtstate.Text;
                        user.zip = txtzip.Text;
                        user.last = txtlastname.Text;
                        await CrossCloudFirestore.Current
                             .Instance
                             .Collection("users")

                             .AddAsync<User>(user);

                        await Navigation.PushModalAsync(new ToolPage());
                    }
                    else
                    {

                        await DisplayAlert("Error", "User cant be created ", "OK");
                    }
                    }
        catch (Exception ex)
              
                {
                    await DisplayAlert("Error", ex.Message, "OK");

                }
            }
            else
            {
               await  DisplayAlert("Error", "Email/password cant be blank", "OK");
            }
            
        }
    }
}