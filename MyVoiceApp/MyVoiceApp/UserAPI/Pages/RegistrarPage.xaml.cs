using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVoiceApp.UserAPI.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyVoiceApp.UserAPI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarPage : ContentPage
    {
        public User CurrUser = new User();

        public RegistrarPage()
        {
            InitializeComponent();
        }


        public void Saveform()
        {
            CurrUser.First = txtfirst.Text;
            CurrUser.Last = txtlast.Text;
            CurrUser.UserName = txtusername.Text;
            CurrUser.Password = txtpassword.Text;
            CurrUser.Email = txtemail.Text;
            CurrUser.Address = txtaddress.Text;
            CurrUser.City = txtcity.Text;
            CurrUser.State = txtstate.Text;
            CurrUser.Zip = txtzip.Text;
     //       CurrUser.Company = txtcompany.Text;
            CurrUser.Phone = txtphone.Text;
        }

        public void LoadForm()
        {
            txtfirst.Text = CurrUser.First;
            txtlast.Text = CurrUser.Last;
            txtusername.Text = CurrUser.UserName;
            txtpassword.Text = CurrUser.Password;
            txtemail.Text = CurrUser.Email;
            txtaddress.Text = CurrUser.Address;
            txtcity.Text = CurrUser.City;
            txtstate.Text = CurrUser.State;
            txtzip.Text = CurrUser.Zip;
//            txtcompany.Text = CurrUser.Company;
            txtphone.Text = CurrUser.Phone;
        }

        private void Butreg(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}