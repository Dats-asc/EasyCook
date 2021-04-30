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

        void TapGestureRecognizer_Tapped1(object sender, System.EventArgs e)
        {
            FrameButton1.BackgroundColor = Color.Yellow;
        }

        private void TapGestureRecognizer_Tapped2(object sender, EventArgs e)
        {
            FrameButton2.BackgroundColor = Color.DarkRed;
        }
    }
}
