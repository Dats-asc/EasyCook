using System;
using System.Collections.Generic;
using SQLite;

namespace EasyCook
{

    public enum Category
    {
        Beverages,
        Bake,
        Dessert,
        Snacks,
        Salad,
        Sauce,
        Soup,
    }

    [Table("Recipe")]
    public class Recipe
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingridients { get; set; }
        public string Complex { get; set; }
        public string RecipeCategory { get; set; }
        public int Time { get; set; }

        public Recipe() {  }

        public Recipe(string name, string ingridients, string complex, string category, int time)
        {
            Name = name;
            Ingridients = ingridients;
            Complex = complex;
            RecipeCategory = category;
        }
    }

    public class RecipeRepository
    {
        SQLiteConnection recipeDatabase;

        public RecipeRepository(string databasePath)
        {
            recipeDatabase = new SQLiteConnection(databasePath);
            recipeDatabase.CreateTable<Recipe>();
        }

        public IEnumerable<Recipe> GetItems()
        {
            return recipeDatabase.Table<Recipe>().ToList();
        }

        public Recipe GetItem(int id)
        {
            return recipeDatabase.Get<Recipe>(id);
        }

        public int DeleteItem(int id)
        {
            return recipeDatabase.Delete<Recipe>(id);
        }

        public int SaveItem(Recipe item)
        {
            if (item.Id != 0)
            {
                recipeDatabase.Update(item);
                return item.Id;
            }
            else
            {
                return recipeDatabase.Insert(item);
            }
        }

        public void Clear()
        {
            var items = GetItems();
            foreach(Recipe recipe in items)
            {
                DeleteItem(recipe.Id);
            }
        }
    }
}
