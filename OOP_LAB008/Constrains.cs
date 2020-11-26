using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOP_LAB008
{

    public class One
    {
        public One()
        {
        }
    }

    public class Two<P> where P : class
    {
        public Two()
        {

        }
    }
    public class Third<U> where U : new()
    {
    }

    public class Set<T> : IAccount<T> where T : struct, IComparable<T>
    {
        private int count;
        private int size;
        public T[] setArr;
        public void Add(T el)
        {
            if (count == size) throw new Exception($"Массив заполнен! [{count}/{size}]");
            setArr[count] = el;
            count++;
        }

        public bool Remove(T element)
        {
            foreach (var o in setArr)
            {
                if (o.CompareTo(element) >= 0)
                    return true;
            }
            return false;
        }
        public void View()
        {
            foreach (var i in setArr)
            {
                Console.WriteLine($"{i}\n");
            }
        }
        public Set()
        {
            setArr = new T[size = 100]; 
            count = 0;
        }

        public Set(int arrSize)
        {
            setArr = new T[size = arrSize]; 
            count = 0;
        }
    }
    public static class WrFunction<T> where T : struct
    {
        public static void Zapis(T[] arr)
        {
            using (StreamWriter file = new StreamWriter(@"D:\UN\OOP_LAB008\1.txt", true))
            {
                file.Write("{");
                foreach (var i in arr)
                    file.Write($"{i} ");
                file.Write("}");
                file.Close();
            }
        }
    }
}

