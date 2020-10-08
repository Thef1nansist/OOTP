using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Text;

namespace OOP_4Lab
{
    public class List<T>
    {
        public List(T data)
        {
            Data = data;
        }
        public List()
        {
            
        }

        public T Data { get; set; }
        public List<T> Next { get; set; }

        List<T> head;
        List<T> tail;
        int countofSymbols;

        public void Add(T date)
        {
            List<T> list = new List<T>(date);

            if (head == null)
                head = list;
            else
                tail.Next = list;
            tail = list;

            countofSymbols++;
        }
        public static List<T> operator <<(List<T> op1, List<T> op2)
        {
            return new List<T>(); и что делать? o
        }
        public void Clear()
        {
            head = null;
            tail = null;
            countofSymbols = 0;
        }

    }
}
