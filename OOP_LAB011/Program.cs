using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB011
{
    class Postavki
    {
        public string Name { get; set; }
        public string tovars { get; set; }
    }
    class Tovar
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region 1
            int n = 8;
            string[] array = {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December",
            };
            var newarr1 = array.Where(x => x.Length == n); foreach (var i in newarr1) Console.WriteLine(i); Console.WriteLine("\n");
            var newarr2 = array.Where(x => x == "December" || x == "January" || x == "February" || x == "June" || x == "July" || x == "August");
            foreach (var i in newarr2) Console.WriteLine(i); Console.WriteLine("\n");
            var newarr3 = array.OrderBy(x => x); foreach (var i in newarr3) Console.WriteLine(i); Console.WriteLine("\n");
            var newarr4 = array.Where(x => x.Contains("u")).Where(x => x.Length >= 4); foreach (var i in newarr4) Console.WriteLine(i); Console.WriteLine("\n");
            #endregion
            #region 23

            List<Book> newlist = new List<Book>();

            newlist.Add(new Book("First", 2004, 150, 550));
            newlist.Add(new Book("Second", 2005, 250, 560));
            newlist.Add(new Book("Second", 2006, 350, 520));
            newlist.Add(new Book("Fourth", 2007, 50, 150));
            newlist.Add(new Book("Fifth", 2004, 450, 350));
            newlist.Add(new Book("Fourth", 2008, 140, 504));
            newlist.Add(new Book("Seventh", 2020, 50, 550));
            newlist.Add(new Book("Second", 2013, 150, 50));

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            var list = newlist.Where(x => x.Author == "Fourth" && x.Year == 2007);
            foreach (var i in list) Console.WriteLine($"Автор: {i.Author}\nГод: {i.Year}\nЦена: {i.Cost}\n");
            var list1 = newlist.Where(x => x.Year > 2006);
            foreach (var i in list1) Console.WriteLine($"{i.Author}"); Console.WriteLine("\n");
            var list2 = newlist.Min(x => x.Length);
            Console.WriteLine(list2); Console.WriteLine("\n");
            var list3 = newlist.Where(x=> x.Cost<550).OrderByDescending(x => x.Length).Take(5);
            foreach (var i in list3) Console.WriteLine($"{i.Author}"); Console.WriteLine("\n");
            var list4 = newlist.OrderBy(x => x.Cost);
            foreach (var i in list4) Console.WriteLine($"{i.Author} - {i.Cost}"); Console.WriteLine("\n");
            #endregion
            #region 4
            var list6 = newlist.GroupBy(p => p.Author).Select(g => new { Name = g.Key, Count = g.Count() }).Where(x => x.Count < 3).OrderBy(x => x.Name).Take(3);
            foreach (var i in list6) Console.WriteLine(i); Console.WriteLine("\n");
            #endregion
            #region 5
            List<Postavki> postavkis = new List<Postavki>()
            {
                new Postavki {Name = "ОООПРИКОЛ", tovars = "винтовки" },
                new Postavki {Name = "ОООГАНСВСЕМ", tovars = "гранаты" },
            };
            List<Tovar> tovars = new List<Tovar>()
            {
                new Tovar {Name = "винтовки", Country ="Польша"},
                new Tovar {Name = "гранаты", Country ="Литва"},
                new Tovar {Name = "гранаты", Country ="Латвия"}
            };

            var rezult = from to in tovars
                         join t in postavkis on to.Name equals t.tovars
                         select new { Name = t.Name, Tovars = to.Name, Country = to.Country };

            foreach(var i in rezult)
                Console.WriteLine($"{i.Name} - {i.Country} - {i.Tovars}");
            #endregion
            Console.ReadKey();
        }
    }
}
