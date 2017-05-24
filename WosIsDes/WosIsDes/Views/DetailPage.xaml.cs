using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WosIsDes.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WosIsDes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(DetailPageViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }
    }
}
