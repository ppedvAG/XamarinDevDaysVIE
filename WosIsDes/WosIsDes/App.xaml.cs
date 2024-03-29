﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WosIsDes.Services;
using WosIsDes.ViewModels;
using Xamarin.Forms;

namespace WosIsDes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new WosIsDes.Views.MainPage(new MainPageViewModel(new PageService()));
            // Live-Variante: DevDays
            // MainPage = new DevDaysDemoMain(new MainPageViewModel(new PageService()));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
