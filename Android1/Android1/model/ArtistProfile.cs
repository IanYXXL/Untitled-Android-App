using System;
using System.Collections.Generic;
using System.Text;

namespace Android1
{
    public class ArtistProfile {

        public string name { get; set; }
        public string specialty { get; set; }
        public string imageSrc { get; set; }
        public string imageIcon { get; set; }
        public string about { get; set; }
        public bool visibility { get; set; }
        public bool invisibility { get; set; }

        public ArtistProfile(string name, string imageSrc,string imageIcon, string specialty, string about)
        {
            this.name = name;
            this.specialty = specialty;
            this.imageSrc = imageSrc;
            this.about = about;
            this.imageIcon = imageIcon;
            this.visibility = false;
            this.invisibility = true;
        }
        

    }
}
