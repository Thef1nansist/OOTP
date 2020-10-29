using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = new Book("Гари Потер", "Djuan", "Первое Издательство", DateTime.Now, 3000, 135, "Бумажный");
            var name2 = new Book("Сахарок", "Djuan", "Сотое", DateTime.Now.AddYears(-100), 3005, 15, "Бумажный");

            var rok = new Book("Евгений Онегин", "Pushkin", "Второе", DateTime.Now.AddYears(-5), 150, 140, "Бумажный");

            var prikol = new Book("Мёртвое", "Marina", "Третье", DateTime.Now.AddYears(-1000), 100, 120, "Бумажный");

            Book.Info();
            if (Book.Equals(name, rok))
            {
                Console.WriteLine("da");
            }
            else
            {
                Console.WriteLine("net");
            }
            //Console.WriteLine(name.ToString());


            List<Book> list = new List<Book>();
            list.Add(name);
            list.Add(rok);
            list.Add(prikol);
            list.Add(name2);

            Console.WriteLine("Введите автора книги: ");
            var au = Console.ReadLine();
            foreach (var book in list)
            {
                if (book.Author == au)
                {
                    Console.WriteLine(book.ToString());
                    Console.WriteLine("\n");
                }
            }
            Console.WriteLine("Введите год издания, после которых были выпущены книги:");
            var year = Convert.ToInt32(Console.ReadLine());
            foreach (var book in list)
            {
                if (book.Date.Year > year)
                {
                    Console.WriteLine(book.ToString());
                    Console.WriteLine("\n");
                }
            }


            Console.ReadKey(true);
        }
    }
}
