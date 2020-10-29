using System;

namespace OOP_Lab05
{
    public interface IDescription
    {
        void Display();

    }
    public class PrintEdition : IDescription
    {
        private int hash = 0;
        public string name;
        public int CountPage;
        public int price;

        public PrintEdition(string _name, int _countpage, int _price)
        {
            name = _name;
            CountPage = _countpage;
            price = _price;
        }

        void IDescription.Display()
        {
            Console.WriteLine("Это печатное издание");
        }
        public override bool Equals(object obj)
        {
            return obj is PrintEdition;
        }
        public override int GetHashCode()
        {
            return hash++;
        }
        public override string ToString()
        {
            string description = $"Object name: {nameof(PrintEdition)}\n" +
                $"Name:{name}\n" +
                $"CountOfPage:{CountPage}\n" +
                $"Price:{price}";
            return description;
        }
    }

    public class Magazine : PrintEdition, IDescription
    {
        public int circulation { get; set; }

        public Magazine(string _name, int _countpage, int _price, int _circulation) : base(_name, _countpage, _price)
        {
            circulation = _circulation;
        }

        void IDescription.Display()
        {
            Console.WriteLine("Это Журнал");
        }

        public override string ToString()
        {
            string description = $"Object name:{nameof(Magazine)}" +
                $"Name:{name}\n" +
                $"CountOfPage:{CountPage}\n" +
                $"Price:{price}\n" +
                $"Circulation:{circulation}";
            return description;
        }

    }
    public class Book : Magazine, IDescription
    {
        public string genre;

        public Book(string _name, int _countpage, int _price, int _circulation, string _genre) : base(_name, _countpage, _price, _circulation)
        {
            genre = _genre;
        }

        void IDescription.Display()
        {
            Console.WriteLine("Это Книга");
        }
        public override string ToString()
        {
            string description = $"Object name:{nameof(Book)}" +
               $"Name:{name}\n" +
               $"CountOfPage:{CountPage}\n" +
               $"Price:{price}\n" +
               $"Circulation:{circulation}" +
               $"Genre:{genre}";

            return description;
        }
    }

    public class Textbook : Book, IDescription
    {
        public int dataOfEdition;
        public Textbook(string _name, int _countpage, int _price, int _circulation, string _genre, int _dataofetition) : base(_name, _countpage, _price, _circulation, _genre)
        {
            dataOfEdition = _dataofetition;
        }
        void IDescription.Display()
        {
            Console.WriteLine("Это Учебник");
        }
        public override string ToString()
        {
            string description = $"Object name:{nameof(Textbook)}" +
               $"Name:{name}\n" +
               $"CountOfPage:{CountPage}\n" +
               $"Price:{price}\n" +
               $"Circulation:{circulation}" +
               $"Genre:{genre}" +
               $"Год издания:{dataOfEdition}";

            return description;
        }

    }
    public class Author : Textbook, IDescription
    {
        public string author;
        public Author(string _name, int _countpage, int _price, int _circulation, string _genre, int _dataofetition, string _author) : base(_name, _countpage, _price, _circulation, _genre, _dataofetition)
        {
            author = _author;
        }
        void IDescription.Display()
        {
            Console.WriteLine("Это Автор");
        }
       
        public override string ToString()
        {
            string description = $"Object name:{nameof(Author)}" +
               $"Name:{name}\n" +
               $"CountOfPage:{CountPage}\n" +
               $"Price:{price}\n" +
               $"Circulation:{circulation}" +
               $"Genre:{genre}" +
               $"Год издания:{dataOfEdition}" +
               $"Автор:{author}";

            return description;
        }
    }
    public class IZdatelstvo : Author, IDescription
    {
        public string edition;
        public IZdatelstvo(string _name, int _countpage, int _price, int _circulation, string _genre, int _dataofetition, string _author, string _edition) : base(_name, _countpage, _price, _circulation, _genre, _dataofetition, _author)
        {
            edition = _edition;
        }
        void IDescription.Display()
        {
            Console.WriteLine("Это Издательство");
        }
        public override string ToString()
        {
            string description = $"Object name:{nameof(IZdatelstvo)}" +
               $"Name:{name}\n" +
               $"CountOfPage:{CountPage}\n" +
               $"Price:{price}\n" +
               $"Circulation:{circulation}\n" +
               $"Genre:{genre}\n" +
               $"Год издания:{dataOfEdition}\n" +
               $"Автор:{author}\n" +
               $"Издательство:{edition}\n";

            return description;
        }

    }

    abstract public class user
    {
       public abstract void Clone();
        public abstract void Display();
    } 

    class user2 : user, IDescription
    {
        public override void Clone()
        {
            Console.WriteLine("Это пользовательский класс использую абстрактный класс ");
        }
        void IDescription.Display()
        {
            Console.WriteLine("Это пользовательский класс используя интефейс");
        }
        public override void Display()
        {
            Console.WriteLine("одноимённые методы");
        }
        
    }
    public class Printer
    {
        public void IAmPrinting(IDescription obj)
        {
            obj.Display();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IDescription[] array = new IDescription[6];
            array[0] = new PrintEdition("Gari", 300, 50);
            array[1] = new Magazine("Сказки деда", 100, 20, 155);
            array[2] = new Book("Сказки бабушки", 10, 90, 255,"Фентази");
            array[3] = new Textbook("Сказки Славы", 1000, 950, 55, "Приключения",2004);
            array[4] = new Author("Сказки Влада", 1500, 50, 155, "Детектив", 2001,"Савченко");
            array[5] = new IZdatelstvo("Сказки Вани", 1545, 540, 14555, "Сказки", 2019, "Иванов","Беларусь");

            Console.WriteLine(array[4] is IZdatelstvo);
            //for(int i =0; i< array.Length; i++)
            //{
            //    Console.WriteLine($"{array[i]}\n");
            //}
            //user2 pr = new user2();

            //pr.Display();
            
            Printer p = new Printer();
            for (int i = 0; i < 5; i++)
            {
                p.IAmPrinting(array[i]);
            }
        }
    }

}
