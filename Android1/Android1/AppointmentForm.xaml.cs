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
	public partial class AppointmentForm : ContentPage
	{
        public DateTime today = DateTime.Today;
        public DateTime maxDate = DateTime.Today.AddMonths(3);
        public string SkinColor { get; set; }
		public AppointmentForm ()
		{
			InitializeComponent ();
            InitAppointmentForm();
		}

        private void Submit(object sender, EventArgs e)
        {

        }

        private void Color1_Clicked(object sender, EventArgs e)
        {
            SelectColor("1");
            //colorSelected.BackgroundColor = Color.FromHex("#ffe7bc");
        }

        private void Color2_Clicked(object sender, EventArgs e)
        {
            SelectColor("2");
            //colorSelected.BackgroundColor = Color.FromHex("#fac595");
        }

        private void Color3_Clicked(object sender, EventArgs e)
        {
            SelectColor("3");
            //colorSelected.BackgroundColor = Color.FromHex("#c97c56");
        }

        private void Color4_Clicked(object sender, EventArgs e)
        {
            SelectColor("4");
            //colorSelected.BackgroundColor = Color.FromHex("#76371c");
        }

        private void SelectColor(string color)
        {
            switch (color)
            {
                case "1":
                    SkinColor = "light";
                    Color1.BorderColor = Color.White;
                    Color2.BorderColor = Color.Transparent;
                    Color3.BorderColor = Color.Transparent;
                    Color4.BorderColor = Color.Transparent;
                    break;
                case "2":
                    SkinColor = "tan";
                    Color2.BorderColor = Color.White;
                    Color1.BorderColor = Color.Transparent;
                    Color3.BorderColor = Color.Transparent;
                    Color4.BorderColor = Color.Transparent;
                    break;
                case "3":
                    SkinColor = "brown";
                    Color3.BorderColor = Color.White;
                    Color2.BorderColor = Color.Transparent;
                    Color1.BorderColor = Color.Transparent;
                    Color4.BorderColor = Color.Transparent;
                    break;
                case "4":
                    SkinColor = "dark";
                    Color4.BorderColor = Color.White;
                    Color2.BorderColor = Color.Transparent;
                    Color3.BorderColor = Color.Transparent;
                    Color1.BorderColor = Color.Transparent;
                    break;
            }
        }

        public void InitAppointmentForm()
        {
            try { E_MName.Text = CurrentUser.MName; }catch { }

            try { SkinColor = CurrentUser.SkinColor;
                switch (SkinColor)
                {
                    case "light":
                        Color1.BorderColor = Color.White;
                        break;
                    case "tan":
                        Color2.BorderColor = Color.White;
                        break;
                    case "brown":
                        Color3.BorderColor = Color.White;
                        break;
                    case "dark":
                        Color4.BorderColor = Color.White;
                        break;
                }}catch { }

            if (CurrentUser.Gender == "Male") { E_Gender.SelectedIndex = 0; }
            else { E_Gender.SelectedIndex = 1; }

            E_FName.Text = CurrentUser.FName;
            E_LName.Text = CurrentUser.LName;
            E_Email.Text = CurrentUser.Email;
            E_Address1.Text = CurrentUser.Address1;
            E_Address2.Text = CurrentUser.Address2;
            E_PhoneN.Text = CurrentUser.PhoneNum.ToString();
            E_Age.Text = CurrentUser.Age.ToString();

            E_Date.MinimumDate = today;
            E_Date.MaximumDate = maxDate;
            
        }

        public void AppointmentSubmit()
        {

        }

        private void BackButton(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}