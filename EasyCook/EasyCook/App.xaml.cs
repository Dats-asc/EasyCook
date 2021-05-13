using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EasyCook.Pages;

namespace EasyCook
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MyTabbedPage();
            //MainPage = new NavigationPage(new TestPage());
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
