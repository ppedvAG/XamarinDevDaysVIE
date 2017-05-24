using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WosIsDes.Models;
using Xamarin.Forms;

namespace WosIsDes.Services
{
    class PageService : IPageService
    {
        public async Task DisplayAlert(string title, string message, string ok)
        {
           await Application.Current.MainPage.DisplayAlert(title,message, ok);
        }

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task PushModalAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }
    }
}
