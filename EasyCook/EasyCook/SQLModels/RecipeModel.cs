using System;
using System.Collections.Generic;
using SQLite;

namespace EasyCook
{
    public enum Units
    {
        Gram,
        Kilogram,
        Liter,
        MilLiter,
        Teaspoon,
        Tablespoon,
        Cup,
        Glass,
    }

    public enum Complexity
    {
        Easy,
        Medium,
        Hard,
    }

    public enum Category
    {

    }

    public class Ingridient
    {
        public string Name { get; set; }
        public Units Measure { get; set; }
        public int Amount { get; set; }

        public Ingridient(string name, Units measure, int amount)
        {
            Name = name;
            Measure = measure;
            Amount = amount;
        }

        public string UnitToString(Units unit)
         {
            switch (unit)
            {
                case Units.Gram:
                    return "гр.";
                case Units.Kilogram:
                    return "кг.";
                case Units.Liter:
                    return "л.";
                case Units.MilLiter:
                    return "мл.";
                case Units.Teaspoon:
                    return "ч.л.";
                case Units.Tablespoon:
                    return "с.л.";
                case Units.Cup:
                    return "чашка";
                    break;
                case Units.Glass:
                    return "стакан";
                default:
                    return "Wrong";
            }
        }

        public string ComplexityToString(Complexity complexity)
        {
            switch (complexity)
            {
                case Complexity.Easy:
                    return "Легкая";
                case Complexity.Medium:
                    return "Средняя";
                case Complexity.Hard:
                    return "Сложная";
                default:
                    return "wrong";
            }
        }
    }

    [Table("Recipe")]
    public class Recipe
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Ingridient> Ingridients { get; set; }
        public Complexity Complex { get; set; }
        public Category RecipeCategory { get; set; }

        public Recipe() {  }

        public Recipe(string name, Complexity complex, Category category)
        {
            Name = name;
            Ingridients = new List<Ingridient>();
            Complex = complex;
            RecipeCategory = category;
        }

        public Recipe(string name, List<Ingridient> ingridients, Complexity complex, Category category)
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
    }
}
