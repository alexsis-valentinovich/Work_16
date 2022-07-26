using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
//1.    Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

//Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число),
//«Название товара» (строка), «Цена товара» (вещественное число).
//Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
//Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».
//2.    Необходимо разработать программу для получения информации о товаре из json-файла.
//Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.
namespace Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Product[] products = new Product[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите информацию о товаре\nВведите код товара: ");
                int codeProduct = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите именование товара: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Введите цену товара: ");
                int priceProduct = Convert.ToInt32(Console.ReadLine());
                products[i] = new Product() { CodeProduct = codeProduct, NameProduct = nameProduct, PriceProduct = priceProduct };
                Console.WriteLine();
            }
            JsonSerializerOptions options = new JsonSerializerOptions();
            {
                JavaScriptEncoder Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic);
                bool WriteIndented = true;
            }
            string jsonString = JsonSerializer.Serialize(products, options);
            using (StreamWriter sw = new StreamWriter("../../../Product.json"))
            {
                sw.WriteLine(jsonString);
            }

        }
    }
}
