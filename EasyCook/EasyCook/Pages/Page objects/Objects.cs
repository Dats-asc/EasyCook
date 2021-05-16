using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace EasyCook.Pages
{

    public class EntryWithFrame
    {
        public StackLayout layout = new StackLayout()
        {
            HorizontalOptions = LayoutOptions.Fill,
            Spacing = 10,
        };

        public Frame frame = new Frame()
        {
            HasShadow = false,
            Padding = 0,
            CornerRadius = 20,
            HorizontalOptions = LayoutOptions.Start,
            WidthRequest = App._SETWIDTH,
            BorderColor = Color.Gray,
            
        };

        public CustomEntry customEntry = new CustomEntry()
        {
            HorizontalTextAlignment = TextAlignment.Start,
            VerticalOptions = LayoutOptions.Center,
            PlaceholderColor = Color.Gray,
            FontSize = 20,
            TranslationX = 10,
        };

        public EntryWithFrame(string placeHolderName)
        {
            customEntry.Placeholder = placeHolderName;
            

            layout.Children.Add(customEntry);
            frame.Content = layout;
        }

    }

    public class AddIngridientButton
    {
        public static Button addIngridientButton = new Button()
        {
            HorizontalOptions = LayoutOptions.Center,
            WidthRequest = 175,
            Text = "Добавить ингридиент",
            FontSize = 15,
            CornerRadius = 20,
        };

        
    }

    public class IngridientLayout
    {
        public StackLayout GetIngridientLayout()
        {
            Label label = new Label
            {
                Text = "Ингридиент",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start,
            };

            var ingridientsNameEntry = new EntryWithFrame("Введите название рецепта");

            var ingridientCountEntry = new EntryWithFrame("Введите количество");


            ingridientsNameEntry.customEntry.Completed += IngridientsNameEntryCompleted;
            ingridientCountEntry.customEntry.Completed += IngridientsCountEntryCompleted;

            StackLayout newIngridient = new StackLayout() { Spacing = 10};
            newIngridient.Children.Add(label);
            newIngridient.Children.Add(ingridientsNameEntry.frame);
            newIngridient.Children.Add(ingridientCountEntry.frame);

            ingridientCountEntry.customEntry.Placeholder = "DASDASDASDASDASDASD";

            return newIngridient;
        }

        public void IngridientsNameEntryCompleted(object sender, EventArgs e)
        {

        }

        public void IngridientsCountEntryCompleted(object sender, EventArgs e)
        {

        }
    }
}
