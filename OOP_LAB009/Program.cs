using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB009
{
    public delegate void Pricol();
    public delegate int Pricol2(int i);

    public static class MyClass
    {
        public static void Print()
        {
            Func<string, string> str = handle;

            Console.WriteLine(str("ivhssdvno,,,,,,"));
        }
        static string handle(string source)
        {
            return Replace(Insert(Remove(Add(ToCamelCase(source)))));
        }

        public static string ToCamelCase(string input)
        {
            var output = input.ToLower().ToCharArray();

            var up = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (up)
                {
                    output[i] = Char.ToUpper(output[i]);
                }
                up = !up;
            }

            var str = "";
            foreach (var ch in output)
            {
                str += ch;
            }

            return str;
        }
        public static string Replace(string input)
        {
            return input.Replace(",", "'");
        }
        public static string Remove(string input)
        {
            return input.Remove(0, 3);
        }

        public static string Insert(string input)
        {
            return input.Insert(0, "1234567890");
        }
        public static string Add(string input)
        {
            return input.Insert(input.Length, "1234567890");
        }
    }

    class Program
    {
        private static int FullHealthOne = 100;
        private static int FullHealthTwo = 100;
        //public Action action;
        //public event Pricol Event;
        //public event Action EventAction;

        //public static void Method1()
        //{
        //    Console.WriteLine("Method1");
        //}
        //public static int Method2()
        //{
        //    Console.WriteLine("Method2");
        //    return 0;
        //}
        //public static void Method3()
        //{
        //    Console.WriteLine("Method3");
        //}
        //public static void Method4()
        //   {
        //    Console.WriteLine("Method4");
        //}
        static void Main(string[] args)
        {
            MyClass.Print();
            Console.ReadKey();
            #region Game
            /*
            Console.WriteLine("Добро пожаловать в игру ПриколыС#\nВот некоторые правила:\n Вы на перестрелке против другого человека,\n есть некоторые команды, которые вам помогут выиграть:\n1.d- обычный урон(10)\n2.h- лечите себя, если у вас не 100% здоровья(10)\n3.m - выстрел с винтовки, но есть шанс, что вы промажете(50)\n.И другая любая кнопка может:\n1.Дать вам урон на выстрел +5 к прежнему\n2.Лишить урона\n3.Залекать себя(+10)\n4.Сделать супер удар(+40)\n5.Выстрелить в себя(-40 к хп) ");

            //ActionClass actionClass = new ActionClass
            //{
            //    Name = "VASY"
            //};
            //actionClass.GoToSleep += ActionClass_GoToSleep;
            //actionClass.DoWork += ActionClass_DoWork;
            //actionClass.TaceTime(DateTime.Parse("27.12.2018 21:13:00"));
            //actionClass.TaceTime(DateTime.Parse("27.12.2018 7:13:00"));
            Game gamerOne = new Game
            {
                PlayerOne = "Vlad"
            };
            Game gamerTwo = new Game
            {
                PlayerTwo = "Igor"
            };
            gamerOne.ToDamage += GamerOne_ToDamage;
            gamerOne.MegaDamage += GamerOne_MegaDamage;
            gamerOne.ToHealh += GamerOne_ToHealh;

            gamerTwo.ToDamage += GamerTwo_ToDamage;
            gamerTwo.MegaDamage += GamerTwo_MegaDamage;
            gamerTwo.ToHealh += GamerTwo_ToHealh;
            Console.WriteLine("Готовы?");
            var o = Console.ReadLine();
            Console.Clear();

            while (true)
            {
                var i = 1;

                gamerOne.FunctionOne(GetButtom());
                if (FullHealthOne <= 0)
                {
                    Console.WriteLine("Igor победил в этом сражении");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                gamerTwo.FunctionOne(GetButtom());
                if (FullHealthTwo <= 0)
                {

                    Console.WriteLine("Vlad победил в этом сражении");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                Console.Clear();
                Console.WriteLine($"    После {i} раунда");
                Console.WriteLine($"Vlad = {FullHealthOne}          Igor = {FullHealthTwo}");
                i++;
            }
            */
            #endregion


        }
        #region events_two
        private static void GamerTwo_ToHealh(object sender, EventArgs e)
        {
            if (FullHealthTwo < 100)
            {
                FullHealthTwo += (int)sender;
            }
            Console.WriteLine($"+ {sender}");
        }

        private static void GamerTwo_MegaDamage(object sender, EventArgs e)
        {
            Random random = new Random();
            int value1 = random.Next(0, 100);
            int value2 = random.Next(0, 100);
            if (value1 < value2 || (int)sender > 50)
            {
                FullHealthOne -= (int)sender;
                Console.WriteLine("Был произведён выстрел с винтовки! ");
                Console.Clear();
            }
        }

        private static void GamerTwo_ToDamage(object sender, EventArgs e)
        {
            FullHealthOne -= (int)sender;
            Console.WriteLine($"- {sender}");
        }
        #endregion
        #region events_one

        private static void GamerOne_ToHealh(object sender, EventArgs e)
        {

            if (FullHealthOne < 100)
            {
                FullHealthOne += (int)sender;
            }
            Console.WriteLine($"+ {sender}");

        }

        private static void GamerOne_MegaDamage(object sender, EventArgs e)
        {
            Random random = new Random();
            int value1 = random.Next(0, 100);
            int value2 = random.Next(0, 100);
            if (value1 > value2 || (int)sender > 50)
            {
                FullHealthTwo -= (int)sender;
                Console.WriteLine($"Был произведён выстрел с винтовки! -{sender} ");
            }

        }

        private static void GamerOne_ToDamage(object sender, EventArgs e)
        {
            FullHealthTwo -= (int)sender;
            Console.WriteLine($"- {sender}");
        }

        public static char GetButtom()
        {
            Console.WriteLine("нажимайте кнопку");
            char but = Console.ReadKey().KeyChar;

            return but;
        }
        #endregion

    }
}
