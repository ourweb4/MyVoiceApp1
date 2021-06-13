using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyVoiceApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var app = Application.Current as App;
            swauto.IsToggled = app.autoflag;
        }

	    protected override void OnDisappearing()
	    {
	        base.OnDisappearing();
	        var app = Application.Current as App;
	        app.autoflag = swauto.IsToggled;
	    }
	}
}