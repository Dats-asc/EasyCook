using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EasyCook.Pages
{
    public partial class RecipesListPage : ContentPage
    {
        public RecipesListPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            FrameButton.BackgroundColor = Color.DarkRed;
        }
    }
}
