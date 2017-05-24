using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WosIsDes.Models;
using WosIsDes.Views;
using Xamarin.Forms;

namespace WosIsDes.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly IPageService pageService;
        private ImageSource thumbnail;
        public ImageSource Thumbnail
        {
            get { return thumbnail; }
            set { SetValue(ref thumbnail, value); }
        }

        private bool computingImage;

        public bool ComputingImage
        {
            get { return computingImage; }
            set { SetValue(ref computingImage, value); }
        }


        private MediaFile photo;


        private ICommand buttonTakeImageClicked;
        public ICommand ButtonTakeImageClickedCommand
        {
            get
            {
                buttonTakeImageClicked = buttonTakeImageClicked ?? new RelayCommand(async () => 
                {
                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await pageService.DisplayAlert("Fehler", "Es ist leider keine Kamera verfügbar", "OK");
                        return;
                    }

                    photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        SaveToAlbum = true,
                        Name = $"{DateTime.Now.ToString()}.jpg"
                    });

                    if (photo == null)
                        return;
                    else
                    {
                        Thumbnail = ImageSource.FromStream(() => photo.GetStream());
                    }
                });
                return buttonTakeImageClicked;
            }
        }

        private ICommand buttonImageFromGalleryClickedCommand;
        public ICommand ButtonImageFromGalleryClickedCommand
        {
            get
            {
                buttonImageFromGalleryClickedCommand = buttonImageFromGalleryClickedCommand ?? new RelayCommand(async () => 
                {
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await pageService.DisplayAlert("No upload", "No Gallery", "Ok");
                        return;
                    }

                    photo = await CrossMedia.Current.PickPhotoAsync();

                    if (photo == null)
                        return;
                    else
                    {
                        Thumbnail = ImageSource.FromStream(() => photo.GetStream());
                    }
                });
                return buttonImageFromGalleryClickedCommand;
            }
        }

        private ICommand buttonScanClickedCommand;
        public ICommand ButtonScanClickedCommand
        {
            get
            {
                buttonScanClickedCommand = buttonScanClickedCommand ?? new RelayCommand(async () => 
                {
                    ComputingImage = true;
                    var client = new HttpClient();
                    // Request headers - replace this example key with your valid subscription key.
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fd473b1ef4f745c4af1abc941cf19b83");

                    // Request parameters. A third optional parameter is "details".
                    string requestParameters = "visualFeatures=Description,Tags,Categories,Adult&language=en";
                    string uri = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0/analyze?" + requestParameters;

                    HttpResponseMessage response;

                    // Request body. Try this sample with a locally stored JPEG image.
                    byte[] byteData = DependencyService.Get<IFileHelper>().GetImageAsByteArray(photo.Path);
                    string responseContent;
                    using (var content = new ByteArrayContent(byteData))
                    {
                        // This example uses content type "application/octet-stream".
                        // The other content types you can use are "application/json" and "multipart/form-data".
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        response = await client.PostAsync(uri, content);
                        responseContent = response.Content.ReadAsStringAsync().Result;
                    }
                    AnalyzedImage ai = JsonConvert.DeserializeObject<AnalyzedImage>(responseContent);
                    ComputingImage = false;
                    await pageService.PushModalAsync(new DetailPage(new DetailPageViewModel(ai,photo)));
                });
                return buttonScanClickedCommand;
            }
        }
        public MainPageViewModel(IPageService pageservice)
        {
            this.pageService = pageservice;
            Thumbnail = ImageSource.FromResource("WosIsDes.Images.thumb.png");
            ComputingImage = false;
        }
    }
}
