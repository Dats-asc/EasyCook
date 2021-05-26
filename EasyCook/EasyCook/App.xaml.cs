using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using EasyCook.Pages;

namespace EasyCook
{
    public partial class App : Application
    {
        public static double _SCREENHEIGHT = DeviceDisplay.MainDisplayInfo.Height;
        public static double _SCREENWIDTH = DeviceDisplay.MainDisplayInfo.Width;
        public static double _SETWIDTH = _SCREENWIDTH * 0.34;
        public static double _DPI = DeviceDisplay.MainDisplayInfo.Density;

        public const string DATABASE_NAME = "recipe.db";
        public static RecipeRepository database;
        public static RecipeRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new RecipeRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public static Page BasePage;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MyTabbedPage());
            BasePage = MainPage;
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
