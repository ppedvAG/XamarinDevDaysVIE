using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WosIsDes.Services;
using WosIsDes.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WosIsDes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DevDaysDemoMain : ContentPage
    {
        public DevDaysDemoMain(MainPageViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }
        public DevDaysDemoMain()
        {
            InitializeComponent();
        }
    }
}
