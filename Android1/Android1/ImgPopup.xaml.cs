
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
	public partial class ImgPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
		public ImgPopup (string Url)
		{
            InitializeComponent();
            popupImage.Source = Url;
            //popupImage.Rotation = 90;
            popupImage.HorizontalOptions = LayoutOptions.CenterAndExpand;
        }
        
    }
}