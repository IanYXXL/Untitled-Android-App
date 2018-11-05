using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Android1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Rewards : ContentPage
	{
		public Rewards ()
		{
			InitializeComponent ();
            PopulatePage();
            LoadGestures();
        }

        private void Appointment_Clicked(object sender, EventArgs e)
        {
            var AppointmentPage = new AppointmentForm();
            NavigationPage.SetHasNavigationBar(AppointmentPage, false);
            Navigation.PushAsync(AppointmentPage);

        }

        public void PopulatePage()
        {
            WelcomeMsg.Text = "Welcome " + CurrentUser.FName +" " + CurrentUser.LName+ ", you have";
            PointsNum.Text = CurrentUser.Points.ToString();
            SettingsButton.Source = Links.settingsIcon;
            QrButton.Source = Links.qrIcon;
            Banner.Source = Links.banner;

        }

        private async void QrTap(object sender, EventArgs e)
        {

            await PopupNavigation.Instance.PushAsync(new Qr());
        }

        private void SettingsTap (object sender, EventArgs e)
        {
            var settings = new SettingsPage();
            NavigationPage.SetHasNavigationBar(settings, false);
            Navigation.PushAsync(settings);
        }

        private void LoadGestures()
        {

            var appointmentGesture = new TapGestureRecognizer();
            var qrGesture = new TapGestureRecognizer();
            var settingsGesture = new TapGestureRecognizer();

            qrGesture.Tapped += QrTap;
            settingsGesture.Tapped += SettingsTap;
            appointmentGesture.Tapped += Appointment_Clicked;

            AppointmentSection.GestureRecognizers.Add(appointmentGesture);
            AppointmentBtn.GestureRecognizers.Add(appointmentGesture);
            QrButton.GestureRecognizers.Add(qrGesture);
            SettingsButton.GestureRecognizers.Add(settingsGesture);
        }
    }
}