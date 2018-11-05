using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Android1
{
	public partial class SettingsPage : ContentPage
	{

        ApiServices apiService = new ApiServices();
        int age;
        bool passwordFlag = false;
		public SettingsPage ()
		{
            InitializeComponent ();
            InitSettings();
            LoadGestures();

		}

        private void Submit(object sender, EventArgs e)
        {
            ResetWarning();

            if (RegFieldsCheck())
            {
                //RegisterCommand.Execute(null);

            }

        }

        /*public ICommand ChangeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    bool res = await apiService.ChangeAsync(E_FName.Text, E_MName.Text, E_LName.Text, E_Email.Text, E_Password.Text, age, E_Address1.Text, E_Address2.Text, E_NTattoo.Text);
                    if (res)
                    {
                        btn_submit.Text = "success";
                    }
                });
            }

        }*/

        private bool RegFieldsCheck()
        {
            bool flag = true;

            if ((E_FName.Text == null || E_FName.Text == "") || (E_LName.Text == null || E_LName.Text == ""))
            {

                lNameWarn.Text = RegWarnings.nameWarn1;
                lNameWarn.Opacity = 1;

            }else if ((!(E_FName.Text == null || E_FName.Text == "")) && (!(E_LName.Text == null || E_LName.Text == "")))
            {
                if((E_MName.Text == null || E_MName.Text == ""))
                {
                    E_MName.Text = "";

                }
            }

                if (E_Email.Text == null || E_Email.Text == "")
            {
                EmailWarn.Text = RegWarnings.EmailWarn1;
                EmailWarn.Opacity = 1;

            }

            if (E_Password.Text == null || E_Password.Text == "")
            {
                PasswordWarn.Text = RegWarnings.PasswordWarn1;
                PasswordWarn.Opacity = 1;

            }else if(E_CPassword.Text == null || E_CPassword.Text == "")
            {
                CPasswordWarn.Text = RegWarnings.CPasswordWarn1;
                CPasswordWarn.Opacity = 1;
            }
            else if (E_Password != E_CPassword)
            {
                CPasswordWarn.Text = RegWarnings.CPasswordWarn2;
                CPasswordWarn.Opacity = 1;

                flag = false;
            }

            if (E_Age.Text == null || E_Age.Text == "")
            {
                PasswordWarn.Text = RegWarnings.PasswordWarn1;
                PasswordWarn.Opacity = 1;

            }
            else
            {
                int.TryParse(E_Age.Text, out age);
            }

            if ( (E_Address1.Text == null || E_Address1.Text == "") && (E_Address2.Text == null || E_Address2.Text == ""))
            {
                AddressWarn.Text = RegWarnings.AddressWarn1;
                AddressWarn.Opacity = 1;
            }else if (E_Address2.Text == null || E_Address2.Text == ""){ E_Address2.Text = ""; }
            else if (E_Address1.Text == null || E_Address1.Text == ""){ E_Address1.Text = "";}
        
            return flag;
        }

        public void ResetWarning()
        {
            EmailWarn.Opacity = 0;
            PasswordWarn.Opacity = 0;
            AgeWarn.Opacity = 0;
            AddressWarn.Opacity = 0;
            CPasswordWarn.Opacity = 0;
            TatttooWarn.Opacity = 0;
            GenderWarn.Opacity = 0;

        }
        public void InitSettings()
        {
            try { E_MName.Text = CurrentUser.MName; } catch { }
            
            if (CurrentUser.Gender == "Male") { E_Gender.SelectedIndex = 0; }
            else { E_Gender.SelectedIndex = 1; }

            if(CurrentUser.Theme == "dark") { E_Theme.SelectedIndex = 0; }
            else { E_Theme.SelectedIndex = 1; }
            E_FName.Text = CurrentUser.FName;
            E_LName.Text = CurrentUser.LName;
            E_Email.Text = CurrentUser.Email;
            E_Address1.Text = CurrentUser.Address1;
            E_Address2.Text = CurrentUser.Address2;
            E_PhoneN.Text = CurrentUser.PhoneNum.ToString();
            E_Age.Text = CurrentUser.Age.ToString();
            E_NTattoo.Text = CurrentUser.Num_Tattoo.ToString();

        }
        private void LoadGestures()
        {
            var changePassGesture = new TapGestureRecognizer();
            changePassGesture.Tapped += ChangePass;
            L_ChangePass.GestureRecognizers.Add(changePassGesture);


            var forgetPassGesture = new TapGestureRecognizer();
            forgetPassGesture.Tapped += ForgetPassword;
            L_ForgotPass.GestureRecognizers.Add(forgetPassGesture);

            var signOutGesture = new TapGestureRecognizer();
            signOutGesture.Tapped += SignOutPressed;
            L_SignOut.GestureRecognizers.Add(signOutGesture);
        }

        private void ChangePass(object sender, EventArgs e)
        {
            if (FormsGrid.RowDefinitions[4].Height.Value == (new GridLength(0)).Value)
            {
                FormsGrid.RowDefinitions[4].Height = new GridLength(2.5, GridUnitType.Star);
                passwordFlag = true;
            }
            else { FormsGrid.RowDefinitions[4].Height = new GridLength(0);

                passwordFlag = false;
            }

        }
        private void ForgetPassword(object sender, EventArgs e)
        {
        }

        private void BackButton(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private void SignOutPressed(Object sender, EventArgs e)
        {
            //Task.Run(() => SignOut());
        }
        private  async Task SignOut()
        {
            await Navigation.PopToRootAsync();
        }
    }
}