using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Android1
{
    [ContentProperty("Source")]
    public class ImageResourceExtension : Xamarin.Forms.Xaml.IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(Source);

            return imageSource;
        }
    }
}
