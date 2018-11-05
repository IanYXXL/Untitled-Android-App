using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Net.Http;

namespace Android1
{
	public partial class Register : ContentPage
	{

        ApiServices apiService = new ApiServices();
        int age;

		public Register ()
		{
            //warnings = new Label[] {EmailWarn,PasswordWarn, CPasswordWarn, AgeWarn, AddressWarn, GenderWarn, TatttooWarn };
			InitializeComponent ();

		}

        private void Submit(object sender, EventArgs e)
        {
            ResetWarning();

            if (RegFieldsCheck())
            {
                //RegisterCommand.Execute(null);
            }
            RegisterCommand.Execute(null);

        }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                     HttpContent res = await apiService.RegisterAsync(E_FName.Text, E_MName.Text, E_LName.Text, E_Email.Text, E_Password.Text, E_Birthday.Date, E_Address1.Text, E_Address2.Text, E_NTattoo.Text, E_Gender.Items[E_Gender.SelectedIndex], E_PhoneN.Text);
                    /*if (res)
                    {
                        btn_submit.Text = "success";
                    }*/
                     TatttooWarn.Text =  await res.ReadAsStringAsync();
                });
            }

        }

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
            else if (E_Password.Text != E_CPassword.Text)
            {
                CPasswordWarn.Text = RegWarnings.CPasswordWarn2;
                CPasswordWarn.Opacity = 1;

                flag = false;
            }

            /*if (E_Age.Text == null || E_Age.Text == "")
            {
                PasswordWarn.Text = RegWarnings.PasswordWarn1;
                PasswordWarn.Opacity = 1;

            }
            else
            {
                int.TryParse(E_Age.Text, out age);
            }*/

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
            //AgeWarn.Opacity = 0;
            AddressWarn.Opacity = 0;
            CPasswordWarn.Opacity = 0;
            TatttooWarn.Opacity = 0;
            GenderWarn.Opacity = 0;

        }
        private void BackButton(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}