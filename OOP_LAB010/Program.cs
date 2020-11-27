using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB010
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1
            Computer<int> cs = new Computer<int>();

            cs.Add(1);
            cs.Add(2);
            cs.Add(3);
            cs.Add(4);
            foreach (var k in cs)
            {
                Console.WriteLine(k);
            }
            cs.Remove(1);
            Console.WriteLine("\nПосле удаления элемента:");
            foreach (var k in cs)
            {
                Console.WriteLine(k);
            }
            if (cs.Contains(2))
                Console.WriteLine("\nЭлемент 2 присутствует в данной коллекции\n");
            else
                Console.WriteLine("Элемент 2 отсутствует в данной коллекции\n");
            #endregion
            #region 2-3

            //2
            HashSet<object> hashSet = new HashSet<object>();

            hashSet.Add("ProcolC#"); hashSet.Add("asdasdasd"); hashSet.Add('F'); hashSet.Add(true); hashSet.Add(54454);
            int i = 1;
            foreach (object o in hashSet)
            {
                Console.WriteLine($"{i}. {o} ");
                i++;
            }
            Console.WriteLine("\n");

            i = 0;
            int p = 0;
            while (i < (2 - p))
            {
                hashSet.Remove(hashSet.ElementAt(i));
                p++;
            }

            List<object> list = new List<object>();
            foreach (object o in hashSet)
            {
                list.Add(o);
            }
            Console.WriteLine("List:");
            foreach (object o in list)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine("\n");

            object value = 54454;
            if (list.IndexOf(value) >= 0) Console.WriteLine("Найдено, индекс в листе: " + list.IndexOf(value));
            else Console.WriteLine("Не найдено"); Console.WriteLine("\n");
            //Console.ReadLine();

            ObservableCollection<Сharacteristics> vs = new ObservableCollection<Сharacteristics>
                    {
                        new Сharacteristics() {characteristics = new List<string>() {"Asus", "DEAL"}},
                        new Сharacteristics() {characteristics = new List<string>() {"LENOVO", "ASER"}},
                        new Сharacteristics() {characteristics = new List<string>() {"Canon", "Samsung"}}

                    };

            vs.CollectionChanged += Vs_CollectionChanged;
            vs.Add(new Сharacteristics() { characteristics = new List<string>() { "Aple", "Honor" } });

            vs.RemoveAt(1);
            vs[0] = new Сharacteristics() { characteristics = new List<string>() { "HP", "MiBook" } };
            Console.WriteLine("Теперь коллекция выглядит так:");
            foreach (var o in vs)
            {
                Console.WriteLine(o);
            }
            Console.ReadLine();
        }

        private static void Vs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    Сharacteristics сharacteristicsNew = e.NewItems[0] as Сharacteristics;
                    Console.WriteLine($"Произошло добавление объекта {сharacteristicsNew}");
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    Сharacteristics OLDсharacteristics = e.OldItems[0] as Сharacteristics;

                    Console.WriteLine($"Произошло удаление объекта{OLDсharacteristics}");
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    Сharacteristics сharacteristicsN = e.NewItems[0] as Сharacteristics;
                    Сharacteristics Oсharacteristics = e.OldItems[0] as Сharacteristics;
                    Console.WriteLine($"Произошло замена объекта {Oсharacteristics} на новый объект {сharacteristicsN}");
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }
    }

    public class Сharacteristics
    {
        public List<string> characteristics;
        public Сharacteristics()
        {

        }
        public override string ToString()
        {
            string tmp = "";
            foreach (string a in characteristics)
            {
                tmp += a + ".";
            }
            return tmp;
        }

    }
    #endregion
}
    
