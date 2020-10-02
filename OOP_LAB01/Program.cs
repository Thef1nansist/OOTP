using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {

                #region 1

                #region примитивные типы

                bool booltest = true;
                byte bytetest = byte.MaxValue;
                sbyte sbytetest = sbyte.MaxValue;
                char chartest = 'f';
                decimal decimaltest = Decimal.MaxValue;
                double doubletest = Double.MaxValue;
                float floattest = float.MaxValue;
                int inttest = int.MaxValue;
                uint uinttest = uint.MaxValue;
                long longtest = long.MaxValue;
                ulong ulongtest = ulong.MaxValue;
                short shorttest = short.MaxValue;
                ushort ushorttest = ushort.MaxValue;

                Console.WriteLine(
                    $"booltest: {booltest}\nbytetest: {bytetest}\nsbytetest: {sbytetest}\nchartest: {chartest}\n" +
                    $"decimaltest: {decimaltest}\ndouble: {doubletest}\nfloattest: {floattest}\ninttest: {inttest}\n" +
                    $"uinttest: {uinttest}\nlongtest: {longtest}\nulongtest: {ulongtest}\nshorttest: {shorttest}\nushort: {ushorttest}");

                #endregion

                #region явное преобразование

                int a = 255;

                byte b = (byte)a;
                int c = (int)b;
                long d = (long)a;

                long e = 255;

                byte f = (byte)e;
                int g = (int)e;

                #endregion

                #region неявное приведение

                byte aa = 255;

                long ab = aa;
                int ac = aa;
                short ad = aa;
                double af = aa;
                ushort ag = aa;

                #endregion

                #region Convert

                string aaa = "255";

                byte aab = Convert.ToByte(aaa);
                int aac = Convert.ToInt16(aaa);
                double aad = Convert.ToDouble(aaa);

                #endregion

                #region упаковка и распаковка

                int x = 255;
                Object obj = x;
                x = (int)obj;

                long y = 5786;
                Object obje = y;
                y = (long)obje;

                short z = 877;
                Object objec = z;
                z = (short)objec;

                #endregion

                #region Неявно типизированные локальные переменные

                var intovaya = 567;
                var color = Color.Aqua;
                var client = new WebClient();
                var str = "строка";
                var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                #endregion

                #region null

                int? nullable = null;

                if (nullable.HasValue)
                    Console.WriteLine(nullable.Value);

                int? _nullable = 76;

                if (_nullable.HasValue)
                    Console.WriteLine(_nullable.Value);

                #endregion

                #region var

                var stroka = "something";

                /*
                stroka = 123;
                */

                #endregion

                #endregion
                #region 2

                #region Объявите строковые литералы. Сравните их

                string str1 = "hello";
                string str2 = "world";

                if (str1 == str2)
                {
                    Console.WriteLine(str1 + str2);
                }
                else
                {
                    Console.WriteLine(str2 + str1);
                }

                #endregion

                #region сцепление, копирование, выделение подстроки и тд

                string str3 = "hello world";
                string str4 = "ello word";
                string str5;

                Console.WriteLine(str3 + str4);

                str5 = str3;
     
                Console.WriteLine(str4.Substring(0, 4));

                string[] words = str4.Split(' ');
                foreach (string s in words)
                    Console.WriteLine(s);

                Console.WriteLine(str4.Insert(0, "h").Insert(9, "l"));

                Console.WriteLine(str4.Replace("word", "world"));

                Console.WriteLine(str4.Remove(0, 4));

                #endregion

                #region Продемонстрируйте интерполирование строк

                Console.WriteLine($"str4: {str4}\nstr3: {str3}");

                #endregion

                #region Создайте пустую и null строку

                string str6 = null;

                if (string.IsNullOrEmpty(str6))
                {
                    Console.WriteLine("is null");
                }
                else
                {
                    Console.WriteLine("is not null");
                }

                #endregion

                #region stringBuilder

                StringBuilder stringBuilder = new StringBuilder("chtoto strokovoe");

                stringBuilder.Remove(4, 2);
                stringBuilder.Insert(0, " str ");
                stringBuilder.Append(" ne str ");

                Console.WriteLine(str6);
                #endregion

                #endregion
                #region 3

                #region Создайте целый двумерный массив и выведите его на консоль 

                int[,] mass = new int[2, 3] { { 1, 2, 3 }, { 0, 1, 2 } };

                for (var i = 0; i < mass.GetLength(0); i++, Console.WriteLine(""))
                    for (int j = 0; j < mass.GetLength(1); j++)
                    {
                        Console.Write("{0}\t", mass[i, j]);
                    }
                #endregion
                #region создание одномерного массива
                string[] weekDays = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
                Console.WriteLine("Размер массива= " + weekDays.Length);
                for (var i = 0; i < weekDays.Length; i++)
                {
                    Console.Write("{0}\t", weekDays[i]);
                }
                Console.WriteLine("\n");
                Console.WriteLine("Введите позицию ");
                var index = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите переменную ");
                var strToReplace = Console.ReadLine();
                weekDays[index] = strToReplace;
                Console.WriteLine("new array:");
                foreach (var str7 in weekDays)
                {
                    Console.Write(str7 + "\t");
                }
                #endregion
                #region Создайте ступечаты массив вещественных чисел
                var NewArray = new double[3][];
                NewArray[0] = new double[2];
                NewArray[1] = new double[3];
                NewArray[2] = new double[4];

                Console.WriteLine("\nВведите переменные в ваш массив: \n");
                for (int i = 0; i < NewArray.Length; i++)
                {
                    for (int j = 0; j < NewArray[i].Length; j++)
                    {
                        NewArray[i][j] = Double.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine("\nВаш массив: ");
                for (int j = 0; j < NewArray.Length; j++)
                {

                    Console.WriteLine();
                    for (int i = 0; i < NewArray[j].Length; i++)
                    {
                        Console.WriteLine(NewArray[j][i]);
                    }
                }

                #endregion
                #region Создайте неявно типизированные переменные для хранения массива и строки
                var myArr = new object[0];
                var strochka = "";
                #endregion
                #endregion
                #region 4
                #region Задайте кортеж из 5 элементов с типами int, string, char, string, ulong
                (int, string, char, string, ulong) t1 = (1, "prikol", '#', "asdsd", 116);
                Console.WriteLine(t1);
                int k = 4;
                Console.WriteLine("Какой элемент вывести: ");
                var n = Int32.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.WriteLine(t1.Item1);
                        break;
                    case 2:
                        Console.WriteLine(t1.Item2);
                        break;
                    case 3:
                        Console.WriteLine(t1.Item3);
                        break;
                    case 4:
                        Console.WriteLine(t1.Item4);
                        break;
                    case 5:
                        Console.WriteLine(t1.Item5);
                        break;
                    default:
                        Console.WriteLine("Вы нажали неизвестную букву");
                        break;
                }
                var obj7 = new Tuple<int, string, char, string, ulong>(5, "john", 'f', "johnson", 8765);
                var tuple = Tuple.Create<int, string, short>(123, "123", 123);
                _ = 10;
                var left = (a: 6, b: 10);
                var right = (a: 5, b: 10);
                if (left == right)
                {
                    Console.WriteLine("Кортежи равны.");
                }
                else
                {
                    Console.WriteLine("Кортежи неравны.");
                }

                #endregion
                #endregion
                #region 5 Создайте локальную функцию в main и вызовите ее
                Tuple<int, int, int, char> TestFunc(int[] arr, string funcString)
                {
                    return new Tuple<int, int, int, char>(arr.Max(), arr.Min(), arr.Sum(), funcString[0]);
                }

                var intArr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
                var funcStr = "abcd";

                var testFuncTuple = Tuple.Create(TestFunc(intArr, funcStr));
                #endregion
                #region 6
                void CheckedTest()
                {
                    try
                    {
                        int pre = int.MaxValue;
                        int pres = int.MaxValue;
                        checked
                        {
                            int rez = pre + pres;
                            Console.WriteLine("a+b= " + rez + "\n");
                        }
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Переполнение \n");
                    }
                }
                CheckedTest();
                void UnCheckedTest()
                {
                    try
                    {
                        int pre = int.MaxValue;
                        int pres = int.MaxValue;
                        checked
                        {
                            int rez = pre + pres;
                            Console.WriteLine("a+b= " + rez + "\n");
                        }
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Переполнение");
                    }
                }
                UnCheckedTest();

                #endregion
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}



