using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WosIsDes.ViewModels;
using Xamarin.Forms;

namespace WosIsDes.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }
    }
}
