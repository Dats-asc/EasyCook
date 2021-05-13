using System;
using System.Collections.Generic;
using Xamarin.Forms;
namespace EasyCook.Pages.Page_objects
{
    class IngridientsLayout : ContentPage
    {
        Recipe newRecipe;

        StackLayout Ingridients = new StackLayout()
        {
            HorizontalOptions = LayoutOptions.Fill,
            Spacing = 20,
        };

        public IngridientsLayout(Recipe recipe)
        {
            newRecipe = recipe;
        }
    }

    class Ingridient : ContentPage
    {
        StackLayout IngridientLayout = new StackLayout()
        {
            HorizontalOptions = LayoutOptions.Fill,
            Spacing = 10,
        };

        Entry IngridientNameEntry = new Entry()
        {
            FontSize = 20,
            Placeholder = "Введите название ингридиента",
            PlaceholderColor = Color.Gray,
        };

        public void IngridientsNameEntryCompleted(object sender, EventArgs e)
        {

        }

        Entry IngridientCountEntry = new Entry()
        {
            FontSize = 20,
            Placeholder = "Введите количество",
            PlaceholderColor = Color.Gray,
        };

        public void IngridientsCountEntryCompleted(object sender, EventArgs e)
        {

        }

        Button AddIngridientButton = new Button()
        {
            HorizontalOptions = LayoutOptions.Center,
            WidthRequest = 100,
            Text = "Добавить ингридиент",
        };

        public void AddIngridientsButtonClicked(object sender, EventArgs e)
        {

        }

        public Ingridient()
        {
            IngridientLayout.Children.Add(IngridientNameEntry);
            IngridientLayout.Children.Add(IngridientCountEntry);
            IngridientLayout.Children.Add(AddIngridientButton);

            AddIngridientButton.Clicked += AddIngridientsButtonClicked;
            IngridientNameEntry.Completed += IngridientsNameEntryCompleted;
            IngridientCountEntry.Completed += IngridientsCountEntryCompleted;

        }
    }
}
