using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_02
{
    public class Book
    {

        //private Book() { }
        private readonly int id;

        public static int CountOfObjects;
        public string Title { get; set; }
        public int Id { get => id; }
        public string Author { get; set; }
        public string Publisher { get; set; }

        public DateTime Date { get; set; }
        public int Length { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }

        

        public Book()
        {

        }
        public Book(string title, string author, string publisher, DateTime date, int length, decimal price, string type)
        {
            Title = title;
            id = CountOfObjects;
            Author = author;
            Publisher = publisher;
            Date = date;
            Length = length;
            Price = price;
            Type = type;

            CountOfObjects++;
        }

        static Book()
        {
            CountOfObjects = 0;
        }
        public static void Info()
        {
            Console.WriteLine("Хранит ифнормацию о Книгах");
        }

        public static bool Equals(Book b1, Book b2)
        {
            return b1.GetHashCode() == b2.GetHashCode();
        }
        public override int GetHashCode()
        {
            return new Random().Next();
        }
        public override string ToString() => $"Название:{Title}\nИздание:{Publisher}\nГод издания:{Date.Year}\nЦена:{Price}";

       
    }
    public partial class Test //частичные классы
    { 
        public void prikol1()
        {
            Console.WriteLine("prank1");
        }
    }
    public partial class Test
    {
        public void prikol2()
        {
            Console.WriteLine("prank2");
        }
    }

}
