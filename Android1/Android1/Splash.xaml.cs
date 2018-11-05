using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Android1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Splash : ContentPage
	{
		public Splash ()
		{
			InitializeComponent ();
            ChooseInit();

		}

        void ChooseInit()
        {
            Thread.Sleep(2000);

            var loginPage = new Login();
            NavigationPage.SetHasNavigationBar(loginPage, false);
            Navigation.PushAsync(loginPage);

        }
	}
}