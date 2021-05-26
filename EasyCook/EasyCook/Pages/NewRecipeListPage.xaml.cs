using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using System.ComponentModel;

namespace EasyCook.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewRecipeListPage : ContentPage
    {
        public static bool RecipeSaved = false;

        private Stack<Frame> TapGestureRecognizerStack = new Stack<Frame>();

        public NewRecipeListPage()
        {
            InitializeComponent();
            LoadRecipes(App.Database.GetItems());
        }

        public void LoadRecipes(IEnumerable<Recipe> recipes)
        {
            RecipePageRecipeLayout.Children.Clear();
            foreach (Recipe recipe in recipes)
            {
                var newRecipe = new RecipeItem(recipe.Name);
                newRecipe.recognizer.Tapped += async (sender, args) => await Navigation.PushAsync(new CheckRecipePage(recipe));
                RecipePageRecipeLayout.Children.Add(newRecipe.Recipe);
            }
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            LoadRecipes(App.Database.GetItems());
            if(TapGestureRecognizerStack.Count != 0)
            {
                TapGestureRecognizerStack.Pop().BackgroundColor = Color.Yellow;
            }
        }

        private void Select(string category)
        {
            var recipes = App.Database.GetItems();
            var selectedRecipes = new List<Recipe>();
            foreach (Recipe rec in recipes)
            {
                if (rec.RecipeCategory.Equals(category))
                {
                    selectedRecipes.Add(rec);
                }
            }
            LoadRecipes(selectedRecipes.AsEnumerable<Recipe>());
        }

        private void ChangeColor(Frame frame)
        {
            if (TapGestureRecognizerStack.Count != 0)
            {
                var elem = TapGestureRecognizerStack.Pop();
                elem.BackgroundColor = Color.White;
            }

            frame.BackgroundColor = Color.Yellow;
            TapGestureRecognizerStack.Push(frame);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Select("Первые блюда");
            ChangeColor(FrameButton1);
        }
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Select("Вторые блюда");
            ChangeColor(FrameButton2);
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Select("Напитки");
            ChangeColor(FrameButton3);
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            Select("Выпечка");
            ChangeColor(FrameButton4);
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            Select("Десерты");
            ChangeColor(FrameButton5);
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            Select("Закуски");
            ChangeColor(FrameButton6);
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            Select("Салаты");
            ChangeColor(FrameButton7);
        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            Select("Соусы");
            ChangeColor(FrameButton8);
        }
    }
}