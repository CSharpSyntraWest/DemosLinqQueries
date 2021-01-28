using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
namespace DemoJoins
{
    class Product//:IComparable<Product>
    { 
        public string Naam { get; set; }
        public string Category { get; set; }

        //public int CompareTo([AllowNull] Product other)
        //{
        //    return Naam.CompareTo(other.Naam);
        //}
        //public int AantalInStock { get; set; }
        //public double Prijs { get; set; }

    }
    class Category
    { 
        public int Id { get; set; }
        public string Naam { get; set; }
    }
    class Program
    {
        private static List<Product> _producten;
        private static List<Category> _categories;
        static void Main(string[] args)
        {
           _producten = GetProductList();
            _categories = GetCategoryList();
           // Demo1();
            Demo2();
        }

        private static List<Category> GetCategoryList()
        {
            return new List<Category>() {
                new Category(){ Id=1, Naam="Voeding"},
                new Category() { Id=2, Naam="Drank"}
            };
        }

        private static void Demo2()
        {
           var queryResult = (from cat in _categories
                             join prod in _producten on cat.Naam equals prod.Category
                             orderby cat.Naam, prod.Naam
                             select new
                              {
                                  CategorieNaam = cat.Naam,
                                  ProductNaam = prod.Naam
                              }).ToList();
            queryResult.ForEach(item => Console.WriteLine($"Category: {item.CategorieNaam}; ProductNaam: {item.ProductNaam}"));

        }

        private static void Demo1()
        {
            string[] categories = { "Voeding", "Drank" };
            var queryResult = from cat in categories
                              join prod in _producten on cat equals prod.Category
                              orderby cat, prod.Naam
                              select new
                              {
                                  Categorie = cat,
                                  ProductNaam = prod.Naam
                              };

            foreach (var item in queryResult)
            {
                Console.WriteLine($"Category: {item.Categorie}; ProductNaam: {item.ProductNaam}");
            }
        }

        private static List<Product> GetProductList()
        {
            return new List<Product>() { 
                new Product { Naam="Brood", Category="Voeding"},
                new Product{ Naam = "Boter", Category="Voeding"},
                new Product { Naam= "Spuitwater",Category="Drank"},
                new Product { Naam = "Bier", Category="Drank"},
                new Product { Naam = "Glas", Category="Servies"}
            };
        }
    }
}
