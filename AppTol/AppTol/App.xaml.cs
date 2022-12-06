using AppTol.Views;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTol
{
    
    public partial class App : Application
    {

        public static FlyoutPage masterDetail { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new LoginUI());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
