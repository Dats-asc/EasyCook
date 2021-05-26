using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyCook.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckRecipePage : ContentPage
    {
        Recipe databaseRecipe;

        public CheckRecipePage(Recipe recipe)
        {
            InitializeComponent();

            RecipeName.Text = "Название: " + recipe.Name;
            if (recipe.Description != null)
            {
                Description.Text = recipe.Description;
            }
            Ingridients.Text = recipe.Ingridients;
            Category.Text = "Категория: " + recipe.RecipeCategory;
            Comlexity.Text = "Сложность: " + recipe.Complex;
            Time.Text = "Время: " + recipe.Time + " мин.";

            databaseRecipe = recipe;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Database.DeleteItem(databaseRecipe.Id);
            DeleteButton.IsEnabled = false;
        }

        
    }
}