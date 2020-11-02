using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OOP_Lab007
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
            if(CountPage<0)
                throw new InvalidData($"В {_countpage} допущена ошибка в книге{ _name}");
           
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
            if(circulation<0)
                throw new InvalidData($"В поле {_circulation} допущена ошибка в книге{ _name} ");

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
            if (dataOfEdition < 0 || dataOfEdition == 0)
                throw new InvalidData($"В книге {_name} допущена ошибка по дате в книге{ _name}");
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
        public int Year => dataOfEdition;
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

    //6 лаба
    public partial class PartialTest
    {
        public void test()
        {
            Console.WriteLine("Основной файл");
        }
    }
    //
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

    //6 лаба
    struct Edition
    {
        public string name__;
        public int age__;
        public void info()
        {
            Console.WriteLine($"Name:{name__}, Возраст:{age__}");
        }

    }
    enum Edit
    {
        edition,
        price,
        name
    }

    public class Library
    {
        List<IZdatelstvo> list = new List<IZdatelstvo>();

        public List<IZdatelstvo> GetList()
        {
            return list;
        }
        public void SetList(List<IZdatelstvo> list)
        {
            this.list = list;
        }
        public void AddElements(IZdatelstvo library)
        {
            list.Add(library);
        }
        public void RemoveElements(IZdatelstvo library)
        {
            list.Remove(library);
        }
        public void Print()
        {
            //if (list.Count == 0)
            //    throw new InvalidNull($"Лист пустой");
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }

    static public class LibraryController
    {
        public static void SearchYear(Library library)
        {
            int year = 2004;
            List<IZdatelstvo> arrayList = library.GetList().GetRange(0, library.GetList().Count);
            if (arrayList.Count == 0)
                throw new InvalidNull("В блоке поиска года список пуст");
            Console.WriteLine("Книги после 2004 года:");
            for (var i = 0; i < arrayList.Count; i++)
            {
                if (arrayList[i].dataOfEdition > year)
                {
                    Console.WriteLine(arrayList[i].name);
                }
            }

        }
        public static void SearchSum(Library library)
        {
            int sum = 0;
            List<IZdatelstvo> arraylist = library.GetList().GetRange(0, library.GetList().Count);
            for (int i = 0; i < arraylist.Count; i++)
            {
                sum += arraylist[i].price;
            }
            if (sum < 0 || sum>int.MaxValue)
            {
                throw new InvalidExepception("Сумма меньше нуля или больше допустимого значения.В блоке поиска суммы", sum);
            }
            Console.WriteLine($"Общая стоимость книг:{sum}$");
        }
        public static void SearcCountBook(Library library)
        {
            List<IZdatelstvo> arraylist = library.GetList().GetRange(0, library.GetList().Count);
            int count = arraylist.Count;
            Console.WriteLine($"Кол-во книг в библиотеке:{count} ");
        }
        public static void SearcRead()
        {
            int indexcount0 = 0;
            int indexcount1 = 1;
            int indexcount2 = 2;
            int indexcount3 = 3;
            int indexcount4 = 4;
            int indexcount5 = 5;
            int indexcount6 = 6;
            int indexcount7 = 7;
            string tmp = "";
            string[] text;
            StreamReader fs = new StreamReader(@"D:\UN\OOP_LAb006\1.txt");
            if (fs == null)
                throw new Exception("Файл не был открыт");
            while (true)
            {
                tmp = fs.ReadLine();
                if (tmp == null)
                    continue;
                text = (string[])(tmp.Split(','));

                if (int.Parse(text[indexcount5]) > 2004)
                {
                    Console.WriteLine(Tostring());
                }
            }
            string Tostring()
            {
                string description =
                  $"Наименование:{text[indexcount0]}\n" +
                  $"Количество страниц:{text[indexcount1]}\n" +
                  $"Цена:{text[indexcount2]}\n" +
                  $"Тираж:{text[indexcount3]}\n" +
                  $"Жанр:{text[indexcount4]}\n" +
                  $"Год издания:{text[indexcount5]}\n" +
                  $"Автор:{text[indexcount6]}\n" +
                  $"Издательство:{text[indexcount7]}\n";

                return description;
            }
        }
        //public static async void SearchFromJson(Library library)
        //{
        //    List<IZdatelstvo> arraylist = library.GetList().GetRange(0, library.GetList().Count);
        //    IZdatelstvo zdatelstvo = new IZdatelstvo();
        //    using (FileStream fs = File.Create("user.json"))
        //    {
        //        await JsonSerializer.SerializeAsync(fs, arraylist);
        //        File.WriteAllText("user.json", (string)zdatelstvo.ToString());
        //    }
        //    using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        //    {
        //        IZdatelstvo restoredPerson = await JsonSerializer.DeserializeAsync<IZdatelstvo>(fs);
        //        Console.WriteLine($"Name: {restoredPerson.name}  Age: {restoredPerson.dataOfEdition}");
        //    }
        //}

    }
    public class Person
    {
        [JsonPropertyName("firstname")]
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            try
            {

                library.AddElements(new IZdatelstvo("Mstiteli", 1545, 540, 14555, "Arabian", 2019, "lana Roads", "Сша"));
                library.AddElements(new IZdatelstvo("Pricol", 200, 540, 14555, "Anal", 2000, "Riley Reid", "США"));
                library.AddElements(new IZdatelstvo("Выживший", 300, 540, 14555, "Azians", 2000, "Abaalla Danger", "США"));
                library.AddElements(new IZdatelstvo("Великий", 400, 540, 14555, "HD", 2009, "Alla Elfi", "Россия"));
                library.AddElements(new IZdatelstvo("Начало", 505, 100, 555, "60fps", 1945, "Квит", "Беларусь"));
                library.AddElements(new IZdatelstvo("Конец", 1545, 600, 145, "Closed Captions", 1941, "Mia Khalifa", "Ливан"));

                //library.Print();
                LibraryController.SearchYear(library);
                LibraryController.SearchSum(library);
                //LibraryController.SearcCountBook(library);
                LibraryController.SearcRead();
                //LibraryController.SearchFromJson();


                //IDescription[] array = new IDescription[8];
                //array[0] = new PrintEdition("Gari", 300, 50);
                //array[1] = new Magazine("Сказки деда", 100, 20, 155);
                //array[2] = new Book("Сказки бабушки", 10, 90, 255, "Фентази");
                //array[3] = new Textbook("Сказки Славы", 1000, 950, 55, "Приключения", 2004);
                //array[4] = new Author("Сказки Влада", 1500, 50, 155, "Детектив", 500, "Савченко");
                //array[5] = new IZdatelstvo("Сказки Вани", 1545, 540, 14555, "Сказки", 504, "Иванов", "Беларусь");
                //array[6] = new IZdatelstvo("Tor", 1545, 540, 14555, "Сказки", 2019, "Иванов", "Беларусь");
                //array[7] = new IZdatelstvo("Mstiteli", 1545, 540, 14555, "Сказки", 2019, "Иванов", "Беларусь");

                //library.Print();


                //Console.WriteLine(array[4] is IZdatelstvo);
                ///////////////////////////////////////////// partial класс
                //PartialTest partial = new PartialTest();
                //partial.test();
                //partial.test2();


                ////////////////////////////////////////////
                ////for(int i =0; i< array.Length; i++)
                ////{
                ////    Console.WriteLine($"{array[i]}\n");
                ////}
                ////user2 pr = new user2();

                ////pr.Display();

                //Printer p = new Printer();
                //for (int i = 0; i < 5; i++)
                //{
                //    p.IAmPrinting(array[i]);
                //}
            }
            catch (InvalidExepception ex)
            {
                Console.WriteLine($"Некоректное значение:{ex.Value} \n Информация:{ex.Message}");
            }
            catch (InvalidData ex)
            {
                Console.WriteLine($"Ошибка:{ex.Message}");
            }
            catch(InvalidNull ex)
            {
                Console.WriteLine($"Некоректное значение:{ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Остальные приколы{ex.Message}");
            }
            finally
            {
                Console.WriteLine("Программа завершена");
            }
           

        }
    }

}
