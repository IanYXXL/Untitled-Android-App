using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Android1
{
	public partial class Login : ContentPage
	{

        ApiServices apiService = new ApiServices();
		public Login()
		{
			InitializeComponent();

            //this.Navigation.RemovePage(this.Navigation.NavigationStack[1]);

            LoadGestures();

		}

        private void Login_Clicked(Object sender, EventArgs e)
        {
            User user = new User(E_Email.Text, E_Password.Text);

            //LoginCommand.Execute(null);
            if (user.AttemptLogin())
            {
                var mainPage = new AccountMain();
                NavigationPage.SetHasNavigationBar(mainPage, false);
                Navigation.PushAsync(mainPage);
            }
        }

        private void Register_Clicked(Object sender, EventArgs e)
        {

            var registrationPage = new Register();
            NavigationPage.SetHasNavigationBar(registrationPage, false);
            Navigation.PushAsync(registrationPage);
        }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    string res = await apiService.LoginAsync(E_Email.Text, E_Password.Text);
                    /*if (res)
                    {
                        loginWarn.Text = "success";
                    }
                    else
                    {
                        loginWarn.Text = "fail";
                    }*/
                    loginWarn.Text = res;

                });
            }

        }

        private void ToWebsite(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.untitledtattoo.com"));
        }

        private void LoadGestures()
        {
            var forgotPassGesture = new TapGestureRecognizer();
            forgotPassGesture.Tapped += ForgotPassword;
            L_ForgotPass.GestureRecognizers.Add(forgotPassGesture);

            var websiteGesture = new TapGestureRecognizer();
            websiteGesture.Tapped += ToWebsite;
            websiteURL.GestureRecognizers.Add(websiteGesture);
        }

        private void ForgotPassword(object sender, EventArgs e) { }


    }

}
