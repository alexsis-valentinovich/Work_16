using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
//2.    Необходимо разработать программу для получения информации о товаре из json-файла.
//Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.
namespace Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceProduct = 0;
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Product.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);
            int maxPrice = products[0].PriceProduct;
            int i = 0;
            int maxI = 0;
            foreach (Product product in products)
            {
                if (maxPrice < products[i].PriceProduct)
                {
                    maxPrice = products[i].PriceProduct;
                    maxI = i;
                }
                i += 1;
            }
            i = 0;
            Console.WriteLine("Информация о товаре");
            foreach (Product product in products)
            {
                Console.WriteLine($"Код товара: {products[i].CodeProduct} \nНаименование товара: {products[i].NameProduct} \nЦена товара: {products[i].PriceProduct}");
                i += 1;
                Console.WriteLine();
            }
            Console.WriteLine("Самый дорогой товар");
            Console.WriteLine($"Код товара: {products[maxI].CodeProduct} \nНаименование товара: {products[maxI].NameProduct} \nЦена товара: {products[maxI].PriceProduct}");
            Console.ReadKey();
        }
    }
}
