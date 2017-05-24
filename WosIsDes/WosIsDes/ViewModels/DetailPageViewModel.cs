using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WosIsDes.Models;
using Xamarin.Forms;

namespace WosIsDes.ViewModels
{
    public class DetailPageViewModel :BaseViewModel
    {
        private AnalyzedImage Image;

        private ImageSource thumbnail;
        public ImageSource Thumbnail
        {
            get { return thumbnail; }
            set { SetValue(ref thumbnail, value); }
        }

        public string Adult
        {
            get
            {
                return Image.Adult.IsAdultContent.ToString();
            }
        }
        public string AdultScore
        {
            get
            {
                return String.Format("{0:P2}", Image.Adult.AdultScore);
            }
        }
        public string Categories
        {
            get
            {    // ListView erstellen und eintragen ?
                return string.Join(Environment.NewLine, Image.Categories.Select(x => x.Name).ToArray());
            }
        }
        public string CategoriesScore
        {
            get
            {    // ListView erstellen und eintragen ?
                return string.Join(Environment.NewLine, Image.Categories.Select(x => String.Format("{0:P2}", x.Score)).ToArray());
            }
        }
        public string Description
        {
            get
            {
                return $"{Image.Description.Captions[0].Text}";
            }
        }
        public string Tags
        {
            get
            {
                return string.Join(Environment.NewLine, Image.Tags.Select(x => x.Name).ToArray());
            }
        }
        public string TagsScore
        {
            get
            {
                return string.Join(Environment.NewLine, Image.Tags.Select(x => String.Format("{0:P2}", x.Confidence)).ToArray());
            }
        }

        public DetailPageViewModel(AnalyzedImage Image, MediaFile photo)
        {
            this.Image = Image;
            thumbnail = ImageSource.FromStream(() => photo.GetStream());
        }
    }
}
