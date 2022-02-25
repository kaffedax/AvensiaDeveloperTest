using System;
using StructureMap;
using System.IO;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avensia.Storefront.Developertest
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(new DefaultRegistry());
            var productListVisualizer = container.GetInstance<ProductListVisualizer>();
            var shouldRun = true;

            //reading products.Json
            string path = Directory.GetCurrentDirectory();
            string fileJson = path + "\\Products.json";
            string dataJson = File.ReadAllText(fileJson);

            //Default currency
            Currency.now = "USD";

            IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());
            object result;
            string key = "productsJson";

            //Create / Overwrite
            result = cache.Set(key, dataJson);

            //Retrieve, null if not found
            result = cache.Get(key);


            DisplayOptions();

            while (shouldRun)
            {
                Console.Write("Enter an option: ");
                var input = Console.ReadKey();
                Console.WriteLine("\n");
                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.WriteLine("Printing all products");
                        //productListVisualizer.OutputAllProduct();
                        result = cache.Get(key);
                        if(result == null)
                        {
                            Console.WriteLine("Cache is empty");
                        }
                        else 
                        { 
                            var article = JsonConvert.DeserializeObject<List<Root>>((string)result);
                            Int32 z = 0;
                            do
                            {
                                double price = article[z].Price;
                                price = Exchange(price);
                                string curr = Currency.now;
                                if(curr == "SEK") { curr = "kr"; }
                                Console.WriteLine($"{article[z].Id}\t{article[z].ProductName}\t{price}" + " " + curr);
                                z++;
                            } while (z < article.Count);
                        }               
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.WriteLine("Printing paginated products");
                        //productListVisualizer.OutputPaginatedProducts();
                        var pagedArticle = JsonConvert.DeserializeObject<List<Root>>((string)result);
                        int pagenumber = 1;
                        result = cache.Get(key);
                        if (result == null)
                        {
                            Console.WriteLine("Cache is empty");
                        }
                        else
                        {                           
                            Int32 y = 1; //1 as start to use as pagenumber
                            do
                            {
                                double price = pagedArticle[y-1].Price;
                                price = Exchange(price);
                                string curr = Currency.now;
                                if (curr == "SEK") { curr = "kr"; }
                                Console.WriteLine($"{pagedArticle[y-1].Id}\t{pagedArticle[y-1].ProductName}\t{price}" + " " + curr);
                                if (y % 5 == 0)
                                {
                                    Console.WriteLine("\tPage: " + pagenumber);
                                    pagenumber++;
                                }
                                y++;
                            } while (y <= pagedArticle.Count);
                        }
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.WriteLine("Printing products grouped by price\n");
                        Int32 x = 1;
                        var gArticle = JsonConvert.DeserializeObject<List<Root>>((string)result);
                        double highPrice = 0;
                        do
                        {
                            double price = gArticle[x - 1].Price;
                            price = Exchange(price);
                            if (price > highPrice) { highPrice = price; };
                            x++;
                        }while (x <= gArticle.Count);                    
                        //Console.WriteLine(highPrice.ToString());                       
                        int fromPrice = 0;
                        int toPrice = 100;
                        x = 0;
                        do {
                            string curr = Currency.now;
                            if (curr == "SEK") { curr = "kr"; }
                                Console.WriteLine(fromPrice + "-" + toPrice + " " + curr);
                                Int32 xy = 0;
                                do
                                {
                                   double price = gArticle[xy].Price;
                                   price = Exchange(price);
                                   if (price >= fromPrice && price < toPrice)
                                    {
                                        double pprice = gArticle[xy].Price;
                                        pprice = Exchange(pprice);
                                        string curry = Currency.now;
                                    if (curr == "SEK") { curr = "kr"; }
                                    if(pprice >= fromPrice && pprice <= toPrice)
                                    {
                                        //Console.WriteLine($"{gArticle[xy].Id}\t{gArticle[xy].ProductName}\t{pprice}" + " " + curry); }
                                        Console.WriteLine($"\t{gArticle[xy].ProductName}\t{pprice}" + " " + curry); }
                                    }
                                    xy++;
                                } while (xy < gArticle.Count);
                            fromPrice = fromPrice + 100;
                            toPrice = toPrice + 100;
                            x++;
                        } while (fromPrice <= highPrice);
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        Console.WriteLine("Printing cached data");
                        result = cache.Get(key);
                        Console.WriteLine(result);
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        Console.WriteLine("USD");
                        Currency.now = "USD";
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.D6:
                        Console.WriteLine("GBP");
                        Currency.now = "GBP";
                        break;
                    case ConsoleKey.NumPad7:
                    case ConsoleKey.D7:
                        Console.WriteLine("SEK");
                        Currency.now = "SEK";
                        break;
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.D8:
                        Console.WriteLine("DKK");
                        Currency.now = "DKK";
                        break;
                    case ConsoleKey.NumPad9:
                    case ConsoleKey.D9:
                        Console.WriteLine(Currency.now);
                        break;
                    //case ConsoleKey.D:
                        //Console.WriteLine("Deleting cached data");
                        //cache.Remove(key);
                        //result = "";
                        //break;
                    //case ConsoleKey.R:
                        //Console.WriteLine("Reload data to cache");
                        //result = cache.Set(key, dataJson);
                        //result = "";
                        //break;
                    case ConsoleKey.Q:
                        shouldRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }               
                Console.WriteLine();
                DisplayOptions();
            }

            Console.Write("\n\rPress any key to exit!");
            Console.ReadKey();
        }

        private static void DisplayOptions()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Print all products");
            Console.WriteLine("2 - Print paginated products");
            Console.WriteLine("3 - Print products grouped by price");
            Console.WriteLine("4 - Print cached data");
            Console.WriteLine("5 - USD");
            Console.WriteLine("6 - GBP");
            Console.WriteLine("7 - SEK");
            Console.WriteLine("8 - DKK");
            Console.WriteLine("9 - Show currency");
            //Console.WriteLine("d - Delete cached data");
            //Console.WriteLine("r - Reload cached data");
            Console.WriteLine("q - Quit");
        }

        public static double Exchange(double input)
        {
            double[] exchangeRate = { 1.0, 0.71, 8.38, 6.06 };
            if(Currency.now == "USD") { input = input * exchangeRate[0]; }
            if(Currency.now == "GBP") { input = input * exchangeRate[1]; }
            if(Currency.now == "SEK") { input = input * exchangeRate[2]; }
            if(Currency.now == "DKK") { input = input * exchangeRate[3]; }
            return input;
        }

        static class Currency
        {
            public static string now;
        }

        public static class ExchangeRates
        {
            public static double USD = 1.0;
            public static double GBP = 0.71;
            public static double SEK = 8.38;
            public static double DKK = 6.06;
        }

        public class Property
        {
            public string KeyName { get; set; }
            public string Value { get; set; }
        }

        public class Root
        {
            public string Id { get; set; }
            public string ProductName { get; set; }
            public string CategoryId { get; set; }
            public double Price { get; set; }
            public List<Property> Properties { get; set; }
        }


    }
}
