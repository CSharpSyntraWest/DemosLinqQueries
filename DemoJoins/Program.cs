using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
//Oefening 1 inner join: Maak een nieuwe klasse TypeProduct Met properties Id en Naam
//Voeg aan class Product een property TypeProduct toe (string),
//waarin de naam van het TypeProduct staat
//Initaliseer een lijst met TypeProduct objecten
// pas  GetProductList, zodat deze eveneens de TypeProduct properties van de producten invult
//Schrijf een Linq query die een inner join maakt tussen TypeProduct.Naam en Product.TypeProduct
//Sorteer eerst op Product.Naam, daarna op Typeproduct.Naam
//Geef een anonymous list terug van TypeProduct namen en Product namen

//Oefening 2 inner join:Wijzig daarna eens de property TypeProduct(string) in TypeProductId(int) in de class Product
//En maak dan eens de join tussen Product.TypeProductId en TypeProduct.Id (sortering en resultaat blijven hetzelfde)
namespace DemoJoins
{
    class TypeProduct
    { 
        public int Id { get; set; }
        public string Naam { get; set; }
    }
    class Product//:IComparable<Product>
    { 
        public string Naam { get; set; }
        public string Category { get; set; }
       // public string TypeProduct { get; set; } 
        public int TypeProductId {get;set;}

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
        private static List<TypeProduct> _typeProducten;
        static void Main(string[] args)
        {
           _producten = GetProductList();
           _categories = GetCategoryList();
           _typeProducten = GetTypeProducten();
            // Demo1();
            //   Demo2();
            // Oefening2();
            //Demo1GroupJoin();
            Demo2GroupJoin();
        }

        private static void Demo2GroupJoin()
        {
            var queryResultGroep = from cat in _categories
                                   join prod in _producten
                                   on cat.Naam equals prod.Category into prodGroep
                                   orderby cat.Naam
                                   select new { 
                                        Categorie = cat.Naam,
                                        Producten = prodGroep
                                   };
            foreach (var groep in queryResultGroep)
            {
                Console.WriteLine(groep.Categorie + ":");
                foreach (Product product in groep.Producten)
                {
                    Console.WriteLine("\t" + product.Naam);
                }
            }

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

        private static void Demo1GroupJoin()
        {
            string[] categories = { "Voeding", "Drank" };
            var queryResultGroup = from cat in categories
                                   join prod in _producten on cat equals prod.Category into prodGroep
                                   select new
                                   {
                                       Categorie = cat,
                                       Producten = prodGroep
                                   };
            foreach (var groep in queryResultGroup)
            {
                Console.WriteLine(groep.Categorie + ":");
                foreach (Product product in groep.Producten)
                {
                    Console.WriteLine("\t" + product.Naam);
                }
            }

        }

        private static void Oefening2()
        {
            var queryResultList = (from typeProd in _typeProducten
                                   join prod in _producten on typeProd.Id equals prod.TypeProductId
                                   orderby prod.Naam, typeProd.Naam
                                   select new
                                   {
                                       ProdTypeNaam = typeProd.Naam,
                                       ProductNaam = prod.Naam
                                   }).ToList();

            queryResultList.ForEach(item => Console.WriteLine($"ProductType: {item.ProdTypeNaam}; ProductNaam: {item.ProductNaam}"));
        }

        private static List<TypeProduct> GetTypeProducten()
        {
            return new List<TypeProduct>() {
                new TypeProduct(){ Id=1, Naam="Basis"},
                new TypeProduct() { Id=2, Naam="Luxe"}
            };
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

      

        private static List<Product> GetProductList()
        {
            return new List<Product>() { 
                new Product { Naam="Brood", Category="Voeding", TypeProductId=1},
                new Product{ Naam = "Boter", Category="Voeding", TypeProductId=1},
                new Product { Naam= "Spuitwater",Category="Drank", TypeProductId=1},
                new Product { Naam = "Bier", Category="Drank", TypeProductId=2},
                new Product { Naam = "Glas", Category="Servies", TypeProductId=2}
            };
        }
    }
}
