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
	public partial class HelpPage : ContentPage
	{
	    public string version;

        public HelpPage ()
		{
			InitializeComponent ();
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        var app = Application.Current as App;
	        version = app.Version;
	        vlabel.Text = version;
			var key = app.ukey;
			klabel.Text = key;
	    }
	}
}