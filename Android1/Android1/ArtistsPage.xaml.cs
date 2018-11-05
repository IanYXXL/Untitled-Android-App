using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Xamarin.Forms.Core;

namespace Android1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ArtistsPage : ContentPage
	{
        public ObservableCollection<ArtistProfile> ArtistCollection { get; set; }

		public ArtistsPage ()
		{

            ArtistCollection = GetArtists();
			InitializeComponent ();
            artistList.ItemsSource = ArtistCollection;

		}

        public ObservableCollection<ArtistProfile> GetArtists()
        {

            return new ObservableCollection<ArtistProfile> {
                new ArtistProfile("T.Dot.Dave","https://static.wixstatic.com/media/72095d_c9f16a3578fe4e009959b7d320632985~mv2_d_1575_1575_s_2.jpg","http://www.personalbrandingblog.com/wp-content/uploads/2017/08/blank-profile-picture-973460_640-300x300.png","Blacks, greys, cover ups","bio" ),
                new ArtistProfile("Jane","http://www.personalbrandingblog.com/wp-content/uploads/2017/08/blank-profile-picture-973460_640-300x300.png","http://www.personalbrandingblog.com/wp-content/uploads/2017/08/blank-profile-picture-973460_640-300x300.png" ,"Tattoo Artist", "bio")

            };
        }

        void OnTap (object sender, ItemTappedEventArgs e)
        {
            var artistSelected = e.Item as ArtistProfile;
            ToggleVisibility(artistSelected);

        }

        public void ToggleVisibility (ArtistProfile artist)
        {
            var index = ArtistCollection.IndexOf(artist);
            artist.visibility = !artist.visibility;
            artist.invisibility = !artist.invisibility;

            ArtistCollection.Remove(artist);
            ArtistCollection.Insert(index, artist);
        }

    }
}