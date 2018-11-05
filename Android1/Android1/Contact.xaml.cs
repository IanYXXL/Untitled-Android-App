using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;


namespace Android1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Contact : ContentPage
	{
		public Contact ()
		{
            InitializeComponent();
            LoadGestures();
            LoadLinks();
        }

        private async void Image1Tap(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new ImgPopup(Links.store1));

        }

        private async void Image2Tap(object sender, EventArgs e)
        {

            await PopupNavigation.Instance.PushAsync(new ImgPopup(Links.store2));
        }

        private async void Image3Tap(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new ImgPopup(Links.store3));
        }

        private void TalkEmail(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("mailto:"+ talkEmailBtn.Text));
        }
        private void MediaEmail(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("mailto:"+ mediaEmailBtn.Text));
        }
        private void WebsiteVisit(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(Links.website));
        }

        private void LoadGestures()
        {
            var tapImageRecognizer1 = new TapGestureRecognizer();
            tapImageRecognizer1.Tapped += Image1Tap;
            var tapImageRecognizer2 = new TapGestureRecognizer();
            tapImageRecognizer2.Tapped += Image2Tap;
            var tapImageRecognizer3 = new TapGestureRecognizer();
            tapImageRecognizer3.Tapped += Image3Tap;

            var talkLink = new TapGestureRecognizer();
            talkLink.Tapped += TalkEmail;
            var mediaLink = new TapGestureRecognizer();
            mediaLink.Tapped += MediaEmail;
            var websiteLink = new TapGestureRecognizer();
            websiteLink.Tapped += WebsiteVisit;

            ShopImage1.GestureRecognizers.Add(tapImageRecognizer1);
            ShopImage2.GestureRecognizers.Add(tapImageRecognizer2);
            ShopImage3.GestureRecognizers.Add(tapImageRecognizer3);

            talkEmailBtn.GestureRecognizers.Add(talkLink);
            mediaEmailBtn.GestureRecognizers.Add(mediaLink);
            websiteBtn.GestureRecognizers.Add(websiteLink);
        }
        private void LoadLinks()
        {
            ShopImage1.Source = Links.store1Icon;
            ShopImage2.Source = Links.store2Icon;
            ShopImage3.Source = Links.store3Icon;
            websiteBtn.Text = Links.website;
            talkEmailBtn.Text = Links.talkEmail;
            mediaEmailBtn.Text = Links.mediaEmail;
            mapPlaceholder.Source = Links.mapFiller;
            mapPlaceholder.HorizontalOptions = LayoutOptions.Center;
            mapPlaceholder.Aspect = Aspect.AspectFit;
        }
    }
}