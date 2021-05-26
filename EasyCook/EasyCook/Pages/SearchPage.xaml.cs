using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace EasyCook.Pages
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        private void CustomEntry_Completed(object sender, EventArgs e)
        {
            SelectRecipes(SearchEntry.Text);
        }

        private void LoadRecipes(IEnumerable<Recipe> recipes)
        {
            RecipeLayout.Children.Clear();
            foreach (Recipe recipe in recipes)
            {
                var newRecipe = new RecipeItem(recipe.Name);
                newRecipe.recognizer.Tapped += async (sender, args) => await Navigation.PushAsync(new CheckRecipePage(recipe));
                RecipeLayout.Children.Add(newRecipe.Recipe);
            }
        }

        private void SelectRecipes(string critery)
        {
            var recipes = App.Database.GetItems();
            var selectedRecipes = new List<Recipe>();
            foreach (Recipe rec in recipes)
            {
                if (rec.Name.Substring(0,critery.Length).ToLower().Equals(critery.ToLower()))
                {
                    selectedRecipes.Add(rec);
                }
            }
            LoadRecipes(selectedRecipes.AsEnumerable<Recipe>());
        }

        public class RecipeItem
        {
            public StackLayout Recipe = new StackLayout
            {
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            private Frame RecipeFrame = new Frame
            {
                HeightRequest = 150,
                WidthRequest = 330,
                CornerRadius = 30,
                HasShadow = false,
                Padding = 0,
                BackgroundColor = Color.Navy,
            };

            private Label RecipeName = new Label()
            {
                Text = "Name",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 20,
            };

            public TapGestureRecognizer recognizer = new TapGestureRecognizer();

            public RecipeItem(string recipeName)
            {
                RecipeName.Text = recipeName;
                RecipeFrame.GestureRecognizers.Add(recognizer);
                Recipe.Children.Add(RecipeFrame);
                Recipe.Children.Add(RecipeName);
            }
        }

        private void CustomEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchEntry.Text.Length > 1)
            {
                SelectRecipes(SearchEntry.Text);
            }

            if (SearchEntry.Text.Length <= 1)
            {
                RecipeLayout.Children.Clear();
            }
        }
    }
}
