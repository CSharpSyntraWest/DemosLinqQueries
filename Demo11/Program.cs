using System;
using System.Collections.Generic;
using System.Linq;
namespace Demo11
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public override string ToString()
        {
            return $"ProductID={ProductID} " +
                $"ProductName={ProductName} " +
                $"Category={Category} " +
                $"UnitPrice={UnitPrice:C2} " +
                $"UnitsInStock={UnitsInStock}";
        }
    }
    public static class Products
    { 
        public static List<Product> ProductsList { get; } = new List<Product>() {
        new Product { ProductID = 1, ProductName = "Chai",Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 39 },
        new Product { ProductID = 2, ProductName = "Chang",Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
        new Product { ProductID = 3, ProductName ="Aniseed Syrup",Category="Condiments",UnitPrice=10.0000M, UnitsInStock=13 },
        new Product { ProductID = 4, ProductName="Chef Anton's Cajun Seasoning",Category= "Condiments", UnitPrice = 22.0000M, UnitsInStock = 53 },
        new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments", UnitPrice = 21.3500M, UnitsInStock = 0 }};
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> productenLijst = Products.ProductsList;
            Product productId3 = (from p in productenLijst
                                  where p.ProductID == 3
                                  select p).First();

            Console.WriteLine($"Het product met Id==3 : \n {productId3}");

            Product productId6 = (from p in productenLijst
                                  where p.ProductID == 6
                                  select p).FirstOrDefault();
            if (productId6 == null)
                Console.WriteLine($"Het product met Id==6 niet gevonden");
            else
                Console.WriteLine($"Het product met Id==6 : \n {productId6}");


            Product productBeveragesFirst = productenLijst.Where(p => p.Category == "Beverages").First();
            Console.WriteLine($"Het eerste product met Categorie='Beverages' : \n {productBeveragesFirst}");

            Product productBeveragesSingle = productenLijst.Where(p => p.Category == "Beverages").Single();
            //geef exception, want meer dan 1 product van categorie 'Beverages'
            Console.WriteLine($"Het enige productmet Categorie='Beverages' : \n {productBeveragesSingle}");



            Product productId6Single = productenLijst.Where(p => p.ProductID == 6).SingleOrDefault();
            if (productId6Single == null)
                Console.WriteLine($"Het product met Id==6 niet gevonden");
            else
                Console.WriteLine($"Het product met Id==6 : \n {productId6Single}");
        }
    }

}
