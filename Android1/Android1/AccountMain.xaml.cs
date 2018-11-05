using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Android1
{
	public partial class AccountMain : TabbedPage
	{
		public AccountMain ()
        {
            InitializeComponent();
        }
        
        protected override bool OnBackButtonPressed()
        {
            if (this.CurrentPage.Title== "Home")
            {
            }
            else { this.CurrentPage = this.Children[0];}
            return true;
        }

    }
}