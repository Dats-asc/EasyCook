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
    public partial class TestPage : ContentPage
    {
        public bool[] FieldsAreEmpty;

        public TestPage()
        {
            InitializeComponent();
            FieldsAreEmpty = new bool[5];

            Installation();

            

        }

        private void Installation()
        {
            UpperInterval.HorizontalOptions = LayoutOptions.Fill;
            UpperInterval.VerticalOptions = LayoutOptions.Fill;
            UpperInterval.WidthRequest = App._SCREENWIDTH;
            UpperInterval.HeightRequest = App._SCREENHEIGHT / 30;
            UpperInterval.Spacing = 15;

            NameFrame.WidthRequest = App._SETWIDTH;
            DescriptionLayout.WidthRequest = App._SETWIDTH;
            DescriptionFrame.WidthRequest = App._SETWIDTH;

            AddRecipeImageButton.HorizontalOptions = LayoutOptions.Fill;
            AddRecipeImageButton.HeightRequest = App._SCREENHEIGHT / 25;
            PickerFrame.WidthRequest = App._SETWIDTH;
            IngridientDescriptionFrame.WidthRequest = App._SETWIDTH;
            IngridientEditor.Placeholder = "Перечислите ингридиенты\n\n\n";
            DescriptionEditor.Placeholder = "Добавте описание \n\n\n";
        }

        private void NameEntry_Completed(object sender, EventArgs e)
        {
            if (AddRecipeNameLabel.Text != null)
                FieldsAreEmpty[0] = true;
            if (FieldsNotEmpty())
            {
                SaveButton.IsEnabled = true;
            }
        }

        private void DescriptionEditor_Completed(object sender, EventArgs e)
        {

        }

        private void IngridientEditor_Completed(object sender, EventArgs e)
        {
            if (IngridientEditor.Text != null)
                FieldsAreEmpty[1] = true;
            if (FieldsNotEmpty())
            {
                SaveButton.IsEnabled = true;
            }

        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var newRecipe = new Recipe()
            {
                Name = AddRecipeNameLabel.Text,
                Description = DescriptionEditor.Text,
                Ingridients = IngridientEditor.Text,
                Complex = ComplexityPicker.Items[ComplexityPicker.SelectedIndex],
                RecipeCategory = CategoryPicker.Items[CategoryPicker.SelectedIndex],
                Time = int.Parse(TimeEntry.Text.Split(' ')[0]),
            };
        }


        private void TimeEntry_Completed(object sender, EventArgs e)
        {
            if (TimeEntry.Text != null)
            {
                FieldsAreEmpty[4] = true;
                TimeEntry.Text = TimeEntry.Text + " мин.";
                if (FieldsNotEmpty())
                {
                    SaveButton.IsEnabled = true;
                }
            }

        }

        private void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            FieldsAreEmpty[2] = true;
            if (FieldsNotEmpty())
            {
                SaveButton.IsEnabled = true;
            }
        }

        private void ComplexityPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            FieldsAreEmpty[3] = true;
            if (FieldsNotEmpty())
            {
                SaveButton.IsEnabled = true;
            }
        }

        public bool FieldsNotEmpty()
        {
            for (int i = 0; i < 5; i++)
            {
                if (FieldsAreEmpty[i] == false)
                    return false;
            }

            return true;
        }
    }

    
}