using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;

namespace OOP_LAB008
{
 
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Set<int> set = new Set<int>(5);
                set.Add(1);
                set.Add(2);
                set.Add(3);
                set.Add(4);
                set.Add(5);
                set.Add(23); // show Exception
                set.View();

                Set<char> setsecond = new Set<char>(5);

                setsecond.Add('a');
                setsecond.Add('b');
                setsecond.Add('c');
                setsecond.Add('d');
                setsecond.Add('e');
                setsecond.View();
                WrFunction<int>.Zapis(set.setArr);
                WrFunction<char>.Zapis(setsecond.setArr);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Programm finally");
            }
        }
    }
}
